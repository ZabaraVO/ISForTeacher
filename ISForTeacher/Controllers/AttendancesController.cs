using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISForTeacher.Controllers
{
    public class AttendancesController : Controller
    {
        // GET: Attendances
        public ActionResult Index(string groupId, string subjectId)
        {
            int groupIdInt = Int32.Parse(groupId);
            int subjectIdInt = Int32.Parse(subjectId);
            return View(GetThemes(groupIdInt, subjectIdInt));
        }

        [HttpPost]
        public ActionResult SaveAttendances(List<AttendanceInfo> info)
        {
            AttendancesEntities context = new AttendancesEntities();
            foreach(AttendanceInfo ai in info)
            {
                Attendance att = context.Attendance.
                    First(e => e.idStudent == ai.StudentId && e.idWork == ai.WorkId);
                if (ai.Value == " ")
                    ai.Value = "п";
                att.visitType = ai.Value;
            }
            context.SaveChanges();
            return Json(new { success = true });
        }

        private List<Theme> GetThemes(int groupId, int subjectId)
        {
            ViewBag.GroupId = groupId;
            ViewBag.SubjectId = subjectId;
            AttendancesEntities context = new AttendancesEntities();
            StudyGroup group = context.StudyGroup.First(e => e.id_group == groupId);
            ViewBag.Students = group.Student.ToList();
            ViewBag.GroupName = group.Name;
            List<Student> students = group.Student.ToList();
            List<int> studentsIds = new List<int>();
            foreach(Student student in students)
                studentsIds.Add(student.idStudent);

            Subject subject = context.Subject.First(e => e.id_subject == subjectId);
            ViewBag.SubjectName = subject.Name;
            List<Theme> themes = subject.Theme.ToList();
            bool tmp;
            foreach (Theme theme in themes)
                foreach(Work work in theme.Work)
                {
                    work.Attendance = work.Attendance.Where(a => studentsIds.Exists(id => id == a.idStudent)).ToList();
                    tmp = group.Student.ToList().Exists(s => s == work.Attendance.First().Student);
                }
            return themes;
        }
    }
}