using System;

namespace LabWork1
{
    public class Gardener : Human, ISleepStanding
    {

        public Gardener(string name, string surname, int age, eSex sex , double salary)
            : base(name, surname, age, sex)
        {
            Salary = salary;
        }

        public double Salary { get; set; }

        public string SleepStanding()
        {
            return "Я сплю стоячи.";
        }

    }
}
