namespace StoreDL;

using Microsoft.Data.SqlClient;
using System.Data;
public class DBREPO
{
    private string _connectionString;

    public DBREPO()
    {
        _connectionString = File.ReadAllText("connectionString.txt");
    }

    public List<Customer> AllCustomers()
    {
        List<Customer> allCustomers = new List<Customer>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string queryTxt = "SELECT*FROM Customer";
            
            using(SqlCommand cmd = new SqlCommand(queryTxt, connection))
            {
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        Customer custo = new Customer();
                        custo.Id = reader.GetInt32(0);
                        custo.UserName = reader.GetString(1);
                        custo.Password = reader.GetString(2);
                        custo.Email = reader.GetString(3);
                        allCustomers.Add(custo);
                    }
                }
            } 
            connection.Close();
        }
        return allCustomers;
    }

    public void AddCustomer(Customer customerToAdd)
    {
        DataSet customerSet = new DataSet();
        string selectCmd = "SELECT*FROM Customer";
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            using(SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd, connection))
            {
                
                dataAdapter.Fill(customerSet, "Customer");

                DataTable customerTable = customerSet.Tables["Customer"];
                DataRow newRow = customerTable.NewRow();
                    newRow["Username"]= customerToAdd.UserName;
                    newRow["Password"]= customerToAdd.Password;
                    newRow["Email"]= customerToAdd.Email;
                customerTable.Rows.Add(newRow);
                
                string insertCmd = $"INSERT INTO Customer (Username, Password, Email) VALUES ('{customerToAdd.UserName}','{customerToAdd.Password}','{customerToAdd.Email}')";
                
                dataAdapter.InsertCommand= new SqlCommand(insertCmd, connection);
                
                dataAdapter.Update(customerTable);
            }
        }
    }
    
}
