using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceManager_BusinessLogicLayer;
using ServiceManager_EntityLayer;

namespace ServiceManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView();
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ServiceManager(oel_ServiceManager Data)
        {
            string json = "";
            try
            {
                bll_ServiceManager BLLServiceManager = new bll_ServiceManager();
                DataTable dt = (DataTable)BLLServiceManager.ServiceManager(Data);
                json = JsonConvert.SerializeObject(dt, Formatting.Indented);

                return new JsonResult()
                {
                    Data = json,
                    MaxJsonLength = 86753090,
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string SaveManager(DataTable json, oel_ServiceManager Data)
        {
            string int_result = "";
            bll_ServiceManager BLLServiceManager = new bll_ServiceManager();
            try
            {
                int_result = (string)BLLServiceManager.ServiceManager(Data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return int_result.ToString();
        }



    }
}