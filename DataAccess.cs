using System.Data.SqlClient;
using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Xml.Linq;

namespace BudgetTracker.Pages
{
    public class DataAccess
    {

        public List<Debit> GetDebits()
        {
            using IDbConnection connection = new SqlConnection(Helper.CnnVal("DebitDB"));
            {
                var sql = "SELECT * FROM Debits";
                var result = connection.Query<Debit>(sql);
                return (List<Debit>)result;
            }
        }

        public List<Debit> FetchDebit(int record)
        {
            using IDbConnection connection = new SqlConnection(Helper.CnnVal("DebitDB"));
            {
                var parameter = new { target = record };
                var sql = "SELECT * from Debits where ID = @target";
                var result = connection.Query<Debit>(sql, parameter);
                return (List<Debit>)result;
            }
        }

        public void UpdateDebit(int id, string name, double cost, string date)

        {
            using IDbConnection connection = new SqlConnection(Helper.CnnVal("DebitDB"));
            {
                var parameters = new { ID = id, NAME = name, COST = cost, DATE = date };
                var sql = "UPDATE Debits SET Name = @NAME, Cost = @COST, PaymentDate = @DATE where ID = @ID";
                _ = connection.Query<Debit>(sql, parameters);

            }
        }
        public void DeleteDebit(int id)

        {
            using IDbConnection connection = new SqlConnection(Helper.CnnVal("DebitDB"));
            {
                var parameters = new { ID = id };
                var sql = "DELETE Debits WHERE ID = @ID";
                _ = connection.Query<Debit>(sql, parameters);

            }
        }

        public void AddDebit(string name, double cost, string date)

        {
            
                using IDbConnection connection = new SqlConnection(Helper.CnnVal("DebitDB"));
                {
                    var parameters = new { NAME = name, COST = cost, DATE = date }; ;
                    var sql = "INSERT INTO Debits (Name, Cost, PaymentDate) VALUES (@NAME,@COST,@DATE)";
                    _ = connection.Query<Debit>(sql, parameters);
                }
            

        }
    }

}

        
