namespace Day_50_01_Exercise_Student_Dictionary
{
    class Stud
    {
        public int StudId { get; set; }
        public string SName { get; set; }
        public override bool Equals(object? obj)
        {
            var x = obj as Stud;
            return this.StudId == x?.StudId && SName == x.SName;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(StudId, SName);
        }
    }

    class ManageStudent
    {
        Dictionary<Stud, int> dic = new();
        public void AddStudent(Stud st, int marks)
        {
            if (dic.ContainsKey(st))
            {
                if (marks > dic[st])
                {
                    dic[st] = marks;
                }
            }
            else
            {
                dic.Add(st, marks);
            }
        }
        public void Display()
        {
            var display = dic.Select(s => new { s.Key.StudId, s.Key.SName, s.Value });
            foreach (var v in display)
            {
                Console.WriteLine(v.StudId + v.SName + v.Value);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            ManageStudent m = new();
            m.AddStudent(new Stud()
            {
                StudId = 1,
                SName = "Raj"
            }, 67);
            m.AddStudent(new Stud()
            {
                StudId = 1,
                SName = "Raj"
            }, 38);
            m.AddStudent(new Stud()
            {
                StudId = 2,
                SName = "Rahul"
            }, 90);
            m.AddStudent(new Stud()
            {
                StudId = 3,
                SName = "Rakesh"
            }, 56);

            m.Display();
        }
    }
}
