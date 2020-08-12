using DevExtremeMvcApp1.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace DevExtremeMvcApp1.Controllers {
    public class HomeController : Controller {

        FuhrparkContextEntities context = new FuhrparkContextEntities();
        public ActionResult Index() {
            SqlParameter[] param = new SqlParameter[] {

            };

            var data = context.Database.SqlQuery<GetIndexUebersicht_Result>("GetIndexUebersicht").ToList();
            return View(data);
        }


        public ActionResult About()
        {
            SqlParameter[] param = new SqlParameter[] {

            };

            var data = context.Database.SqlQuery<GetIndexUebersicht_Result>("GetIndexUebersicht").ToList();
            return View(data);
        }


        public ActionResult uebersicht()
        {
            SqlParameter[] param = new SqlParameter[] {

            };

            var data = context.Database.SqlQuery<GetIndexUebersicht_Result>("GetIndexUebersicht").ToList();
            return View(data);
        }
    }
}