using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuteSurvey.Utility
{
  public class QueryList <T>
    {
        private IList<T> ql ;

        public QueryList() {
        ql = new List<T>();
        }
        public void Add(T item) {
            ql.Add(item);
        }
        public void Remove(T item) {
            ql.Remove(item);
        }

        public void Remove(Func<T, bool> search)
        {
            ql.RemoveAt(ql.IndexOf(ql.Where(search).FirstOrDefault()));
        }
        public int Max(Func<T, int> max) {
            return ql.Max<T>(max);
        }
        public List<T> Search(Func<T, bool> search) {
            return ql.Where(search).ToList<T>();
        }
        public void Clear() {
            ql.Clear();
        }
        public int Count() {
            return ql.Count;
        }
        public void CopyTo(T[] array,int index) {
            ql.CopyTo(array, index);            
        }
        public bool Contains(T item) {            
            return ql.Contains(item);
        }

        public List<T> toList() {
            return ql.ToList();
        }
    }
}
