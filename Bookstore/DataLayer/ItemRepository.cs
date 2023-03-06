using Bookstore.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.DataLayer
{
    public class ItemRepository
    {
        public List<Item> GetAllItems()
        {
            List<Item> items = new List<Item>();
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT* FROM Items";
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Item i = new Item();
                    i.id = sqlDataReader.GetInt32(0);
                    i.title = sqlDataReader.GetString(1);
                    i.price = sqlDataReader.GetDouble(2);
                    i.quantity = sqlDataReader.GetInt32(3);
                    i.description = sqlDataReader.GetString(4);
                    i.insert_date = sqlDataReader.GetDateTime(5);
                    i.category = sqlDataReader.GetString(6);
                    items.Add(i);
                }
            }
            return items;
        }

        public int InsertItem(Item i)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format("INSERT INTO Items VALUES('{0}','{1}','{2}','{3}','{4}','{5}')",
                    i.title, i.price, i.quantity, i.description, i.insert_date, i.category);
                sqlConnection.Open();
                return sqlCommand.ExecuteNonQuery();
            }
        }

        public int UpdateItem(Item i)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format("UPDATE Items SET title='{0}', price='{1}', quantity='{2}', description='{3}', insertDate='{4}', category='{5}' WHERE Id = '{6}'",
                    i.title, i.price, i.quantity, i.description, i.insert_date, i.category, i.id);
                sqlConnection.Open();
                return sqlCommand.ExecuteNonQuery();
            }
        }

        public int DeleteItem(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connString))
            {
                sqlConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = sqlConnection;
                command.CommandText = "DELETE FROM Items WHERE Id = " + id;

                return command.ExecuteNonQuery();
            }
        }

        public List<Item> SearchItems(string s)
        {
            List<Item> items = new List<Item>();
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Items WHERE title LIKE'" + "%" + s + "%" +
                "' OR category LIKE'" + "%" + s + "%" + "' OR description LIKE'" + "%" + s + "%" + "' ";
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Item i = new Item();
                    i.id = sqlDataReader.GetInt32(0);
                    i.title = sqlDataReader.GetString(1);
                    i.price = sqlDataReader.GetDouble(2);
                    i.quantity = sqlDataReader.GetInt32(3);
                    i.description = sqlDataReader.GetString(4);
                    i.insert_date = sqlDataReader.GetDateTime(5);
                    i.category = sqlDataReader.GetString(6);
                    items.Add(i);
                }
            }
            return items;
        }
    }
}
