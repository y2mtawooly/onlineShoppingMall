using System;
using System.Data.SqlClient;
using System.Data;
using OnlineShoppingMall.Adapters.Core;
using OnlineShoppingMall.Models.Good;

namespace OnlineShoppingMall.Adapters
{
    public class GoodsAdapter : OnlineShoppingMallAdapter
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
        public DataTable InsertGoodsData(Goods goods)
        {
            DataTable data = new DataTable();
            try
            {
                using (var command = Connection.CreateCommand())
                {


                    Connection.Open();
                    var createQuary = command.CommandText;
                    // SQLの設定
                    command.CommandText = "INSERT INTO [dbo].[Cart] ([UserAccountId], [GoodsId], [SaleId], [ConsumptionTaxId], [AddDate], [AddBy], [UpdateDate], [UpdateBy]) VALUES (@param1, @param2, NULL, @param3, @param4, (SELECT [UserId] FROM [dbo].[Account] WHERE [Id] = @param5), @param6, (SELECT [UserId] FROM [dbo].[Account] WHERE [Id] = @param7))";

                    // SQLの実行
                    command.Parameters.AddWithValue("@param1", "userId");

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