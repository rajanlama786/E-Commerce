using CommonEnitity.Catalog;
using System.Runtime.CompilerServices;

namespace CatalogService.SQLDataProvider;

public interface ICatalogDataProvider
{
    Task<IEnumerable<CatalogItem>> GetCatalogItemListAsyc();
    Task<CatalogItem> GetCatalogItemByIDAsync(Guid itemID);
    Task CatalogItemAddAsync(CatalogItem objCatalogItem);

    Task CatalogItemUpdateAsync(CatalogItem objCatalogItem);
}

