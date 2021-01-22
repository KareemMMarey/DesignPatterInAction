using CustomerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAlgorithms
{
    public class AllCustomerValidation : IValidation<ICustomerInterface>
    {
        public void Validate(ICustomerInterface obj)
        {
            if (obj.CustomerName.Length == 0)
            {
                throw new Exception("Customer name is required");
            }
            if (obj.PhoneNumber.Length == 0)
            {
                throw new Exception("Phone number is required");
            }
            if (obj.BillAmount == 0)
            {
                throw new Exception("Bill amount is required");
            }
            if (obj.BillDate >= DateTime.Now)
            {
                throw new Exception("Bill date is required");
            }
            if (obj.Address.Length < 1)
            {
                throw new Exception("Address is required");
            }
        }
    }
    public class LeadCustomerValidation : IValidation<ICustomerInterface>
    {
        public void Validate(ICustomerInterface obj)
        {
            if (obj.CustomerName.Length == 0)
            {
                throw new Exception("Customer name is required");
            }
            if (obj.PhoneNumber.Length == 0)
            {
                throw new Exception("Phone number is required");
            }
        }
    }
    public class VendorCustomerValidation
    {
    }
}
