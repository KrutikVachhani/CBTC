using EventPlanner360.DAL.Schedule;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;

namespace EventPlanner360.Areas.Schedule.Controllers
{
    [Area("Schedule")]
    [Route("Schedule/[Controller]/[Action]")]
    public class ScheduleController : Controller
    {
        public IActionResult Schedule()
        {
            ScheduleDALBase scheduleDAL = new ScheduleDALBase();
            DataTable dataTable = scheduleDAL.Schedule();
            return View(dataTable);
        }
    }
}
