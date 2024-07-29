using exam.Exams;
using exam.ques;

using System;
using System.ComponentModel.Design;

namespace exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject(10, "Computer Science");
            ExamType examType;
            string examTypeInput;
            do
            {
                Console.WriteLine("Enter the type of exam (Practical or Final):");
                examTypeInput = Console.ReadLine()?.ToLower();

            } while (!Enum.TryParse(examTypeInput, true, out examType) || !Enum.IsDefined(typeof(ExamType), examType));

            Console.WriteLine("Enter the number of questions for the exam:");
            int numberOfQuestions;
            while (!int.TryParse(Console.ReadLine(), out numberOfQuestions) || numberOfQuestions <= 0)
            {
                Console.WriteLine("Invalid number. Please enter a positive integer.");
            }

            Console.WriteLine("Enter the time of the exam in min:");
            int.TryParse(Console.ReadLine(), out int time);

            Console.Clear();

            Exam exam = examType == ExamType.Final
                ? new FinalExam(DateTime.Now, numberOfQuestions, time)
                : new PracticalExam(DateTime.Now, numberOfQuestions, time);

            Console.Clear();
            for (int i = 0; i < numberOfQuestions; i++)
            {
                Console.WriteLine("Enter type of question (True Or False (1) / MCQ (2) ):");
                if (!int.TryParse(Console.ReadLine(), out int questionTypeInput) ||
                    !Enum.IsDefined(typeof(QuestionType), questionTypeInput))
                {
                    Console.WriteLine("Invalid question type.");
                    return;
                }

                var questionType = (QuestionType)questionTypeInput;

                Console.WriteLine("Enter question:");
                string body = Console.ReadLine() ?? string.Empty;

                Console.WriteLine("Enter question mark:");
                if (!int.TryParse(Console.ReadLine(), out int mark) || mark <= 0)
                {
                    Console.WriteLine("Invalid mark.");
                    return;
                }

                int numberOfAnswers = questionType == QuestionType.TrueOrFalse ? 2 : 3;

                Question question = questionType == QuestionType.TrueOrFalse
                    ? new TrueFalse("True or False Question", body, mark)
                    : new Mcq("MCQ Question", body, mark);

                Console.WriteLine("Enter the answers:");
                question.AnswerList = new Answer[numberOfAnswers];
                for (int j = 0; j < numberOfAnswers; j++)
                {
                    Console.WriteLine($"Enter answer {j + 1}: ");
                    string answerText = Console.ReadLine() ?? string.Empty;

                    question.AnswerList[j] = new Answer(j + 1, answerText);
                }

                Console.WriteLine("Enter the ID of the right answer:");
                if (!int.TryParse(Console.ReadLine(), out int rightAnswerId))
                {
                    Console.WriteLine("Invalid answer ID.");
                    return;
                }

                Answer? foundAnswer = null;
                foreach (var answer in question.AnswerList)
                {
                    if (answer.AnswerId == rightAnswerId)
                    {
                        foundAnswer = answer;
                        break;
                    }
                }
                question.RightAnswer = foundAnswer;

                Console.Clear();
                exam.AddQuestion(question);
            }

            Console.Clear();

            Console.WriteLine("Are you ready for the exam? (yes or no)");
            string? readiness = Console.ReadLine()?.ToLower();

            if (readiness == null)
            {
                Console.WriteLine("try agian");

            }
            else if (readiness == "yes")
            {
                subject.CreateExam(exam);
                exam.StartExam();
                exam.Display_Exam();
                exam.EndExam();
            }
            else
            {
                Console.WriteLine("try later ");
            }    
            exam.ShowAnswers();
            
        }
    }
}
