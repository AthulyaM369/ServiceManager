using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceManager_EntityLayer;
using ServiceManager_DataLayer;
using static ServiceManager_BusinessLogicLayer.bll_ServiceManager;
using System.Data;

namespace ServiceManager_BusinessLogicLayer
{
    public class bll_ServiceManager
    {
        
            dal_ServiceManager objReportDal = new dal_ServiceManager();

            public object ServiceManager(oel_ServiceManager Data)
            {
                try
            {
                var result = objReportDal.ServiceManager(Data);
                return result;
            }
                catch (Exception)
                {

                    throw;
                }
            }


    }
}
