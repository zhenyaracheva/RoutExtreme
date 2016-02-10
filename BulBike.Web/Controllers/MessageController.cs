using BulBike.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BulBike.Web.Controllers
{
    public class MessageController : BaseController
    {

        public MessageController(IUserService users)
            : base(users)
        {
        }

        public ActionResult CreateMessage()
        {
            return View();
        }
    }
}