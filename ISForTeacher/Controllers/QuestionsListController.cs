using ISForTeacher.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ISForTeacher.Controllers
{
    public class QuestionsListController : Controller
    {
        // GET: QuestionsList
        public ActionResult Index(int[] studentIds, string subjectId)
        {
            //JToken jt = JToken.Parse(jsonStudentIds);
            return View(getWorksToAskAbout(studentIds.ToList(), subjectId));
        }

        private Dictionary<string,List<Work>> getWorksToAskAbout(List<int> studentIds, string subjectId)
        {
            AttendancesEntities context = new AttendancesEntities();
            List<Student> students = context.Student.Where(s=>studentIds.Contains(s.idStudent)).ToList();
            List<List<Work>> allNeededWorks = new List<List<Work>>();
            for(int j = 0; j < students.Count; j++)
            {
                allNeededWorks.Add(new List<Work>());
            }

            Subject subject = context.Subject.First(e => e.id_subject.ToString() == subjectId);
            foreach (Theme theme in subject.Theme)
            {
                foreach(Work work in theme.Work)
                {
                    foreach (Student student in students)
                    {
                        Attendance att = work.Attendance.First(e => e.Student == student);
                        if (att.visitType[0] == 'н')
                        {
                            int index = students.IndexOf(student);
                            allNeededWorks[index].Add(work);
                        }
                    }
                }
            }

            Dictionary<string, List<Work>> result = new Dictionary<string, List<Work>>();
            int i = 0;
            foreach (List<Work> works in allNeededWorks)
            {
                result.Add(students[i].FIO,works);
                i++;
            }
            
            return result;
        }
    }
}