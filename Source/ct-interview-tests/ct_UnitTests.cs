using Ct.Interview.Web.Api;
using Ct.Interview.Web.Api.Controllers;
using Ct.Interview.Web.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Threading.Tasks;

namespace ct_interview_tests
{
    [TestClass]
    public class ctUnitTests
    {
        [TestMethod]
        public async Task AsxListedCompanies_HappyRequest_ReturnsWithExpectedRecord()
        {
            // Arrange
            var counter = 0;
            var subService = Substitute.For<IAsxListedCompaniesService>();
            subService.GetByAsxCode("TEST")
                .Returns(new AsxListedCompany[1]
                { new AsxListedCompany
                { AsxCode="testCode", CompanyName = "tCompany", GicsIndustryGroup="gCompany"} })
                .AndDoes(x => counter++);

            var systemUT = new AsxListedCompaniesController(subService);

            // Act
            var methodUT = await systemUT.Get("TEST");
            var objectUT = (methodUT.Value);


            // Assert
            Assert.AreEqual(objectUT.GetType().ToString() , "Ct.Interview.Web.Api.AsxListedCompanyResponse[]");
            Assert.AreEqual(objectUT[0].CompanyName, "tCompany");
            Assert.AreEqual(objectUT[0].AsxCode, "testCode");
        }





    }
}
