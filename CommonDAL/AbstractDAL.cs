using InterfaceDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDAL
{
    public abstract class AbstractDAL<AnyType> : IDAL<AnyType>
    {
        protected string _ConnectionString = "";
        public AbstractDAL(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }
        protected List<AnyType> AnyTypes = new List<AnyType>();
        public virtual void Add(AnyType obj)
        {
            AnyTypes.Add(obj);
        }

        public virtual AnyType GetById()
        {
            throw new NotImplementedException();
        }

        public virtual void Save()
        {
            throw new NotImplementedException();
        }

        public virtual List<AnyType> Search()
        {
            throw new NotImplementedException();
        }

        public void Update(AnyType obj)
        {
            throw new NotImplementedException();
        }
    }
}
