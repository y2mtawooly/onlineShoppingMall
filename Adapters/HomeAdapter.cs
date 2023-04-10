using System;
using System.Data.SqlClient;
using System.Data;
using OnlineShoppingMall.Adapters.Core;
using OnlineShoppingMall.Models.UserInformation;
using OnlineShoppingMall.Models.User;

namespace OnlineShoppingMall.Adapters
{
    public class HomeAdapter : OnlineShoppingMallAdapter
    {
        public DataTable Login(UserAccount userAccount)
        {
            DataTable data = new DataTable();
            try
            {
                using (var command = Connection.CreateCommand())
                {

                    string userId = userAccount.UserId;
                    string password = userAccount.Password;


                    Connection.Open();
                    var createQuary = command.CommandText;
                    // SQLの設定
                    command.CommandText = "SELECT * FROM Account WHERE UserId = @param1 AND Password = @param2;";

                    // SQLの実行
                    command.Parameters.AddWithValue("@param1", userId);
                    command.Parameters.AddWithValue("@param2", password);

                    //command.ExecuteNonQuery();

                    var adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);
                }
            }
            catch (Exception exception)
            {
            }
            finally
            {
                // データベースの接続終了
                Connection.Close();
            }
            return data;
        }

    }
}