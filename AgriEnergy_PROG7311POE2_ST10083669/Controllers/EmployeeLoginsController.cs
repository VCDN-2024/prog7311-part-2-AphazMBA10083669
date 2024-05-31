using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgriEnergy_PROG7311POE2_ST10083669.Models;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;


namespace AgriEnergy_PROG7311POE2_ST10083669.Controllers
{
    public class EmployeeLoginsController : Controller

    {
        private readonly AgriEnergyConnectPlatformContext _context;

        public EmployeeLoginsController(AgriEnergyConnectPlatformContext context)
        {
            _context = context;
        }

        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        // GET Account
        [HttpGet]
        public IActionResult Username(EmployeeLogin employeeLogin)
        {
            return View();
        }

        void connectionString()
        {
            con.ConnectionString = "Data Source=labVMH8OX\\SQLEXPRESS;Initial Catalog=AgriEnergyConnectPlatform;Integrated Security=True;" +
                "Encrypt=True;Trust Server Certificate=True";
        }

        public IActionResult PasswordHash(EmployeeLogin employeeLogin)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from EmployeeLogins where username='"+employeeLogin.EmployeeId+"' and password='"+employeeLogin.PasswordHash+"'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("Create");
            }
            else
            {
                con.Close();
                return View("Error");
            }
        }
    }
}
