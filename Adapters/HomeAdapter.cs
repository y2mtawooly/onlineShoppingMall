using System;
using System.Data.SqlClient;
using System.Data;
using OnlineShoppingMall.Adapters.Core;
using OnlineShoppingMall.Models.UserInformation;
using OnlineShoppingMall.Models.Cart;

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

        public DataTable InsertCart(Cart cart)
        {
            DataTable data = new DataTable();
            try
            {
                using (var command = Connection.CreateCommand())
                {

                    int userId = cart.UserAccountId;
                    int GoodsId = cart.GoodsId;
                    int tax = cart.ConsumptionTaxId;
                    DateTime addDate = cart.AddDate;

                    cart.AddBy = userId.ToString();
                    string addBy = cart.AddBy;

                    DateTime udatedDate = cart.UpdateDate;

                    cart.UpdateBy = userId.ToString();
                    string updateBy = cart.UpdateBy;



                    Connection.Open();
                    var createQuary = command.CommandText;
                    // SQLの設定
                    command.CommandText = "INSERT INTO [dbo].[Cart] ([UserAccountId], [GoodsId], [SaleId], [ConsumptionTaxId], [AddDate], [AddBy], [UpdateDate], [UpdateBy]) VALUES (@param1, @param2, NULL, @param3, @param4, (SELECT [UserId] FROM [dbo].[Account] WHERE [Id] = @param5), @param6, (SELECT [UserId] FROM [dbo].[Account] WHERE [Id] = @param7))";

                    // SQLの実行
                    command.Parameters.AddWithValue("@param1", userId);
                    command.Parameters.AddWithValue("@param2", GoodsId);
                    command.Parameters.AddWithValue("@param3", tax);
                    command.Parameters.AddWithValue("@param4", addDate);
                    command.Parameters.AddWithValue("@param5", addBy);
                    command.Parameters.AddWithValue("@param6", udatedDate);
                    command.Parameters.AddWithValue("@param7", updateBy);

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

        public DataTable Cart(int userId)
        {
            DataTable data = new DataTable();
            try
            {
                using (var command = Connection.CreateCommand())
                {
                    Cart cart = new Cart();

                    cart.UserAccountId = userId;

                    Connection.Open();
                    var createQuary = command.CommandText;
                    // SQLの設定
                    command.CommandText = "SELECT c.Id, c.GoodsId, g.Name, g.Price, g.Stock, t.TaxRate FROM [dbo].[Cart] AS c INNER JOIN [dbo].[Goods] g ON c.GoodsId = g.Id INNER JOIN [dbo].[Tax] t ON c.ConsumptionTaxId = t.Id WHERE c.UserAccountId = @param1 AND c.ConsumptionTaxId = 0;";

                    // SQLの実行
                    command.Parameters.AddWithValue("@param1", userId);

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
                // データベースの接続終了
                Connection.Close();
            }
            return data;
        }

        public DataTable AllDelete()
        {
            DataTable data = new DataTable();
            try
            {
                using (var command = Connection.CreateCommand())
                {
                    Connection.Open();
                    command.CommandText = "DELETE FROM Cart";

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

        public DataTable Delete(Cart cart)
        {
            DataTable data = new DataTable();
            try
            {
                var deleteId = cart.Id;
                using (var command = Connection.CreateCommand())
                {
                    Connection.Open();
                    command.CommandText = "DELETE FROM Cart WHERE [Id] = @param1;";

                    command.Parameters.AddWithValue("@param1", deleteId);

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
    }
}