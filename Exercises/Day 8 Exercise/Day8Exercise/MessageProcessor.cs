namespace Day8Exercise
{
    internal class MessageProcessor
    {
        static void Main(string[] args)
        {
            //Take input in one line  UserName: <username> and LoginMessage:<message>
            Console.WriteLine("Enter input in the format 'UserName: <username> and LoginMessage:<message>'");
            string input = Console.ReadLine();
            string[] parts = input.Split('|', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            string userName = parts[0];
            string message = parts[1].ToLower();
            string status = string.Empty;

            //Business Logic
            if (!message.Contains("successful"))
            {
                status = "LOGIN FAILED";
            }
            else if(message.Equals("login successful"))
            {
                status = "LOGIN SUCCESS";
            }
            else
            {
                status = "LOGIN SUCCESS(CUSTOM MESSAGE)";
            }


            Console.WriteLine($"User: {userName}");
            Console.WriteLine($"Message: {message}");
            Console.WriteLine($"Status: {status}");

        }
    }
}
