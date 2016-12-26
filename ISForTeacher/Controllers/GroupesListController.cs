using ISForTeacher.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISForTeacher.Controllers
{
    public class GroupesListController : Controller
    {
        // GET: GroupesList
        public ActionResult Index()
        {
            ViewBag.BigHeader = "Группы";
            ViewBag.ListElemsLinkType = ListElemsLinkType.lel_ToGroupe;
            ViewBag.ElementsListControllsType = ElementsListControllsType.elc_AddRemove;
            ViewBag.ShowBackCancel = ShowBackCancel.sbc_Back;
            @ViewBag.BacklLink = Url.Action(
                actionName: "Index",
                controllerName: "Home"
            );
            ViewBag.ContentArea = ContentArea.ca_List;
            return View("~/Views/Common/Window.cshtml", getGroupes());
        }
        private List<List<string>> getGroupes()
        {
            AttendancesEntities context = new AttendancesEntities();
            List<List<string>> result = new List<List<string>>();
            foreach(StudyGroup group in context.StudyGroup)
            {
                List<string> list = new List<string> { group.Name, group.id_group.ToString()};
                result.Add(list);
            }
            return result;
            /*return new List<List<string>> {
                new List<string> { "ИСТ-13", "1" },
                new List<string> { "БМ-14", "2" },
                new List<string> { "ММ-15", "3" }
            };*/
        }
    }
}