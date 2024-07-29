using System;

namespace exam.Exams
{
    internal class PracticalExam : Exam
    {
        public PracticalExam(DateTime examTime, int numberOfQuestions, int time) : base(examTime, numberOfQuestions, time)
        {
        }

        public override void Display_Exam()
        {
            Console.WriteLine("Practical Exam:");
            foreach (var question in Questions)
            {
                question.DisplayQuestion();
                foreach (var answer in question.AnswerList)
                {
                    Console.WriteLine(answer);
                }
            }

            int garde = CalculateGrade();
            Console.WriteLine($"garde: {garde}/{Number_Of_Questions}");
        }

        private int CalculateGrade()
        {
            int right_answer = 0;
            foreach (var question in Questions)
            {
                Console.WriteLine($"'{question.Header}', enter your answer ID:");
                if (!int.TryParse(Console.ReadLine(), out int userAnswerId))
                {
                    Console.WriteLine("Invalid answer ID.");
                    continue;
                }

                if (question.RightAnswer != null && userAnswerId == question.RightAnswer.AnswerId)
                {
                    right_answer++;
                }
            }
            return right_answer;
        }

        public override void ShowAnswers()
        {
            Console.WriteLine("Right answers for the Practical Exam:");
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
