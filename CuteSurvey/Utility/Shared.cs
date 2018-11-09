using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CuteSurvey.Utility
{   
        public static class Common
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


        public static List<T> toList<T>(this System.Data.DataTable dt, DataFieldMappings df,Func<T,T> Bind)
        {
            try
            {
                const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
                var columnNames = dt.Columns.Cast<DataColumn>()
                    .Select(c => c.ColumnName)
                    .ToList();
                var ints = Activator.CreateInstance<T>();
                var objectProperties = GetAllProperties(typeof(T));
                var targetList = dt.AsEnumerable().Select(dataRow =>
                {
                    var instanceOfT = Activator.CreateInstance<T>();
                    // foreach (var properties in objectProperties.Where(properties => columnNames.Contains(properties.Name) && dataRow[properties.Name] != DBNull.Value))
                    foreach (DataFieldMapping d in df.GetMapping())
                    {
                        if (dt.Columns.Contains(d.DataField))
                        {
                            var property = objectProperties.Where(
                                                    properties => properties.Name == d.MemberField && dataRow[d.DataField] != DBNull.Value
                                                    );
                            if (property.Count() > 0)
                            {
                                var pt = property.FirstOrDefault();
                                pt.SetValue(instanceOfT, dataRow[d.DataField], null);
                                
                            }
                        }
                    }
                    instanceOfT = Bind(instanceOfT);
                    return instanceOfT;
                }).ToList();

                return targetList.ToList<T>();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
        }

        public static List<T> toList<T>(this System.Data.DataTable dt, DataFieldMappings df)
        {
            try {
               // const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
                var columnNames = dt.Columns.Cast<DataColumn>()
                    .Select(c => c.ColumnName)
                    .ToList();
                var ints = Activator.CreateInstance<T>();
                var objectProperties = GetAllProperties(typeof(T));
                var targetList = dt.AsEnumerable().Select(dataRow =>
                {
                    var instanceOfT = Activator.CreateInstance<T>();
                    // foreach (var properties in objectProperties.Where(properties => columnNames.Contains(properties.Name) && dataRow[properties.Name] != DBNull.Value))
                    foreach (DataFieldMapping d in df.GetMapping())
                    {
                        if (dt.Columns.Contains(d.DataField))
                        {
                            var property = objectProperties.Where(
                                                    properties => properties.Name == d.MemberField && dataRow[d.DataField] != DBNull.Value
                                                    );
                            if (property.Count() > 0)
                            {
                                var pt = property.FirstOrDefault();
                                pt.SetValue(instanceOfT, dataRow[d.DataField], null);
                            }
                        }
                    }                
                    return instanceOfT;
                }).ToList();

                return targetList.ToList<T>();
            } catch (Exception e) {
                throw new Exception (e.Message ,e.InnerException  );
            }            
        }

        public static IEnumerable<PropertyInfo> GetAllProperties(Type t)
        {
            if (t == null)
                return Enumerable.Empty<PropertyInfo>();

            BindingFlags flags = BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly;
            return t.GetProperties(flags).Union(GetAllProperties(t.BaseType));
        }


    }


}



public class DataFieldMappings {
    private List<DataFieldMapping> dfm;
    public DataFieldMappings() {
        dfm = new List<DataFieldMapping>();
    }
    public List<DataFieldMapping> GetMapping() {
        return dfm;
    }
    public DataFieldMappings Add(string dataField, string memberField) {
        dfm.Add(new DataFieldMapping(dataField, memberField));
        return this;
    }
}

public class DataFieldMapping {
    public string DataField;
    public string MemberField;
    public DataFieldMapping(string dataField,string memberField) {
        DataField = dataField;
        MemberField = memberField;
    }
}