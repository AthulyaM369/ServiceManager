using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ServiceManager_EntityLayer
{
    public class oel_ServiceManager
    {

        string _mode = "", name = "", user_Code = "", active = "", gender = "";
        int userID = 0;
        DateTime? dob = null;
        bool returnDs = false, returnDt = false;

        public string Mode { get => _mode; set => _mode = value; }
        public string Name { get => name; set => name = value; }
        public string User_Code { get => user_Code; set => user_Code = value; }
        public int UserID { get => userID; set => userID = value; }
        public bool ReturnDs { get { return returnDs; } set { returnDs = value; } }
        public bool ReturnDt { get => returnDt; set => returnDt = value; }

    }
}