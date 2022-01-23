using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces
{
    public interface ICatalogTypeRepository
    {
        Task<IEnumerable<CatalogType>?> GetTypesAsync();
        Task<int?> Add(string type);
        Task<bool> Delete(int id);
        Task<bool> Update(int id, string type);
    }
}
