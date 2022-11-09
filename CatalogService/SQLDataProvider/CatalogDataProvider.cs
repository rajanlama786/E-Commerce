using CommonEnitity.Catalog;
using Microsoft.AspNetCore.Http.HttpResults;
using SQLHelper;

namespace CatalogService.SQLDataProvider;

public class CatalogDataProvider: ICatalogDataProvider
{
    public async Task<IEnumerable<CatalogItem>> GetCatalogItemListAsyc()
    {
        SQLGetListAsync objSQLH = new SQLGetListAsync();
        //[dbo].[uspGetCatalogItemList]
        string spName = objSQLH.GetFullSpName("uspGetCatalogItemList");
        try
        {
            IEnumerable<CatalogItem> objCataLogList =
                await objSQLH.ExecuteAsListAsync<CatalogItem>(spName);
            return objCataLogList;
        }
        catch 
        {
            throw;
        }
    }

    public async Task<CatalogItem> GetCatalogItemByIDAsync(Guid itemID)
    {
        List<SQLParam> sParam = new List<SQLParam>
        {
            new SQLParam("@ItemID", itemID)
        };
        SQLGetAsync objSQLH = new SQLGetAsync();
        string spName = objSQLH.GetFullSpName("uspGetCatalogItemByID");
        try
        {
            return await objSQLH.ExecuteAsObjectAsync<CatalogItem>(spName, sParam);
        }
        catch
        {
            throw;
        }
    }

    public async Task CatalogItemAddAsync(CatalogItem objCatalogItem)
    {
        List<SQLParam> sParam = new List<SQLParam>
        {
            new SQLParam("@Id", objCatalogItem.Id),
            new SQLParam("@Name", objCatalogItem.Name),
            new SQLParam("@AvailableStock", objCatalogItem.AvailableStock),
            new SQLParam("@CatalogTypeId", objCatalogItem.CatalogTypeId),            
            new SQLParam("@CatalogBrandId", objCatalogItem.CatalogBrandId),
            new SQLParam("@Description", objCatalogItem.Description),
            new SQLParam("@MaxStockThreshold", objCatalogItem.MaxStockThreshold),
            new SQLParam("@OnReorder", objCatalogItem.OnReorder),
            new SQLParam("@PictureFileName", objCatalogItem.PictureFileName),
            new SQLParam("@PictureUri", objCatalogItem.PictureUri),
            new SQLParam("@Price", objCatalogItem.Price),
            new SQLParam("@RestockThreshold", objCatalogItem.RestockThreshold)           
        };
        SQLExecuteNonQueryAsync objSQLH = new SQLExecuteNonQueryAsync();
        string spName = objSQLH.GetFullSpName("uspCatalogItemAdd");
        try
        {
            await objSQLH.ExecuteNonQueryAsync(spName, sParam);
        }
        catch
        {
            throw;
        }
    }

    public async Task CatalogItemUpdateAsync(CatalogItem objCatalogItem)
    {
        List<SQLParam> sParam = new List<SQLParam>
        {
            new SQLParam("@Id", objCatalogItem.Id),
            new SQLParam("@Name", objCatalogItem.Name),
            new SQLParam("@AvailableStock", objCatalogItem.AvailableStock),
            new SQLParam("@CatalogTypeId", objCatalogItem.CatalogTypeId),
            new SQLParam("@CatalogBrandId", objCatalogItem.CatalogBrandId),
            new SQLParam("@Description", objCatalogItem.Description),
            new SQLParam("@MaxStockThreshold", objCatalogItem.MaxStockThreshold),
            new SQLParam("@OnReorder", objCatalogItem.OnReorder),
            new SQLParam("@PictureFileName", objCatalogItem.PictureFileName),
            new SQLParam("@PictureUri", objCatalogItem.PictureUri),
            new SQLParam("@Price", objCatalogItem.Price),
            new SQLParam("@RestockThreshold", objCatalogItem.RestockThreshold)
        };
        SQLExecuteNonQueryAsync objSQLH = new SQLExecuteNonQueryAsync();
        string spName = objSQLH.GetFullSpName("uspCatalogItemUpdate");
        try
        {
            await objSQLH.ExecuteNonQueryAsync(spName, sParam);
        }
        catch
        {
            throw;
        }
    }
}

