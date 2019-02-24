using Ct.Interview.Web.Api;
using Ct.Interview.Web.Api.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ct_interview_tests
{
    [TestClass]
    public class ct_IntegrationTets
    {
        [TestMethod]
        public void ASXData_RetrieveExisting_ShouldGetObject()
        {
            var sut = ASXdata.GetOrganisation("MOQ");
            Assert.IsFalse(string.IsNullOrWhiteSpace(sut.AsxCode));
        }


        [TestMethod]
        public void ASXData_RetrieveNonExisting_ShouldGetObject()
        {
            var sut = ASXdata.GetOrganisation("XMOQX");
            Assert.IsNull(sut);
        }

        [TestMethod]
        public async Task AsxListedCompaniesService_RetrieveExisting_ShouldGetObject()
        {
            IAsxListedCompaniesService sut = new AsxListedCompaniesService();
            var asxListedCompanies = await sut.GetByAsxCode("MOQ");
            Assert.IsFalse(string.IsNullOrWhiteSpace(asxListedCompanies[0].AsxCode));
        }
    }
}
