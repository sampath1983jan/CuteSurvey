using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuteSurvey.Survey;
using CuteSurvey.SurveyFactory.Component;
using System.Data;
using CuteSurvey.Utility;
namespace CuteSurvey.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //Book book = new Book("Worley", "Inside ASP.NET", 10);
            //book.Display();
            //// Create video
            //Video video = new Video("Spielberg", "Jaws", 23, 92);
            //video.Display();
            //Borrowable borrowvideo = new Borrowable(video);
            //borrowvideo.BorrowItem("Customer #1");
            //borrowvideo.BorrowItem("Customer #1");
            //borrowvideo.Display();

            CuteSurvey.Survey.SurveyBuilder.CreateTemplate("Test survey", "my", "testing purpose", "welcome to my survey", "thank for visiting this survey");
            

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("SurveyID", typeof(int)));
            dt.Columns.Add(new DataColumn("sDate", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("eDate", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("status", typeof(int)));
            DataRow dr;
            dr= dt.NewRow();
            dr[0] = 1;
            dr[1] = DateTime.Now;
            dr[2] = DateTime.Now.AddDays(4);
            dr[3] = 1;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[0] = 2;
            dr[1] = DateTime.Now.AddDays(1);
            dr[2] = DateTime.Now.AddDays(6);
            dr[3] = 2;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[0] = 3;
            dr[1] = DateTime.Now.AddMonths(1);
            dr[2] = DateTime.Now.AddDays(4);
            dr[3] = 2;
            dt.Rows.Add(dr);
            dt.AcceptChanges();
            
         //   var surveys=    dt.toList<Survey.Survey >(
         //   new DataFieldMappings().Add("SurveyID","SurveyID")
         //   .Add("sDate", "StartDate")
         //   .Add ("eDate","EndDate").Add("status","Status").Add("statusss", "status"), Bind);

         //   var sr = new CuteSurvey.Survey.Survey();            

         //   var s = new CuteSurvey.SurveyFactory.SurveyTemplate(1);
         //   var iquestion = s.Questions.NewQuestion(SurveyQuestionType._input,1).Default();
         //   iquestion.IsRequired = true;
         //   s.Questions.AddQuestion(iquestion, Program.CallMe);
         //   var iq = s.Questions.Duplicate(-1);
         //   s.Questions.AddQuestion(iq, Program.CallMe);
         ////   s.Questions.Remove(-1, Program.AfterRemove);
         //   List<Question> qu = s.Questions.GetQuestion(x => x.IsRequired = true && x.MaxLength == 0);
            System.Console.ReadLine();
        }

        //public static CuteSurvey.SurveyFactory.SurveyTemplate load(int sid) {

        //}

        public static Survey.Survey Bind(Survey.Survey survey) {
            survey.SurveyID  = 100;
            return survey;
        }
        //public static bool AfterRemove(Question question) {
        //    return true;
        //}
        public static bool CallMe(IQuestion question) {
            return true;
        }
        
    }


    /// <summary>

    /// The 'ConcreteDecorator' class

    /// </summary>

    class Borrowable : Decorator

    {
        protected List<string> borrowers = new List<string>();

        // Constructor

        public Borrowable(LibraryItem libraryItem)
          : base(libraryItem)
        {
        }

        public void BorrowItem(string name)
        {
            borrowers.Add(name);
            libraryItem.NumCopies--;
        }

        public void ReturnItem(string name)
        {
            borrowers.Remove(name);
            libraryItem.NumCopies++;
        }
        public override void Display()
        {
            base.Display();

            foreach (string borrower in borrowers)
            {
                System.Console.WriteLine(" borrower: " + borrower);
            }
        }
    }

    abstract class Decorator : LibraryItem

    {
        protected LibraryItem libraryItem;

        // Constructor

        public Decorator(LibraryItem libraryItem)
        {
            this.libraryItem = libraryItem;
        }

        public override void Display()
        {
            libraryItem.Display();
        }
    }


    abstract class LibraryItem

    {
        private int _numCopies;

        // Property

        public int NumCopies
        {
            get { return _numCopies; }
            set { _numCopies = value; }
        }

        public abstract void Display();
    }


    class Book : LibraryItem

    {
        private string _author;
        private string _title;

        // Constructor

        public Book(string author, string title, int numCopies)
        {
            this._author = author;
            this._title = title;
            this.NumCopies = numCopies;
        }

        public override void Display()
        {
            System.Console.WriteLine("\nBook ------ ");
            System.Console.WriteLine(" Author: {0}", _author);
            System.Console.WriteLine(" Title: {0}", _title);
            System.Console.WriteLine(" # Copies: {0}", NumCopies);
        }
    }

    class Video : LibraryItem

    {
        private string _director;
        private string _title;
        private int _playTime;

        // Constructor

        public Video(string director, string title,
          int numCopies, int playTime)
        {
            this._director = director;
            this._title = title;
            this.NumCopies = numCopies;
            this._playTime = playTime;
        }

        public override void Display()
        {
            System.Console.WriteLine("\nVideo ----- ");
            System.Console.WriteLine(" Director: {0}", _director);
            System.Console.WriteLine(" Title: {0}", _title);
            System.Console.WriteLine(" # Copies: {0}", NumCopies);
            System.Console.WriteLine(" Playtime: {0}\n", _playTime);
        }
    }


}
