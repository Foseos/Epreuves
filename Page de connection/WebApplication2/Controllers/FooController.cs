﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class FooController : Controller
    {
        // GET: Foo
        public ActionResult Index()
        {
            return View();
        }
    }
}