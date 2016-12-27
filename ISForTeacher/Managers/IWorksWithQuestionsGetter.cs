using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISForTeacher.Managers
{
    public interface IWorksWithQuestionsGetter
    {
        Dictionary<string, List<Work>> getWorksToAskAbout(List<int> studentIds, string subjectId);
    }
}
