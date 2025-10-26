using Microsoft.Data.SqlClient;
using RoomMates.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace RoomMates.DAL
{
    public class DataAccess
    {
        private readonly string _connectionString;

        public DataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }


        public List<ViewBill> GetUserBills(int userId, int actionType,int? month)
        {
            List<ViewBill> bills = new List<ViewBill>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllDetails", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@ActionType", actionType);
                    cmd.Parameters.AddWithValue("@Month", month);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var bill = new ViewBill
                            {
                                Month = reader["MonthName"]?.ToString() ?? "",
                                Name = reader["Name"]?.ToString() ?? "",
                                PayAmount = reader["PayAmount"] != DBNull.Value ? Convert.ToDecimal(reader["PayAmount"]) : 0,
                                UserPurchaseAmount = reader["UserPurchaseAmount"] != DBNull.Value ? Convert.ToDecimal(reader["UserPurchaseAmount"]) : 0,
                                PayTotalAmount = reader["PayTotalAmount"] != DBNull.Value ? Convert.ToDecimal(reader["PayTotalAmount"]) : 0,
                                AdvancePending = reader["AdvancePending"] != DBNull.Value ? Convert.ToDecimal(reader["AdvancePending"]) : 0,
                                TotalAmountRentAdvance = reader["TotalAmountRentAdvance"] != DBNull.Value ? Convert.ToDecimal(reader["TotalAmountRentAdvance"]) : 0
                            };
                            bills.Add(bill);
                        }
                    }
                }
            }

            return bills;
        }
        public List<User> GetUserID()
        {
            List<User> bills = new List<User>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllDetails", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", 0);
                    cmd.Parameters.AddWithValue("@ActionType", 1);
                    cmd.Parameters.AddWithValue("@Month", 0);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var bill = new User
                            {
                                UserID = reader["UserID"] != DBNull.Value ? Convert.ToInt32(reader["UserID"]) : 0,
                                Name = reader["Name"]?.ToString() ?? ""
                            };

                            bills.Add(bill);

                        }
                    }
                }
            }

            return bills;
        }

    }
}
