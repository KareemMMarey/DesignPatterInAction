using CustomerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Injection;
using ValidationAlgorithms;
using MiddleLayer;
using Unity.Resolution;

namespace FactoryCustomer
{
    // This class will resposible about creating our classes
    //Design Pattern: Simple Factory Pattern
    // To Make the factory return any type we have to make it generic
    public static class Factory<AnyType>
    {
        private static IUnityContainer objectsOfTheProject = null;
        //static Factory()
        //{
        //    // there is a proplem here that the classes are loaded if you want it or not
        //    custs.Add("Customer", new Customer());
        //    custs.Add("Lead", new Lead());
        //}
        // Design Pattern:Lazy Loading
        public static AnyType Create(string type) {
            if (objectsOfTheProject == null) {
                objectsOfTheProject = new UnityContainer();
                objectsOfTheProject.RegisterType<ICustomerInterface, Customer>
                    ("Customer", new InjectionConstructor(new AllCustomerValidation()));
                objectsOfTheProject.RegisterType<ICustomerInterface, Lead>
                    ("Lead", new InjectionConstructor(new LeadCustomerValidation()));
            }
            // Design Pattern: RIP replace if with polymorphesim
            // if(CustomerType=="Customer" ){return new Customer();}
            //else {return new Lead();}
            return objectsOfTheProject.Resolve<AnyType>(type, new Unity.Resolution.ResolverOverride[] {
            new ParameterOverride("ConnectionString",@"Data Source=WINDEV\SQLDEV;Initial Catalog=Sample;
             Integrated Security=true")
            }); ;
        }
    }
}
