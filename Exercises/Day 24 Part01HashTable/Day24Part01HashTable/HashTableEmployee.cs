using System.Collections;

namespace Day24Part01HashTable
{
    internal class HashTableEmployee
    {
        static void Main(string[] args)
        {
            Hashtable employeeTable = new Hashtable();
            employeeTable.Add(101, "Alice");
            employeeTable.Add(102, "Bob");
            employeeTable.Add(103, "Charlie");
            employeeTable.Add(104, "Diana");

            if (!employeeTable.ContainsKey(105))
            {
                employeeTable.Add(105, "Edward");
            }
            else
            {
                Console.WriteLine("Id already exists.");
            }

            object empNameObj = employeeTable[102];
            string empName = (string)empNameObj;

            Console.WriteLine($"Employee with id 102: {empName}");

            foreach(DictionaryEntry item in employeeTable)
            {
                Console.WriteLine($"ID:{item.Key}, NAME:{item.Value} ");
            }

            Console.WriteLine($"Total Employee Before Deletion: {employeeTable.Count}");
            employeeTable.Remove(103);
            Console.WriteLine($"Total Employee After Deletion: {employeeTable.Count}");


        }
    }
}
