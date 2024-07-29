using System;

namespace exam.ques

{
    internal class Mcq :   Question
    {
        public Mcq(string header, string body, int mark) : base(header, body, mark)
        {
        }

        public override void DisplayQuestion()
        {
            Console.WriteLine(Header);
            Console.WriteLine(Body);
        }
    }
}
