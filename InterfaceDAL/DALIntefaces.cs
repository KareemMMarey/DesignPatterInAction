using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDAL
{
    // Design Pattern : Generic Repositry Pattern
    public interface IDAL<AnyType>
    {
        void Add(AnyType obj); // In memory
        void Update(AnyType obj); // In memory
        List<AnyType> Search();
        AnyType GetById();
        void Save(); // Physical Commit
    }
}
