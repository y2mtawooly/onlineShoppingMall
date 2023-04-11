using System;
using System.Data.SqlClient;
using System.Data;
using OnlineShoppingMall.Adapters.Core;
using OnlineShoppingMall.Models.UserInformation;

namespace OnlineShoppingMall.Adapters
{
    public class HomeAdapter : OnlineShoppingMallAdapter
    {
        public DataTable GetDataByAll()
        {
            DataTable data = new DataTable();
            try
            {
                using (var command = Connection.CreateCommand())
                {
                    Connection.Open();
                    command.CommandText = "SELECT * FROM Goods";

                    var adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);
                }
            }
            catch (Exception exception)
            {
                throw;
            }
            finally
            {
                // データベースの接続終了
                Connection.Close();
            }
            return data;
        }


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

        public DataTable DetailGoodsInfo(string goodsId)
        {
            DataTable data = new DataTable();
            try
            {
                using (var command = Connection.CreateCommand())
                {
                    Connection.Open();
                    var createQuary = command.CommandText;
                    // SQLの設定
                    command.CommandText = "SELECT * FROM Goods WHERE Id = @param1;";

                    // SQLの実行
                    command.Parameters.AddWithValue("@param1", goodsId);

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

        public DataTable Cart(string goodsId)
        {
            DataTable data = new DataTable();
            try
            {
                using (var command = Connection.CreateCommand())
                {
                    Connection.Open();
                    var createQuary = command.CommandText;
                    // SQLの設定
                    command.CommandText = "SELECT * FROM Goods WHERE Id = @param1;";

                    // SQLの実行
                    command.Parameters.AddWithValue("@param1", goodsId);

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