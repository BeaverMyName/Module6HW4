using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories
{
    public class CatalogBrandRepository : ICatalogBrandRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CatalogBrandRepository(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<IEnumerable<CatalogBrand>?> GetBrandsAsync()
        {
            var items = await _dbContext.CatalogBrands.ToListAsync();
            return items;
        }

        public async Task<int?> Add(string brand)
        {
            var item = _dbContext.CatalogBrands.Add(new CatalogBrand
            {
                Brand = brand
            });

            await _dbContext.SaveChangesAsync();

            return item.Entity.Id;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var brand = await _dbContext.CatalogBrands.FirstOrDefaultAsync(x => x.Id == id);

                if (brand is null)
                {
                    return false;
                }

                _dbContext.CatalogBrands.Remove(brand);

                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Update(int id, string brand)
        {
            try
            {
                var brandToUpdate = await _dbContext.CatalogBrands.FirstOrDefaultAsync(x => x.Id == id);

                if (brandToUpdate is null)
                {
                    return false;
                }

                brandToUpdate.Brand = brand;

                _dbContext.CatalogBrands.Update(brandToUpdate);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
