using EventPlanner360.Areas.Service.Models;
using EventPlanner360.Areas.Venue.Models;
using EventPlanner360.DAL.Service;
using EventPlanner360.DAL.Venue;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace EventPlanner360.Areas.Service.Controllers
{
    [Area("Service")]
    [Route("Service/[Controller]/[Action]")]
    public class ServiceController : Controller
    {
        public IConfiguration Configuration;
        public ServiceController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        ServiceDALBase serviceDALBase = new ServiceDALBase();

        #region Service List
        public IActionResult ServiceList()
        {
            DataTable dataTable = serviceDALBase.PR_Service_SelectAll();
            return View(dataTable);
        }
        #endregion

        #region Service By ID
        public IActionResult ServiceAdd(int ServiceID)
        {
            ServiceModel serviceModel = serviceDALBase.PR_Service_SelectByID(ServiceID);
            if (serviceModel != null)
            {
                return View("ServiceAddEdit", serviceModel);
            }
            else
            {
                return View("ServiceAddEdit");
            }
        }
        #endregion


        #region Service Save
        public IActionResult ServiceSave(ServiceModel serviceModel)
        {
            if (ModelState.IsValid)
            {
                if (serviceDALBase.ServiceSave(serviceModel))
                {
                    TempData["Save"] = "Service Inserted Successfully.";
                    return RedirectToAction("ServiceList");
                }
            }
            return View("ServiceAddEdit");
        }
        #endregion


        #region Service Delete
        public IActionResult ServiceDelete(int ServiceID)
        {
            bool isSuccess = serviceDALBase.PR_Service_Delete(ServiceID);
            if (isSuccess)
            {
                return RedirectToAction("ServiceList");
            }
            return RedirectToAction("ServiceList");
        }
        #endregion

        #region Venue Filter

        public IActionResult ServiceFilter(ServiceModel model)
        {
            string connectionstr = this.Configuration.GetConnectionString("myConnectionString");
            SqlConnection sqlConnection = new SqlConnection(connectionstr);
            sqlConnection.Open();

            SqlCommand ObjCmd = sqlConnection.CreateCommand();

            ObjCmd.CommandType = CommandType.StoredProcedure;
            ObjCmd.CommandText = "PR_Service_Filter";

            if (model.ServiceName == null)
            {
                ObjCmd.Parameters.AddWithValue("@ServiceName", DBNull.Value);
            }
            else
            {
                ObjCmd.Parameters.AddWithValue("@ServiceName", model.ServiceName);
            }
            SqlDataReader sqlDataReader = ObjCmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sqlDataReader);

            return View("ServiceList", dt);
        }

        #endregion
    }
}