using Ct.Interview.Web.Api.Data;
using System.Threading.Tasks;

namespace Ct.Interview.Web.Api
{
    public class AsxListedCompaniesService : IAsxListedCompaniesService
    {
        public Task<AsxListedCompany[]> GetByAsxCode(string asxCode)
        {
            var o = new AsxListedCompany[1] { ASXdata.GetOrganisation(asxCode) };
            return Task.FromResult<AsxListedCompany[]>(o);
        }
    }
}
