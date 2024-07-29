using exam.ques;

using System;
using System.Collections.Generic;

namespace exam.Exams
{
   
        public enum ExamType
        {
            Final = 1,
            Practical = 2
        }
    
    public abstract class Exam
    {
        public DateTime ExamTime { get; set; }
        public int Number_Of_Questions { get; set; }
        public int time { get; set; }

        public List<Question> Questions { get; set; } = new List<Question>();
        public Subject? AssociatedSubject { get; set; }
        private DateTime startTime;
        private DateTime EndTime;

        protected Exam(DateTime examTime, int numberOfQuestions, int time)
        {
            ExamTime = examTime;
            Number_Of_Questions = numberOfQuestions;
            this.time = time;
        }

        public abstract void Display_Exam();

        public void AddQuestion(Question question)
        {
            if (question == null)
            {
                Console.WriteLine("Try again , can't add a question.");
                return;
            }

            if (Questions.Count < Number_Of_Questions)
            {
                Questions.Add(question);
            }
            else
            {
                Console.WriteLine("Can't add more questions. Exam is full.");
            }
        }

        public abstract void ShowAnswers();

        public void StartExam()
        {
            startTime = DateTime.Now;
            Console.WriteLine($"Exam started at :{startTime}");
        }

        public void EndExam()
        {
            EndTime = DateTime.Now;
         
            TimeSpan timeTaken = EndTime - startTime;
            Console.WriteLine($"Total time taken: {timeTaken.TotalMinutes} minutes");
        }
    }
}
