using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LoginSession.Core.Application.Helpes
{
    public static class SessionHelper
    {
        public static void Set<T>(this ISession session, string key,T values)
        {
            session.SetString(key,JsonConvert.SerializeObject(values));
        }

        public static T Get<T>(this ISession session, string key)
        {
           var value = session.GetString(key);
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
