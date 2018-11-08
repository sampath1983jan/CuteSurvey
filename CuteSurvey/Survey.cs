using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuteSurvey.SurveyFactory
{
    public class Survey
    {
        public int SurveyID;
        public int UserID;
        public ISurveyTemplate SurveyTemplate;

    }
}
