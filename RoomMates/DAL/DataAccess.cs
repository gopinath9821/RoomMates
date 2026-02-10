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



        public DataTable GetUserBills_DT(int userId, int actionType, int? month)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllDetails", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@ActionType", actionType);
                    cmd.Parameters.AddWithValue("@Month", month);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }

            return dt;
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

        public List<TotalBill> GetUserBilldata(int userId, int actionType, int? month)
        {
            List<TotalBill> bills = new List<TotalBill>();

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
                            var bill = new TotalBill
                            {
                                RoomRent = reader["RoomRent"] != DBNull.Value ? Convert.ToDecimal(reader["RoomRent"]) : 0,
                                EBBill = reader["EBBill"] != DBNull.Value ? Convert.ToDecimal(reader["EBBill"]) : 0,
                                WaterBill = reader["WaterBill"] != DBNull.Value ? Convert.ToDecimal(reader["WaterBill"]) : 0,
                                AkkaBill = reader["AkkaBill"] != DBNull.Value ? Convert.ToDecimal(reader["AkkaBill"]) : 0,
                                GasBill = reader["GasBill"] != DBNull.Value ? Convert.ToDecimal(reader["GasBill"]) : 0,
                                WifiNetwork = reader["WifiNetwork"] != DBNull.Value ? Convert.ToDecimal(reader["WifiNetwork"]) : 0,
                                TotalUserAmount = reader["TotalUserAmount"] != DBNull.Value ? Convert.ToDecimal(reader["TotalUserAmount"]) : 0,
                                TotalAmount = reader["TotalAmount"] != DBNull.Value ? Convert.ToDecimal(reader["TotalAmount"]) : 0,
                                SathishShopBill = reader["SathishShopBill"] != DBNull.Value ? Convert.ToDecimal(reader["SathishShopBill"]) : 0
                            };
                            bills.Add(bill);
                        }
                    }
                }
            }

            return bills;
        }

        public List<UserBill> GetUserBillsDetails(int userId, int actionType, int? month)
        {
            List<UserBill> userBills = new List<UserBill>();

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
                            var bill = new UserBill
                            {
                                Name = reader["Name"]?.ToString() ?? "",
                                ProductName = reader["ProductName"]?.ToString() ?? "",
                                Price = reader["Price"] != DBNull.Value ? Convert.ToDecimal(reader["Price"]) : 0
                            };
                            userBills.Add(bill);
                        }
                    }
                }
            }

            return userBills;
        }

    }
}
