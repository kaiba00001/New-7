using DoctorAp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DoctorAp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string _connectionString;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _connectionString = "Server=tcp:digigroup30.database.windows.net,1433;Initial Catalog=49;Persist Security Info=False;User ID=sqladmin;Password=Blackbird127;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }

        // Action method for the default "Index" view
        public IActionResult Index()
        {
            return View();
        }

        // Action method for the "Privacy" view
        public IActionResult Privacy()
        {
            return View();
        }

        // Action method for the "Bill" view
        public IActionResult Bill()
        {
            List<ItemsLead> itemsLead = FetchItemsLead();
            return View(itemsLead);
        }

        // Action method for the "Stocks" view
        public IActionResult Stocks()
        {
            List<StockTrackerLead> stocks = FetchStockTrackerLead();
            return View(stocks);
        }

        // Action method for the "Links" view
        public IActionResult Links()
        {
            List<Contacts> contacts = FetchContacts();
            return View(contacts);
        }

        private List<Contacts> FetchContacts()
        {
            List<Contacts> contacts = new List<Contacts>();

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand("SELECT TOP (1000) * FROM [dbo].[AspNetUsers]", con))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            contacts.Add(new Contacts()
                            {
                                Id = reader["Id"].ToString(),
                                Firstname = reader["FirstName"].ToString(),
                                Lastname = reader["LastName"].ToString(),
                                Email = reader["Email"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to fetch contacts");
                // Handle or log the exception as per your requirement
            }

            return contacts;
        }

        private List<StockTrackerLead> FetchStockTrackerLead()
        {
            List<StockTrackerLead> stocktrackerlead = new List<StockTrackerLead>();

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand("SELECT TOP (1000) * FROM [dbo].[StockTrackerLead]", con))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            stocktrackerlead.Add(new StockTrackerLead()
                            {
                                Item = reader["Item"].ToString(),
                                Quantity = Convert.ToInt32(reader["Quantity"]),
                                // Add more properties as needed
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to fetch stocks");
                // Handle or log the exception as per your requirement
            }

            return stocktrackerlead;
        }

        private List<ItemsLead> FetchItemsLead()
        {
            List<ItemsLead> itemsLead = new List<ItemsLead>();

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand("SELECT TOP (1000) * FROM [dbo].[ItemsLead]", con))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            itemsLead.Add(new ItemsLead()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Item = reader["Item"].ToString(),
                                Quantity = Convert.ToInt32(reader["Quantity"]),
                                CostPerItem = Convert.ToDecimal(reader["CostPerItem"])
                                // Add more properties as needed
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to fetch items lead");
                // Handle or log the exception as per your requirement
            }

            return itemsLead;
        }

        // Action method for the "Error" view
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
