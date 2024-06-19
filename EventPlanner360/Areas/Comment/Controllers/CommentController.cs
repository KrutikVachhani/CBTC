using Microsoft.AspNetCore.Mvc;
using EventPlanner360.Areas.Comment.Models;
using EventPlanner360.DAL.Comment;
using System.Data;

namespace EventPlanner360.Areas.Comment.Controllers
{
    [Area("Comment")]
    [Route("Comment/[Controller]/[Action]")]
    public class CommentController : Controller
    {
        #region Configuration

        public IConfiguration Configuration;
        public CommentController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        CommentDALBase commentDALBase = new CommentDALBase();

        #endregion


        #region Comment List
        public IActionResult CommentView()
        {
            DataTable dataTable = commentDALBase.PR_Comment_SelectAll();
            return View(dataTable);
        }

        public IActionResult CommentList()
        {
            DataTable dataTable = commentDALBase.PR_Comment_SelectAll();
            return View(dataTable);
        }
        #endregion


        #region Comment Add
        public IActionResult CommentAdd(int CommentID)
        {
            CommentModel commentModel = commentDALBase.PR_Comment_SelectByID(CommentID);
            if (commentModel != null)
            {
                return View("CommentAddEdit", commentModel);
            }
            else
            {
                return View("CommentAddEdit");
            }
        }
        #endregion


        #region Comment Save
        public IActionResult CommentSave(CommentModel commentModel)
        {
            if (ModelState.IsValid)
            {
                if (commentDALBase.CommentSave(commentModel))

                    return RedirectToAction("CommentView");
                else
                {
                    return RedirectToAction("CommentView");
                }
            }
            return View("CommentView");
        }
        #endregion


        #region Comment Delete
        public IActionResult CommentDelete(int CommentID)
        {
            bool isSuccess = commentDALBase.PR_Comment_Delete(CommentID);
            if (isSuccess)
            {
                return RedirectToAction("CommentList");
            }
            return RedirectToAction("CommentList");
        }
        #endregion
    }
}
