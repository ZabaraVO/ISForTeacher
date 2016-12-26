using ISForTeacher.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISForTeacher.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.IsStartPage = true;
            //tmpAttendancesFilling();
            return View("~/Views/Common/Window.cshtml");
        }

        private void tmpAttendancesFilling()
        {
            AttendancesEntities context = new AttendancesEntities();
            List<StudyGroup> groupes = context.StudyGroup.ToList();
            foreach(StudyGroup group in groupes)
            {
                foreach(Subject subject in group.Subject)
                {
                    foreach (Theme theme in subject.Theme)
                    {
                        foreach (Work work in theme.Work)
                        {
                            foreach (Student student in group.Student)
                            {
                                Attendance att = new Attendance();
                                att.idStudent = student.idStudent;
                                att.idWork = work.idWork;
                                att.visitType = tmpGetRandAttValue();
                                context.Attendance.Add(att);
                            }
                        }
                    }
                }
            }
            context.SaveChanges();
        }
        private string tmpGetRandAttValue()
        {
            Random rnd = new Random();
            int intVal = rnd.Next(1, 4);
            string result = "";
            switch (intVal)
            {
                case 1:
                    result = "п";
                    break;
                case 2:
                    result = "б";
                    break;
                case 3:
                    result = "н";
                    break;
            }
            return result;
        }
    }
}