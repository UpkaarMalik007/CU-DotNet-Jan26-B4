namespace Word_Guessing_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> lst = new List<string> { "MOBILE", "PICTURE", "CLASS", "LAPTOP", "COLLEGE", "SECURITY" };
            bool guessing = true;
            int index = 0;
            int location = 0;


            while (guessing)
            {
                Console.WriteLine("Welcome to C# Hangman");
                string word = string.Empty;
                int lives = 6;
                if (index < lst.Count)
                {
                    word = lst[index++];

                }
                List<char> guessed = new List<char>();
                string gist = new string('_', word.Length);
                while (lives > 0)
                {
                    Console.WriteLine($"Word: {string.Join(" ", gist.ToCharArray())}");
                    Console.WriteLine($"Lives Left: {lives}");
                    Console.WriteLine($"Guessed: {string.Join(",", guessed)}");

                    Console.Write("Guess a letter: ");
                    char ch = char.ToUpper(Console.ReadLine()[0]); // safer than Console.Read()

                    if (ch >= 'A' && ch <= 'Z')
                    {
                        if (guessed.Contains(ch))
                        {
                            Console.WriteLine($"You already guessed '{ch}'. Try again.");
                        }
                        else if (word.Contains(ch))
                        {
                            guessed.Add(ch);
                            char[] display = gist.ToCharArray();
                            for (int j = 0; j < word.Length; j++)
                            {
                                if (word[j] == ch)
                                    display[j] = ch;
                            }
                            gist = new string(display);

                            Console.WriteLine("Good Catch!");

                            if (!gist.Contains('_'))
                            {
                                Console.WriteLine($"You Guessed the Whole Word: {gist}");
                                break;
                            }
                        }
                        else
                        {
                            guessed.Add(ch);
                            lives--;
                            Console.WriteLine("Nope! That's not in the word.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid Letter.");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}

