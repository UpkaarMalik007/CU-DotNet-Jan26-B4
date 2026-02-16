namespace Day31LINQExercise
{
    class Student
    {
        public int Id;
        public string Name;
        public string Class;
        public int Marks;
    }
    internal class StudentPerformance
    {
        static void Main(string[] args)
        {
            var students = new List<Student>
            {
                new Student{Id=1, Name="Amit", Class="10A", Marks=85},
                new Student{Id=2, Name="Neha", Class="10A", Marks=72},
                new Student{Id=3, Name="Rahul", Class="10B", Marks=90},
                new Student{Id=4, Name="Pooja", Class="10B", Marks=60},
                new Student{Id=5, Name="Kiran", Class="10A", Marks=95}
            };

            var topThreeStudent = students.OrderByDescending(s => s.Marks).Take(3);
            foreach(var stud in topThreeStudent)
            {
                Console.WriteLine(stud.Name+"-"+stud.Marks);
            }

            var avgInStudents = students.GroupBy(s => s.Class).Select(g => new { Class = g.Key, Avg = g.Average(s => s.Marks) }).ToList();
            foreach (var avg in avgInStudents)
            {
                Console.WriteLine(avg.Class+"-"+avg.Avg);
            }
            

            //co-related sub query
            
            var belowAvg = students.Where(s => s.Marks < (students.Where(x => x.Class == s.Class).Average(a => a.Marks))); 
            
            foreach (var s in belowAvg)
            {
                Console.WriteLine($"{s.Name}  {s.Class}  {s.Marks}");
            }
            var ordered = students.OrderBy(s => s.Class).OrderByDescending(s => s.Marks).ToList();
            foreach (var s in ordered)
            {
                Console.WriteLine($"{s.Class}  {s.Name}  {s.Marks}");
            }

        }
    }
}
