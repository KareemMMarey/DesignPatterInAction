using CustomerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class CustomerBase: ICustomerInterface
    {
        private IValidation<ICustomerInterface> validation = null;
        public CustomerBase(IValidation<ICustomerInterface> obj)
        {
            validation = obj;
        }
        public CustomerBase()
        {
            CustomerName = "";
            PhoneNumber = "";
            BillAmount = 0;
            BillDate = DateTime.Now;
            Address = "";
        }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal BillAmount { get; set; }
        public DateTime BillDate { get; set; }
        public string Address { get; set; }

        // for validation purposes i will create a virtual method to validate 
        // which can be overwritten by each class
        public virtual void Validate() {
            validation.Validate(this);
        }
    }
    // Concern for validation, for customer all fields are compelsory
    // Design Pattern: IoC Pattern
    public class Customer:CustomerBase
    {
        public Customer(IValidation<ICustomerInterface> obj):base(obj)
        {

        }
        //public override void Validate()
        //{
        //    if (CustomerName.Length ==0) {
        //        throw new Exception("Customer name is required");
        //    }
        //    if (PhoneNumber.Length ==0)
        //    {
        //        throw new Exception("Phone number is required");
        //    }
        //    if (BillAmount ==0)
        //    {
        //        throw new Exception("Bill amount is required");
        //    }
        //    if (BillDate>=DateTime.Now)
        //    {
        //        throw new Exception("Bill date is required");
        //    }
        //    if (Address.Length < 1)
        //    {
        //        throw new Exception("Address is required");
        //    }
        //}
    }
    // Concern for validation, for customer only custmer name and phone are compelsory
    public class Lead : CustomerBase
    {
        public Lead(IValidation<ICustomerInterface> obj) : base(obj)
        {

        }
        //public override void Validate()
        //{
        //    if (CustomerName.Length ==0) {
        //        throw new Exception("Customer name is required");
        //    }
        //    if (PhoneNumber.Length ==0)
        //    {
        //        throw new Exception("Phone number is required");
        //    }
        //}
    }
}
