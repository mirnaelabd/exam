using exam.Exams;
using System;

namespace exam
{
    public class Subject
    {
          public string SubjectName { get; set; }
        public int SubjectId { get; set; }
      
        public Exam? Exam { get; set; }

        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }

        public void CreateExam(Exam exam)
        {
            Exam = exam;
         
        }
    }
}
