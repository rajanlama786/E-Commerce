using CatalogService.BusinessManager;
using CommonEnitity.Catalog;
using CommonEnitity.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CatalogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {

        [Authorize]
        // GET: api/<CatalogController>
        [HttpPost("GetCatalogItemListAsync")]
        public async Task<IEnumerable<CatalogItem>> GetCatalogItemListAsync()
        {
            ICatalogManager catalogManager = CatalogManagerFactory.Create();
            return await catalogManager.GetCatalogItemListAsyc();
        }

        [HttpPost("GetCatalogItemAsync")]
        public Task<CatalogItem> GetCatalogItemAsync(Guid CatalogItemID)
        {
            ICatalogManager catalogManager = CatalogManagerFactory.Create();
            return catalogManager.GetCatalogItemByIDAsync(CatalogItemID);
        }

        [HttpPost("CatalogItemAddAsync")]
        public async Task CatalogItemAddAsync([FromBody] CatalogItem objCatalogItem)
        {
            ICatalogManager catalogManager = CatalogManagerFactory.Create();
            objCatalogItem.Id = Guid.NewGuid();
            await catalogManager.CatalogItemAddAsync(objCatalogItem);
        }

        [HttpPost("CatalogItemUpdateAsync")]
        public async Task CatalogItemUpdateAsync([FromBody] CatalogItem objCatalogItem)
        {
            ICatalogManager catalogManager = CatalogManagerFactory.Create();           
            await catalogManager.CatalogItemUpdateAsync(objCatalogItem);
        }

        // GET api/<CatalogController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CatalogController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CatalogController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CatalogController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
