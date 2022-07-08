using System;
using System.Collections.Generic;

namespace PeopleApp.Unit.Tests.Library.Comparers
{
    public class GenericComparer<T> : IEqualityComparer<T> where T : class
    {
        public GenericComparer(Func<T, object> expr)
        {
            this._expr = expr;
        }

        private Func<T, object> _expr { get; set; }

        public bool Equals(T x, T y)
        {
            var first = _expr.Invoke(x);
            var sec = _expr.Invoke(y);
            if (first != null && first.Equals(sec))
            {
                return true;
            }
            return false;
        }

        public int GetHashCode(T obj)
        {
            return obj.GetHashCode();
        }
    }
}