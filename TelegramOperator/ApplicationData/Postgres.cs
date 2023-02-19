using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;
using Npgsql;

namespace TelegramOperator
{

    internal class Postgres
    {

        public static NpgsqlConnection GetConnection()
        {
            string password = "";
            string database = "telegram";
            return new NpgsqlConnection($@"Server=localhost;Port=5432;User Id=postgres;Password={password};Database={database}");
        }

        public static void RecordConection(string api_hash, int api_id, string phone, string username, string member, string photo)
        {
            using (NpgsqlConnection connect = GetConnection())
            {
                connect.Open();
                using (var command = new NpgsqlCommand("INSERT INTO public.account " +
                "(api_hash, api_id, phone,username, member, photo) " +
                "VALUES (@api_hash, @api_id, @phone, @username, @member, @photo)", connect))
                {
                    command.Parameters.AddWithValue("api_hash", api_hash);
                    command.Parameters.AddWithValue("api_id", api_id);
                    command.Parameters.AddWithValue("phone", phone);
                    command.Parameters.AddWithValue("username", username);
                    command.Parameters.AddWithValue("member", member);
                    command.Parameters.AddWithValue("photo", photo);
                    command.ExecuteNonQuery();
                }


            }
        }

        public static void DeleteData(int iid)
        {
            using (NpgsqlConnection connect = GetConnection())
            {
                connect.Open();
                using (var command = new NpgsqlCommand("DELETE FROM public.account WHERE id = @n", connect))
                {
                    command.Parameters.AddWithValue("n", iid);
                    command.ExecuteNonQuery();
                }

            }

        }


        public static List<Telegram> ReadingData()
        {
            List<Telegram> members = new List<Telegram>();           
            using (NpgsqlConnection connect = GetConnection())
            {
                connect.Open();
                using (var command = new NpgsqlCommand("SELECT * FROM account", connect))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string photo = reader.GetString(6);
                        members.Add(new Telegram { id = reader.GetInt32(0).ToString(), member = reader.GetString(4),
                        username = reader.GetString(5), phone = reader.GetString(3), photo = BitmapFromBase64(photo)});
                    }
                    reader.Close();
                    return members;


                }

            }

        }

        public static BitmapSource BitmapFromBase64(string b64string)
        {
            var bytes = Convert.FromBase64String(b64string);

            using (var stream = new MemoryStream(bytes))
            {
                return BitmapFrame.Create(stream,
                    BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            }
        }


        public static List<string> ReadingDataString(string _id)
        {
            List<string> member = new List<string>();

            using (NpgsqlConnection connect = GetConnection())
            {
                connect.Open();
                using (var command = new NpgsqlCommand($"SELECT * FROM account WHERE id = {_id}", connect))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        member.Add(reader.GetInt32(0).ToString());
                        member.Add(reader.GetString(1));
                        member.Add(reader.GetInt32(2).ToString());
                        member.Add(reader.GetString(3));
                    }
                    reader.Close();
                    return member;

                }

            }

        }


    }
}
