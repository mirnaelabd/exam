using System;
using exam.ques;

namespace exam.Exams
{
    internal class FinalExam : Exam
    {
        private DateTime now;

     
public FinalExam(DateTime examTime, int numberOfQuestions, int time) : base(examTime, numberOfQuestions, time)
        {
        }

        public override void Display_Exam()
        {
            Console.WriteLine("Final Exam:");
            foreach (var question in Questions)
            {
                question.DisplayQuestion();
                foreach (var answer in question.AnswerList)
                {
                    Console.WriteLine(answer);
                }
            }
            int score = CalculateGrade();
            Console.WriteLine($"Grade: {score}/{Number_Of_Questions}");
        }

        private int CalculateGrade()
        {
            int correctAnswers = 0;
            foreach (var question in Questions)
            {
                Console.WriteLine($"For question '{question.Header}', enter your answer ID:");
                if (!int.TryParse(Console.ReadLine(), out int userAnswerId))
                {
                    Console.WriteLine("Invalid answer ID.");
                    continue;
                }

                if (question.RightAnswer != null && userAnswerId == question.RightAnswer.AnswerId)
                {
                    correctAnswers++;
                }
            }
            return correctAnswers;
        }

        public override void ShowAnswers()
        {
            Console.WriteLine("Showing right answers for the Final Exam:");
            foreach (var question in Questions)
            {
                Console.WriteLine(question.Header);
                Console.WriteLine(question.Body);
                foreach (var answer in question.AnswerList)
                {
                    if (answer == question.RightAnswer)
                    {
                        Console.WriteLine($"Correct Answer: {answer}");
                    }
                }
            }
        }
    }
}
