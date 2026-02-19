namespace Day38Part01Exercise
{
    internal class VowelShifterCipher
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the string: ");
            string s=Console.ReadLine();
            s = vowelshifter(s);
            if (string.IsNullOrEmpty(s))
            {
                Console.WriteLine(" ");
            }
            else
            {
                Console.WriteLine(s);
            }
        }
        public static string vowelshifter(string input)
        {
            input = input.ToLower();
            if (string.IsNullOrEmpty(input)) return string.Empty;

            List<char> result = new List<char>();

            foreach(var c in input)
            {
                if(c<'a' || c > 'z')
                {
                    return string.Empty;
                }
                if (IsVowel(c))
                {
                    result.Add(nextVowel(c));  //add next vowel
                }
                else
                {
                    result.Add(nextConsonant(c)); // add next consonant
                }

                
            }
            return new string(result.ToArray());

        }

        static bool IsVowel(char c)
        {
            List<char> vowel =new List<char> { 'a', 'e', 'i', 'o', 'u' };
            return vowel.Contains(c);
        }

        static char nextVowel(char ch)
        {
            if (ch == 'a') return 'e';
            else if (ch == 'e') return 'i';
            else if (ch == 'i') return 'o';
            else if (ch == 'o') return 'u';
            else return 'a';
        }

        static char nextConsonant(char ch)
        {
            char nextChar= (char)(ch + 1);

            if (nextChar > 'z')
            {
                nextChar= 'a';
            }


            while (IsVowel(nextChar))
            {
                nextChar = (char)(nextChar + 1);
                if (nextChar > 'z')
                {
                    nextChar = 'a';
                }
            }
            return nextChar;
        }
    }
}
