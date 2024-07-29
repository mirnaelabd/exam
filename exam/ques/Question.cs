using exam.ques;
using System;

namespace exam.ques
{
    public enum QuestionType
    {
        TrueOrFalse = 1,
        MCQ = 2
    }

    public abstract class Question : ICloneable
    {
        public string Header { get; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public Answer[] AnswerList { get; set; }
        public Answer RightAnswer { get; set; }

        protected Question(string header, string body, int mark)
        {
            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = new Answer[0];
        }

        public override string ToString()
        {
            return $"{Header}, Body: {Body}, Mark: {Mark}";
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }


        public abstract void DisplayQuestion();
    }
}