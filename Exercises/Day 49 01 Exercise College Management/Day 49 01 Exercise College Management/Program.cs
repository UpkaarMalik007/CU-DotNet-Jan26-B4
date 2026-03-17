namespace Day_49_01_Exercise_College_Management
{

    public class Program
    {
        class CollageManagement
        {
            Dictionary<string, Dictionary<string, int>> studentRecords = new Dictionary<string, Dictionary<string, int>>();

            Dictionary<string, Dictionary<string, int>> subjectsRecords = new Dictionary<string, Dictionary<string, int>>();

            Dictionary<string, List<string>> subjectInsertionOrder = new Dictionary<string, List<string>>();

            public int AddStudent(string studentId, string subject, int marks)
            {
                // studentRecords update
                if (!studentRecords.ContainsKey(studentId))
                    studentRecords[studentId] = new Dictionary<string, int>();

                if (!studentRecords[studentId].ContainsKey(subject) || studentRecords[studentId][subject] < marks)
                    studentRecords[studentId][subject] = marks;

                // subjectsRecords update
                if (!subjectsRecords.ContainsKey(subject))
                {
                    subjectsRecords[subject] = new Dictionary<string, int>();
                    subjectInsertionOrder[subject] = new List<string>();
                }

                if (!subjectsRecords[subject].ContainsKey(studentId))
                {
                    subjectsRecords[subject][studentId] = marks;
                    subjectInsertionOrder[subject].Add(studentId);
                }
                else if (subjectsRecords[subject][studentId] < marks)
                {
                    subjectsRecords[subject][studentId] = marks;
                }

                return 1;
            }

            public int RemoveStudent(string studentId)
            {
                if (!studentRecords.ContainsKey(studentId))
                    return 0;

                foreach (var subject in studentRecords[studentId].Keys)
                {
                    if (subjectsRecords.ContainsKey(subject))
                    {
                        subjectsRecords[subject].Remove(studentId);
                        subjectInsertionOrder[subject].Remove(studentId);
                    }
                }

                studentRecords.Remove(studentId);
                return 1;
            }

            public string TopStudent(string subject)
            {
                if (!subjectsRecords.ContainsKey(subject) || subjectsRecords[subject].Count == 0)
                    return "";

                int maxMarks = subjectsRecords[subject].Values.Max();

                List<string> result = new List<string>();

                foreach (var student in subjectInsertionOrder[subject])
                {
                    if (subjectsRecords[subject][student] == maxMarks)
                    {
                        result.Add(student + " " + maxMarks);
                    }
                }

                return string.Join("\n", result);
            }

            public string Result()
            {
                List<string> result = new List<string>();

                foreach (var student in studentRecords.Keys)
                {
                    double avg = studentRecords[student].Values.Average();
                    result.Add(student + " " + avg.ToString("0.00"));
                }

                return string.Join("\n", result);
            }
        }

        public static void Main()
        {
            CollageManagement cm = new CollageManagement();

            cm.AddStudent("S1", "Math", 80);
            cm.AddStudent("S2", "Math", 90);
            cm.AddStudent("S3", "Math", 90);
            cm.AddStudent("S1", "Phy", 90);

            Console.WriteLine(cm.TopStudent("Math"));
            Console.WriteLine(cm.Result());

            cm.RemoveStudent("S1");
        }
    }
}
