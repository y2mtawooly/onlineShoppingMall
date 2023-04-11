using System;
using System.Data.SqlClient;
using System.Data;
using OnlineShoppingMall.Adapters.Core;
using OnlineShoppingMall.Models.UserInformation;
using OnlineShoppingMall.Models.User;

namespace OnlineShoppingMall.Adapters
{
    public class LoginAdapter : OnlineShoppingMallAdapter
    {

        public DataTable GetDataByAll()
        {
            DataTable data = new DataTable();
            try
            {
                using (var command = Connection.CreateCommand())
                {
                    Connection.Open();
                    command.CommandText = "SELECT * FROM Account";

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

        public DataTable AddUserAccount(UserAccount userAccount)
        {
            DataTable data = new DataTable();
            try
            {
                using (var command = Connection.CreateCommand())
                {

                    string userId = userAccount.UserId;
                    string password = userAccount.Password;
                    DateTime addDate = userAccount.AddDate;

                    userAccount.AddBy = userId;
                    string addBy = userAccount.AddBy;

                    DateTime udatedDate = userAccount.UpdateDate;

                    userAccount.UpdateBy = userId;
                    string updateBy = userAccount.UpdateBy;


                    Connection.Open();
                    var createQuary = command.CommandText;
                    // SQLの設定
                    command.CommandText = "INSERT INTO Account ([UserId], [Password], [AddDate], [AddBy], [UpdateDate], [UpdateBy]) VALUES (@param1, @param2, @param3,@param4, @param5, @param6);";

                    // SQLの実行
                    command.Parameters.AddWithValue("@param1", userId);
                    command.Parameters.AddWithValue("@param2", password);
                    command.Parameters.AddWithValue("@param3", addDate);
                    command.Parameters.AddWithValue("@param4", addBy);
                    command.Parameters.AddWithValue("@param5", udatedDate);
                    command.Parameters.AddWithValue("@param6", updateBy);

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

        public DataTable AddUserAccountInfo(UserInfo userInfo)
        {
            DataTable data = new DataTable();
            try
            {
                using (var command = Connection.CreateCommand())
                {

                    string userId = userInfo.Id;
                    string name = userInfo.Name;
                    DateTime birth = userInfo.Birth;
                    string gender = userInfo.Gender;
                    string email = userInfo.Email;
                    string phoneNumber = userInfo.PhoneNumber;
                    string postNumber = userInfo.PostNumber;
                    string address = userInfo.Address;
                    DateTime addDate = userInfo.AddDate;
                    DateTime udatedDate = userInfo.UpdateDate;

                    


                    Connection.Open();
                    var createQuary = command.CommandText;
                    // SQLの設定
                    command.CommandText = "INSERT INTO UserInfo ([Id], [Name], [Birth], [Gender], [Email], [PhoneNumber], [PostNumber], [Address], [AddDate],[UpdateDate]) VALUES (@param1, @param2, @param3, @param4, @param5, @param6, @param7, @param8, @param9, @param10);";

                    // SQLの実行
                    command.Parameters.AddWithValue("@param1", userId);
                    command.Parameters.AddWithValue("@param2", name);
                    command.Parameters.AddWithValue("@param3", birth);
                    command.Parameters.AddWithValue("@param4", gender);
                    command.Parameters.AddWithValue("@param5", email);
                    command.Parameters.AddWithValue("@param6", phoneNumber);
                    command.Parameters.AddWithValue("@param7", postNumber);
                    command.Parameters.AddWithValue("@param8", address);
                    command.Parameters.AddWithValue("@param9", addDate);
                    command.Parameters.AddWithValue("@param10", udatedDate);

                    //command.ExecuteNonQuery();

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

        public DataTable FindId(UserInfo userInfo)
        {
            DataTable data = new DataTable();
            try
            {
                using (var command = Connection.CreateCommand())
                {
                    string name = userInfo.Name;
                    DateTime birth = userInfo.Birth;

                    Connection.Open();
                    var createQuary = command.CommandText;
                    // SQLの設定
                    command.CommandText = "SELECT * FROM UserInfo WHERE [Name] = @param1 AND [Birth] = @param2 ;";
                    
                    // SQLの実行
                    command.Parameters.AddWithValue("@param1", name);
                    command.Parameters.AddWithValue("@param2", birth);

                    //command.ExecuteNonQuery();

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



        public DataTable FindPassword(string id)
        {
            DataTable data = new DataTable();
            try
            {
                using (var command = Connection.CreateCommand())
                {
                    string userId = id;

                    Connection.Open();
                    var createQuary = command.CommandText;
                    // SQLの設定
                    command.CommandText = "SELECT * FROM Account WHERE [UserId] = @param1;";

                    // SQLの実行
                    command.Parameters.AddWithValue("@param1", userId);

                    //command.ExecuteNonQuery();

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