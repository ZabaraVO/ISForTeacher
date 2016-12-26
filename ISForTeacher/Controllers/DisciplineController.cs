using ISForTeacher.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISForTeacher.Controllers
{
    public class DisciplineController : Controller
    {
        // GET: Discipline
        public ActionResult Index(string disciplineName, string disciplineId)
        {
            ViewBag.BigHeader = disciplineName;
            ViewBag.SubjectId = disciplineId;
            ViewBag.ListElemsLinkType = ListElemsLinkType.lel_ToAttendances;
            ViewBag.ElementsListControllsType = ElementsListControllsType.elc_AddRemove;
            ViewBag.ShowBackCancel = ShowBackCancel.sbc_Back;
            @ViewBag.BacklLink = Url.Action(
                actionName: "Index",
                controllerName: "DisciplinesList"
            );
            ViewBag.RightBottomControllsType = RightBottomControllsType.rbc_Settings;
            ViewBag.GroupOrDiscipline = GroupOrDiscipline.god_Discipline;
            ViewBag.ContentArea = ContentArea.ca_ListElement;
            return View("~/Views/Common/Window.cshtml", getGroupes(disciplineId));
        }
        private List<List<string>> getGroupes(string disciplineId)
        {
            AttendancesEntities context = new AttendancesEntities();
            Subject subject = context.Subject.First(e => e.id_subject.ToString() == disciplineId);
            List<List<string>> result = new List<List<string>>();
            foreach (StudyGroup group in subject.StudyGroup)
            {
                List<string> list = new List<string> { group.Name, group.id_group.ToString() };
                result.Add(list);
            }

            return result;

            /*return new List<List<string>> {
                new List<string> { "ИСТ-13", "1" },
                new List<string> { "ММ-13", "2" }
            };*/
        }
    }
}