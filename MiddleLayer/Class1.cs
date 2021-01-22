using CustomerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class CustomerBase : ICustomerInterface
    {
        private static IValidation<ICustomerInterface> validation = null;
        public CustomerBase(IValidation<ICustomerInterface> obj)
        {
            validation = obj;
        }
        public CustomerBase()
        {
            CustomerName = "";
            PhoneNumber = "";
            Address = "";
            BillAmount =0;
            BillDate = DateTime.Now ;
        }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal BillAmount { get; set ; }
        public DateTime BillDate { get; set; }
        public string Address { get ; set ; }

        public void Validate()
        {
            validation.Validate(this);
        }
    }
    public class Customer : CustomerBase {
        public Customer(IValidation<ICustomerInterface> obj) :base(obj)
        {

        }
    }
    public class Lead : CustomerBase {
        public Lead(IValidation<ICustomerInterface> obj) : base(obj)
        {

        }
    }

}
