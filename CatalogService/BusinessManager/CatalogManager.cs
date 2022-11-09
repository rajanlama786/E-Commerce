using CatalogService.SQLDataProvider;
using CommonEnitity.Catalog;

namespace CatalogService.BusinessManager;

public class CatalogManager : ICatalogManager
{
    public async Task<IEnumerable<CatalogItem>> GetCatalogItemListAsyc()
    {
        ICatalogDataProvider objcatalogDataProvider = CatalogFactory.Create();
        return await objcatalogDataProvider.GetCatalogItemListAsyc();
    }

    public async Task<CatalogItem> GetCatalogItemByIDAsync(Guid itemID)
    {
        ICatalogDataProvider objcatalogDataProvider = CatalogFactory.Create();
        return await objcatalogDataProvider.GetCatalogItemByIDAsync(itemID);
    }

    public async Task CatalogItemAddAsync(CatalogItem objCatalogItem)
    {
        ICatalogDataProvider objcatalogDataProvider = CatalogFactory.Create();
        await objcatalogDataProvider.CatalogItemAddAsync(objCatalogItem);
    }

    public async Task CatalogItemUpdateAsync(CatalogItem objCatalogItem)
    {
        ICatalogDataProvider objcatalogDataProvider = CatalogFactory.Create();
        await objcatalogDataProvider.CatalogItemUpdateAsync(objCatalogItem);
    }
}

