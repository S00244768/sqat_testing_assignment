using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Quality_and_Testing_Assignment
{
    public interface DiscountService
    {
        double GetDiscount();
    }
    public class ImplementationClass : DiscountService
    {
        double DiscountService.GetDiscount()
        {
            throw new NotImplementedException();
        }

        static void Main()
        {
            DiscountService obj = new ImplementationClass();

            obj.GetDiscount();
        }
    }
}
