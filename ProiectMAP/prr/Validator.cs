using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prr
{
    public interface Validator<T>
    {
        Boolean validate(T obj, out String message);
    }


    public class OrderValidator : Validator<Order>
    {
        public Boolean validate(Order o, out String message)
        {
            if (o == null)
            {
                message = "No order?";
                return false;
            }

            if (String.IsNullOrEmpty(o.Name) || (o.Room==null))
            {
                message = "No data!";
                return false;
            }

            message = "";
            return true;
        }
    }
}
