using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace baitapCNPM.Common
{
    public static class SessionPersister
    {
        public static string UserName
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return string.Empty;
                }
                var sessionVar =
               HttpContext.Current.Session[Common.SessionName.USER_SESSION];
                if (sessionVar != null)
                {
                    return sessionVar as string;
                }
                return null;
            }
            set
            {
                HttpContext.Current.Session[Common.SessionName.USER_SESSION] = value;
            }
        }
    }
}