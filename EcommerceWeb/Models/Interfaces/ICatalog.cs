using CommonEnitity.Catalog;

namespace WebEcommerce.Models.Interfaces;

public interface ICatalog
{
    Task<IEnumerable<CatalogItem>> GetCatalogItemListAsyc();
    Task<CatalogItem> GetCatalogItemByIDAsync(Guid itemID);

    Task CatalogItemAddAsync(CatalogItem objCatalogItem);
    Task CatalogItemUpdateAsync(CatalogItem objCatalogItem);
}

