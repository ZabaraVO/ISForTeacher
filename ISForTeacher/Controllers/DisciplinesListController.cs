using ISForTeacher.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISForTeacher.Controllers
{
    public class DisciplinesListController : Controller
    {
        // GET: DisciplineList
        public ActionResult Index()
        {
            ViewBag.BigHeader = "Предметы";
            ViewBag.ListElemsLinkType = ListElemsLinkType.lel_ToDiscipline;
            ViewBag.ElementsListControllsType = ElementsListControllsType.elc_AddRemove;
            ViewBag.ShowBackCancel = ShowBackCancel.sbc_Back;
            @ViewBag.BacklLink = Url.Action(
                actionName: "Index",
                controllerName: "Home"
            );
            ViewBag.ContentArea = ContentArea.ca_List;
            return View("~/Views/Common/Window.cshtml", getDisciplines());
        }

        private List<List<string>> getDisciplines()
        {
            AttendancesEntities context = new AttendancesEntities();
            List<List<string>> result = new List<List<string>>();
            foreach (Subject subject in context.Subject)
            {
                List<string> list = new List<string> { subject.Name, subject.id_subject.ToString() };
                result.Add(list);
            }
            return result;
        }
    }
}