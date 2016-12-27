using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISForTeacher.tmpForTests
{
    public class Class1
    {
        public void someMethod()
        {
            var mockSet = new Mock<DbSet<Student>>();

            Mock<AttendancesEntities> mockContext = new Mock<AttendancesEntities>();
            mockContext.Setup(m => m.Student).Returns(mockSet.Object);

            Student student = new Student();
            student.FIO = "Иванов И.И.";
            mockContext.Setup(m => m.Student.Add(student));
        }
    }
}
