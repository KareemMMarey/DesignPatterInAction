using AdoDotNETDAL;
using CustomerInterfaces;
using InterfaceDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Resolution;

namespace FactoryDAL
{
    public class FactoryDAL<AnyType>
    {
        private static IUnityContainer objectsOfTheProject = null;
        
        // Design Pattern:Lazy Loading
        public static AnyType Create(string type)
        {
            if (objectsOfTheProject == null)
            {
                objectsOfTheProject = new UnityContainer();
                
                objectsOfTheProject.RegisterType<IDAL<ICustomerInterface>, CustomerDAL>("ADODAL");
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
