class Program
{
    static void Main(string[] args)
    {
        //Challenge 1
        int[][] arr1 = { new int[] { 1, 2 }, new int[] { 2, 1, 5 } };

        int[] arr1Common = CommonItems(arr1);
        /* write method to print arr1Common */

        //Challenge 2
        int[][] arr2 = { new int[] { 1, 2 }, new int[] { 1, 2, 3 } };
        InverseJagged(arr2);
        /* write method to print arr2 */

        //Challenge 3
        int[][] arr3 = { new int[] { 1, 2 }, new int[] { 1, 2, 3 } };
        CalculateDiff(arr3);
        /* write method to print arr3 */

        //Challenge 4
        int[,] arr4 = { { 1, 2, 3 }, { 4, 5, 6 } };
        int[,] arr4Inverse = InverseRec(arr4);
        /* write method to print arr4Inverse */

        //Challenge 5
        Demo("hello", 1, 2, "world");

        //Challenge 6
        SwapTwo("this is", "a string");
        //Challenge 7
        string firstName, middleName, lastName;
        ParseNames("Mary Elizabeth Smith", out firstName, out middleName, out lastName);
        Console.WriteLine($"First name: {firstName}, middle name: {middleName}, last name: {lastName}");

        //Challenge 8
        GuessingGame();
    }

    /*
    Challenge 1. Given a jagged array of integers (two dimensions).
    Find the common elements in the nested arrays.
    Example: int[][] arr = { new int[] {1, 2}, new int[] {2, 1, 5}}
    Expected result: int[] {1,2} since 1 and 2 are both available in sub arrays.
    */
    static int[] CommonItems(int[][] jaggedArray)
    {
        int[] result = new int[2];
        int counter = 0;
        foreach (int i in jaggedArray[0])
        {
            // var test = Array.Exists(jaggedArray[1], num => num == i);
            if (Array.Exists(jaggedArray[1], num => num == i))
            {
                result[counter] = i;
                counter++;
            }
        }
        return result;
    }

    /* 
    Challenge 2. Inverse the elements of a jagged array.
    For example, int[][] arr = {new int[] {1,2}, new int[]{1,2,3}} 
    Expected result: int[][] arr = {new int[]{2, 1}, new int[]{3, 2, 1}}
     */
    static void InverseJagged(int[][] jaggedArray)
    {
        foreach (int[] i in jaggedArray)
        {
            Array.Reverse(i);

        }
        int[][] arr = { jaggedArray[0], jaggedArray[1] };

    }

    /* 
    Challenge 3.Find the difference between 2 consecutive elements of an array.
    For example, int[][] arr = {new int[] {1,2}, new int[]{1,2,3}} 
    Expected result: int[][] arr = {new int[] {-1}, new int[]{-1, -1}}
     */
    static void CalculateDiff(int[][] jaggedArray)
    {
        int[] arr1 = new int[jaggedArray[0].GetLength(0) - 1];
        int[] arr2 = new int[jaggedArray[1].GetLength(0) - 1];
        int[][] arr = { arr1, arr2 };
        var counter = 0;
        foreach (int[] i in jaggedArray)
        {
            for (var j = 0; j < (i.Length - 1); j++)
            {
                arr[counter][j] = i[j] - i[j + 1];
            }
            counter++;
        }
    }

    /* 
    Challenge 4. Inverse column/row of a rectangular array.
    For example, given: int[,] arr = {{1,2,3}, {4,5,6}}
    Expected result: {{1,2},{3,4},{5,6}}
    //  */
    static int[,] InverseRec(int[,] recArray)
    {
        int a = recArray.GetLength(0);
        int b = recArray.GetLength(1);

        int[,] result = new int[b, a];
        var c = 0;
        var d = 0;
        for (var i = 0; i < a; i++)
        {
            for (var j = 0; j < b; j++)
            {
                result[c, d] = recArray[i, j];
                d++;
                if (d > 1)
                {
                    d = 0;
                    c++;
                }
            }
        }
        return result;

    }

    /* 
    Challenge 5. Write a function that accepts a variable number of params of any of these types: 
    string, number. 
    - For strings, join them in a sentence. 
    - For numbers then sum them up. 
    - Finally print everything out. 
    Example: Demo("hello", 1, 2, "world") 
    Expected result: hello world; 3 */
    static void Demo(string a, int b, int c, string d)
    {
        string words = a + " " + d + "; ";
        int nums = b + c;
        // System.Console.WriteLine(words + nums);
    }

    /* Challenge 6. Write a function to swap 2 objects but only if they are of the same type 
    and if they’re string, lengths have to be more than 5. 
    If they’re numbers, they have to be more than 18. */
    static void SwapTwo(string a, string b)
    {
        string c = a + b;

        a = c.Substring(a.Length, b.Length);
        b = c.Substring(0, a.Length - 1);
        System.Console.WriteLine(b);

    }

    /* Challenge 7. Write a function to parse the first name, middle name, last name given a string. 
    The names will be returned by using out modifier */
    static void ParseNames(
        string input,
        out string firstName,
        out string middleName,
        out string lastName)
    {
        firstName = "Hung";
        middleName = "Van";
        lastName = "Hoang";
    }

    /* Challenge 8. Write a function that does the guessing game. 
    The function will think of a random integer number (lets say within 100) 
    and ask the user to input a guess. 
    It’ll repeat the asking until the user puts the correct answer. */
    static void GuessingGame()
    {
        try
        {
            Random rnd = new Random();
            int num = rnd.Next(5);
            int inputNum = default;
            while (inputNum != num)
            {
                System.Console.WriteLine("Your guess: ");
                var input = Console.ReadLine();
                inputNum = Int32.Parse(input);
                if (inputNum == num)
                {
                    System.Console.WriteLine("correct answer");
                }
                else
                {
                    System.Console.WriteLine("the answer is wrong. Guess again!");
                }

            }

        }
        catch (System.Exception)
        {

            throw new Exception("error");
        }


    }
}
