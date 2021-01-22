using CommonDAL;
using CustomerInterfaces;
using FactoryCustomer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotNETDAL
{
    public abstract class TemplateADO<AnyType>: AbstractDAL<AnyType>
    {
        protected SqlConnection objCon = null;
        protected SqlCommand objCommand = null;
        public TemplateADO(string ConnectionString) : base(ConnectionString)
        {
        }

        private void Open() {
            objCon = new SqlConnection(_ConnectionString);
            objCon.Open();
            objCommand = new SqlCommand();
            objCommand.Connection = objCon;
        }
        private void Close() {
            if (objCon.State == System.Data.ConnectionState.Open) {
                objCon.Close();
            }
        }

        // Design Pattern:- Template Pattern
        // You have a template that has a very fixed sequance of operationas
        void Excute(AnyType obj) { // Fixed Squance
            Open();
            ExcuteCommand(obj );
            Close();

        }
        List<AnyType> Excute()
        { // Fixed Squance
            Open();
            List<AnyType> Listobj  = ExcuteCommand();
            Close();
            return Listobj;

        }
        // Child Classes have the librety to ovveride this method
        protected abstract void ExcuteCommand(AnyType obj);
        protected abstract List<AnyType> ExcuteCommand();

        //public override void Add(AnyType obj)
        //{
        //    base.Add(obj);
        //}

        //public override AnyType GetById()
        //{
        //    return base.GetById();
        //}

        public override void Save()
        {
            foreach (var item in base.AnyTypes)
            {
                Excute(item);
            }
        }

        public override List<AnyType> Search()
        {
            return Excute();
        }
    }
    public class CustomerDAL : TemplateADO<ICustomerInterface>
    {
        public CustomerDAL(string ConnectionString) : base(ConnectionString)
        {
        }

        protected override void ExcuteCommand(ICustomerInterface obj)
        {
            objCommand.CommandText = @"INSERT INTO [dbo].[Customer]
           ([CustomerName]
           ,[CustomerTyspe]
           ,[BillAmount]
           ,[BillDate]
           ,[PhoneNumber]
           ,[Address])
            VALUES
           ('"+obj.CustomerName+"',1,"+obj.BillAmount+",'"+ obj.BillDate+ "','"+obj.PhoneNumber+"','"+obj.Address+"')";

            objCommand.ExecuteNonQuery();
        }

        protected override List<ICustomerInterface> ExcuteCommand()
        {
            objCommand.CommandText = @"Select * from [dbo].[Customer]";
            SqlDataReader dr = null;
            dr = objCommand.ExecuteReader();
            List<ICustomerInterface> lstobj = new List<ICustomerInterface>();
            while (dr.Read())
            {
                ICustomerInterface icust = Factory<ICustomerInterface>.Create("Customer");
                icust.CustomerName = dr["CustomerName"].ToString();
                icust.BillDate = Convert.ToDateTime(dr["BillDate"]);
                icust.BillAmount = Convert.ToDecimal(dr["BillAmount"]);
                icust.PhoneNumber = dr["PhoneNumber"].ToString();
                icust.Address = dr["Address"].ToString();
                //icust. = dr["CustomerName"].ToString();
                lstobj.Add(icust);
            }
            return lstobj;
        }
    }
}
