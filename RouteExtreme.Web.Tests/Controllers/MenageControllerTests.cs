using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
using Moq;
using RouteExtreme.Web.App_Start;
using RouteExtreme.Services.Contracts;
using RouteExtreme.Web.Controllers;
using RouteExtreme.Models;
using TestStack.FluentMVCTesting;
using System.Collections.Generic;
using System.Linq;

namespace RouteExtreme.Web.Tests.Controllers
{
    [TestClass]
    public class MenageControllerTests
    {
        [TestMethod]
        public void AddPhoneNumber()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(ManageController).Assembly);

            var userServerce = new Mock<IUserService>();
            var chatServerce = new Mock<IChatRoomService>();
            
            var controller = new ManageController(userServerce.Object, chatServerce.Object);
            controller.WithCallTo(x => x.AddPhoneNumber())
                .ShouldRenderView("AddPhoneNumber");
        }

    }
}
