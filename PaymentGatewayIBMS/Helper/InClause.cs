using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGatewayIBMS.Helper
{
    public static class InClause
    {
        public static bool In<T>(this T source, params T[] list)
        {
            return list.Contains(source);
        }
    }
}
