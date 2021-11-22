
namespace LabWork1
{
    public enum eSex { Male, Female }

    public class Human
    {
        public Human(string name, string surname, int age, eSex sex)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Sex = sex;
        }


        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public eSex Sex { get; private set; }

    }
}
