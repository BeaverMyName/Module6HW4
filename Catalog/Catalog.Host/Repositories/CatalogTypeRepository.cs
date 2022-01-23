using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories
{
    public class CatalogTypeRepository : ICatalogTypeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CatalogTypeRepository(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<IEnumerable<CatalogType>?> GetTypesAsync()
        {
            var items = await _dbContext.CatalogTypes.ToListAsync();
            return items;
        }

        public async Task<int?> Add(string type)
        {
            var item = _dbContext.CatalogTypes.Add(new CatalogType
            {
                Type = type
            });

            await _dbContext.SaveChangesAsync();

            return item.Entity.Id;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var type = await _dbContext.CatalogTypes.FirstOrDefaultAsync(x => x.Id == id);

                if (type is null)
                {
                    return false;
                }

                _dbContext.CatalogTypes.Remove(type);

                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Update(int id, string type)
        {
            try
            {
                var typeToUpdate = await _dbContext.CatalogTypes.FirstOrDefaultAsync(x => x.Id == id);

                if (typeToUpdate is null)
                {
                    return false;
                }

                typeToUpdate.Type = type;

                _dbContext.CatalogTypes.Update(typeToUpdate);
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
