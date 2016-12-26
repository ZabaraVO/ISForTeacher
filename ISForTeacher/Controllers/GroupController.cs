using ISForTeacher.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISForTeacher.Controllers
{
    public class GroupController : Controller
    {
        // GET: Group
        public ActionResult Index(string groupName, string groupId)
        {
            ViewBag.BigHeader = groupName;
            ViewBag.GroupId = groupId;
            ViewBag.ListElemsLinkType = ListElemsLinkType.lel_ToAttendances;
            ViewBag.ElementsListControllsType = ElementsListControllsType.elc_AddRemove;
            ViewBag.ShowBackCancel = ShowBackCancel.sbc_Back;
            @ViewBag.BacklLink = Url.Action(
                actionName: "Index",
                controllerName: "GroupesList"
            );
            ViewBag.RightBottomControllsType = RightBottomControllsType.rbc_Settings;
            ViewBag.GroupOrDiscipline = GroupOrDiscipline.god_Group;
            ViewBag.ContentArea = ContentArea.ca_ListElement;
            return View("~/Views/Common/Window.cshtml", getDisciplines(groupId));
        }

        private List<List<string>> getDisciplines(string groupId)
        {
            AttendancesEntities context = new AttendancesEntities();
            StudyGroup group = context.StudyGroup.First(e => e.id_group.ToString() == groupId);
            List<List<string>> result = new List<List<string>>();
            foreach(Subject subject in group.Subject)
            {
                List<string> list = new List<string> { subject.Name, subject.id_subject.ToString()};
                result.Add(list);
            }

            return result;
            /*return new List<List<string>> {
                new List<string> { "Технологии прог-я", "1" },
                new List<string> { "Мат. логика", "2" }
            };*/
        }
    }
}