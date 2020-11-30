using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Models.SessionCommon
{
    public class SessionHelper
    {
        public static void setSession(UserSession session)
        {
            HttpContext.Current.Session["UsernameSession"] = session.UsernameSession;
            HttpContext.Current.Session["RoleSession"] = session.RoleSession;
        }
        public static string getUserSession()
        {
            var userS = HttpContext.Current.Session["UsernameSession"];
            return (string )userS;
        }
        public static string getRoleSession()
        {
            var role = HttpContext.Current.Session["RoleSession"];
            return (string) role;
        }
    }
}
