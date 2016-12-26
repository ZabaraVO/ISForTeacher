using ISForTeacher.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISForTeacher.Controllers
{
    public class QuestionsGeneratorController : Controller
    {
        // GET: QuestionsGenerator
        public ActionResult Index(string groupId, string subjectId, string cancelLink)
        {
            ViewBag.SubjectId = subjectId;
            ViewBag.BigHeader = "Генерация вопросов";
            ViewBag.ShowSelectionButtons = true;
            ViewBag.ListElemsLinkType = ListElemsLinkType.lel_ToQuesions;
            ViewBag.ElementsListControllsType = ElementsListControllsType.elc_generateQuestions;
            ViewBag.ShowBackCancel = ShowBackCancel.sbc_Cancel;
            ViewBag.CancelLink = cancelLink;
            return View("~/Views/Common/Window.cshtml", getStudents(Int32.Parse(groupId)));
        }

        private List<List<string>> getStudents(int groupId)
        {
            AttendancesEntities context = new AttendancesEntities();
            ViewBag.SmallHeader = context.StudyGroup.First(e=>e.id_group==groupId).Name;
            List<Student> groupStudents= context.Student.Where(e => e.id_group == groupId).ToList();
            List<List<string>> result = new List<List<string>>();
            foreach (Student student in groupStudents)
                result.Add(new List<string> { student.FIO, student.idStudent.ToString() });
            return result;
        }
    }
}