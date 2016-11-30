using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.HtmlControls;
using Domain.Abstract;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebUI.Controllers;
using WebUI.HtmlHelpers;
using WebUI.Models;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            Mock<IElectronicCigarettesRepository> mock = new Mock<IElectronicCigarettesRepository>();
            mock.Setup(m => m.ElectronicCigarettes).Returns(new List<ElectronicCigarettes>
            {
                new ElectronicCigarettes {ElectronicCigarettesId = 1, Name = "cig1"},
                new ElectronicCigarettes {ElectronicCigarettesId = 2, Name = "cig2"},
                new ElectronicCigarettes {ElectronicCigarettesId = 3, Name = "cig3"},
                new ElectronicCigarettes {ElectronicCigarettesId = 4, Name = "cig4"},
                new ElectronicCigarettes {ElectronicCigarettesId = 5, Name = "cig5"}
            });

            ElectronicCigarettesController controller = new ElectronicCigarettesController(mock.Object);
            controller.pageSize = 3;

            IEnumerable<ElectronicCigarettes> result = (IEnumerable<ElectronicCigarettes>)controller.List(null,2).Model;

            List<ElectronicCigarettes> electronicCigarettes = result.ToList();

            Assert.IsTrue(electronicCigarettes.Count == 2);


            Assert.AreEqual(electronicCigarettes[0].Name, "cig4");
            Assert.AreEqual(electronicCigarettes[1].Name, "cig5");
        }
        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            //организация
            HtmlHelper myhelper = null;
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };
            Func<int, string> pageUrlDelegate = i => "Page" + i;
            //действие
            MvcHtmlString result = myhelper.PageLinks(pagingInfo, pageUrlDelegate);

            //Утверждение
            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
                            + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
                            + @"<a class=""btn btn-default"" href=""Page3"">3</a>",
                result.ToString());
        }
    }
}
