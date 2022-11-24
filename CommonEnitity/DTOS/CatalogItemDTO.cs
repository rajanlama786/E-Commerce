using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonEnitity.DTOS;

public class CatalogItemDTO
{
    public string id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public double price { get; set; }
    public string pictureFileName { get; set; }
    public string pictureUri { get; set; }
    public int catalogTypeId { get; set; }
    public object catalogType { get; set; }
    public int catalogBrandId { get; set; }
    public object catalogBrand { get; set; }
    public int availableStock { get; set; }
    public int restockThreshold { get; set; }
    public int maxStockThreshold { get; set; }
    public bool onReorder { get; set; }
}

