using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuteSurvey.Utility
{   
        public class Common
    {   
            /// <summary>
            /// 
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="item1">Actual Object</param>
            /// <param name="item2">Target Object</param>
            public static void Combine<T>(ref T target, T source)
            {
                Type t = typeof(T);
                var properties = t.GetProperties().Where(prop => prop.CanRead && prop.CanWrite);
                foreach (var prop in properties)
                {
                    var value = prop.GetValue(source, null);
                    if (value != null)
                        prop.SetValue(target, value, null);
                }
            }
        }
    
}
