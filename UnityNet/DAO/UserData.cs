using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SocketGameProtocol;

namespace SocketMultiplayerGameServer.DAO
{
    class UserData
    {
        private MySqlConnection mysqlCon;
        private string MysqlConStr = "Database=game;Data Source=localhost;User Id=root;Password=65715848;Charset=utf8;port=3306";
        public UserData()
        {
            ConnectMysql();
        }
        private void ConnectMysql()
        {
            try
            {
                mysqlCon = new MySqlConnection(MysqlConStr);
                mysqlCon.Open();
                Console.WriteLine("连接数据库成功");
            }
            catch(Exception e)
            {
                Console.WriteLine("连接数据库失败");
            }
        }
        public bool Logon(MainPack pack)
        {
            Console.WriteLine("AAA");
            string username = pack.Loginpack.Username;
            string password = pack.Loginpack.Password;
            Console.WriteLine(username);

            string sql = "select * from user where username = @username";
            MySqlCommand comd = new MySqlCommand();
            comd.Connection = mysqlCon;
            comd.CommandText = sql;
            comd.Parameters.AddWithValue("@username", username);
            comd.Prepare();
            MySqlDataReader reader = comd.ExecuteReader();     //执行SQL，返回一个“流”
            if(reader.HasRows)
            {
                Console.WriteLine("该用户名已存在");
                return false;
            }
            //while (reader.read())
            //{

            //}

            reader.Close();
            sql= "insert into user (username, password) VALUES (@username, @password)";
            comd = new MySqlCommand();
            comd.Connection = mysqlCon;
            comd.CommandText = sql;
            comd.Parameters.Clear();
            comd.Parameters.AddWithValue("@username",username);
            comd.Parameters.AddWithValue("@password", password);
            comd.Prepare();
 
            try
            {
                comd.ExecuteNonQuery();
                Console.WriteLine("新用户{0}已注册",username);
    
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);

            }
            return true;
        }
    }
}
