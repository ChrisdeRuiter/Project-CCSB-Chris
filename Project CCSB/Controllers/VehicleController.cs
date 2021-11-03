using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using Project_CCSB.Models;
using Project_CCSB.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Project_CCSB.Controllers
{
    public class VehicleController : Controller
    {
        private SqlConnection con;
        //To Handle connection related activities
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);

        }
        public IActionResult AddVehicle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddVehicle(VehicleViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    if (AddVehicle(model))
                    {
                        return View();
                    }
                    ViewBag.Message = "Vehicle details added successfully";

                    return View();
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        public bool AddVehicle(VehicleViewModel obj)
        {
            connection();
            SqlCommand com = new SqlCommand("AddNewEmpDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@VehicleBrand", obj.VehicleBrand);
            com.Parameters.AddWithValue("@VehicleType", obj.VehicleType);
            com.Parameters.AddWithValue("@Length", obj.Length);
            com.Parameters.AddWithValue("@VehicleKind", obj.VehicleKind);
            com.Parameters.AddWithValue("@Licenseplate", obj.Licenseplate);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }
        }
    }
}
