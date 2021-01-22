using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInterfaces
{
    public interface ICustomerInterface
    {
         string CustomerName { get; set; }
         string PhoneNumber { get; set; }
         decimal BillAmount { get; set; }
         DateTime BillDate { get; set; }
         string Address { get; set; }
         void Validate();

    }

    // Design Pattern: Strategy Pattern
    // Behavioural Pattern : Helps you to choose Stratgy dynamicaly
    public interface IValidation<AnyType> {
        void Validate(AnyType obj);
    }
}
