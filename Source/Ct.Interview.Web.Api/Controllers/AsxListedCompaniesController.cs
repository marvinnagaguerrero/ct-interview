using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Ct.Interview.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsxListedCompaniesController : ControllerBase
    {
        private IAsxListedCompaniesService _asxListedCompaniesService = new AsxListedCompaniesService();

        public AsxListedCompaniesController(IAsxListedCompaniesService asxListedCompaniesService)
        {
            _asxListedCompaniesService = asxListedCompaniesService;
        }

        [HttpGet("{asxcode}")]
        public async Task<ActionResult<AsxListedCompanyResponse[]>> Get(string asxcode)
        {
            var asxListedCompanies = await _asxListedCompaniesService.GetByAsxCode(asxcode);
            return Mapper.Map<AsxListedCompanyResponse[]>(asxListedCompanies);
        }

        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
    }
}
