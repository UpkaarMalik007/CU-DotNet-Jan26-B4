namespace Day7Exercise
{     internal class Day7Exercise
    {
        static void Main()
        {
            string input = Console.ReadLine();  // Separate by '|' : GateCode|UserInitial|AccessLevel|IsActive|Attempts

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("INVALID ACCESS LOG");
                return;
            }

            string[] inputs = input.Split('|');

            if (inputs.Length != 5)
            {
                Console.WriteLine("INVALID ACCESS LOG");
                return;
            }

            // -------- GateCode Validation --------
            string gateCode = inputs[0];
            if (gateCode.Length != 2 || !char.IsLetter(gateCode[0]) || !char.IsDigit(gateCode[1]))
            {
                Console.WriteLine("INVALID ACCESS LOG");
                return;
            }

            // -------- UserInitial Validation --------
            if (inputs[1].Length != 1 || !char.IsUpper(inputs[1][0]))
            {
                Console.WriteLine("INVALID ACCESS LOG");
                return;
            }
            char userInitial = inputs[1][0];

            byte accessLevel = byte.Parse(inputs[2]);
            bool isActive = bool.Parse(inputs[3]);
            byte attempts = byte.Parse(inputs[4]);

            // -------- AccessLevel and Attempts Validation --------
            if (accessLevel < 1 || accessLevel > 7 || attempts > 200)
            {
                Console.WriteLine("INVALID ACCESS LOG");
                return;
            }


            // -------- Business Logic --------
            string status;

            if (!isActive)
                status = "ACCESS DENIED – INACTIVE USER";
            else if (attempts > 100)
                status = "ACCESS DENIED – TOO MANY ATTEMPTS";
            else if (accessLevel >= 5)
                status = "ACCESS GRANTED – HIGH SECURITY";
            else
                status = "ACCESS GRANTED – STANDARD";

            // -------- Formatted Output --------
            Console.WriteLine(status);
            Console.WriteLine($"Gate      : {gateCode}");
            Console.WriteLine($"User      : {userInitial}");
            Console.WriteLine($"Level     : {accessLevel}");
            Console.WriteLine($"Attempts  : {attempts}");
            Console.WriteLine($"Status    : {status}");
        }
    }

}
