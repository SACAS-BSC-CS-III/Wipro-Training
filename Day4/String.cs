using System;

class StringPrograms
{
    static void Main()
    {
        // string text = "CSharp Language";

        // int length = text.Length;
        // Console.WriteLine("The Length of the String is : " + length);

        // string subString = text.Substring(7, 8);
        // Console.WriteLine("The Substring of the Main String is : " + subString);

        // Console.WriteLine(text.ToUpper());

        // Console.WriteLine(text.IndexOf("r"));

        // string newText = text.Replace("CSharp", "Java");
        // Console.WriteLine("The Replaced String is " + newText);

        // string Replaced = text.Replace(" ", "");
        // Console.WriteLine("The String Length after removing Spaces : " + Replaced.Length);

        // int pos = text.IndexOf("Language");
        // string newString = text.Substring(pos, 8);
        // Console.WriteLine("The New String is " + newString);

        // string data1 = "This is the day fout training class";
        // string[] lang1 = data1.Split(' ');
        // Console.WriteLine("The blank spaces in the above statement : " + ((lang1.Length) - 1));

        // string data2 = "apple,orange,grapes,banana";
        // string[] lang2 = data2.Split(',');
        // Console.WriteLine("The Specail characters in the above statement : " + ((lang2.Length) - 1));

        // string data3 = "This is the day fout training class";
        // string[] lang3 = data3.Split(' ');
        // Console.WriteLine("The Number of Words in the above statement :" + (lang3.Length));

        // int specialCharCount = 0;
        // string data4 = "One@Two#Three$Four%Five&Six";
        // foreach (char i in data4)
        // {
        //     if (!char.IsLetterOrDigit(i) && !char.IsWhiteSpace(i))
        //     {
        //         specialCharCount++;
        //     }
        // }
        // Console.WriteLine("The Total Number of special characters : " + specialCharCount);

        int vCount = 0;
        int cCount = 0;
        int splCharCount = 0;
        int numCount = 0;
        int spaceCount = 0;

        string givenData = "Hello! Team, submit the Project 23-07-2005.";
        char[] vowels = ['a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'];
        foreach (char c in givenData)
        {
            if (vowels.Contains(c))
            {
                vCount++;
            }
            else
            {
                if (!char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c))
                {
                    splCharCount++;
                }
                else if (char.IsLetter(c))
                {
                    cCount++;
                }
                else if (char.IsDigit(c))
                {
                    numCount++;
                }
                else if (char.IsWhiteSpace(c))
                {
                    spaceCount++;
                }
            }
        }
        Console.WriteLine("Vowels : " + vCount);
        Console.WriteLine("Consonants : " + cCount);
        Console.WriteLine("special : " + splCharCount);
        Console.WriteLine("Numeric : " + numCount);
        Console.WriteLine("Spaces : " + spaceCount);
        
    }
}