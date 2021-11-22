using System;

namespace LabWork1
{
    public class Student : Human, ISleepStanding
    {

        public Student(string name, string surname, int age, eSex sex,
            int course, string studentTicket, bool livesInDormitory, string passportNumber)
            : base(name, surname, age, sex)
        {
            Course = course;
            LivesInDormitory = livesInDormitory;
            StudentTicket = studentTicket;
            PassportNumber = passportNumber;
        }


        public int Course { get; set; }
        public bool LivesInDormitory { get; set; }
        public string StudentTicket { get; set; }
        public string PassportNumber { get; set; }


        public string SleepStanding()
        {
            return "Я малюю картину.";
        }

    }
}
