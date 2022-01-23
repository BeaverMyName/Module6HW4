using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces
{
    public interface ICatalogBrandRepository
    {
        Task<IEnumerable<CatalogBrand>?> GetBrandsAsync();
        Task<int?> Add(string brand);
        Task<bool> Delete(int id);
        Task<bool> Update(int id, string brand);
    }
}
