public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        //Plan:
        //First we create an array with the length given to store the multiples of the number given
        // Function will iterate through the lenght of the number given and multiply the number 
        // by the index in which I is currently at.
        //The multiple is stored in a variable 
        //The multiple is then stored in the array at the index of I
        //Return the resulting array


        double[] multiplesArray = new double[length];

        for (int i = 0; i < length; i++)
        {
            double multiple = number * (i + 1);
            multiplesArray[i] = multiple;
        }
        return multiplesArray; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //Plan:
        //First we create a new list 
        //We iterate through the list of data that is going to be rotated selecting the last 'amount' of numbers 
        //Using a foreach loop with the range method
        //we assign each number rotated to the new list
        //With the other part of the list of numbers we iterate and add them to the new list
        //Finally we clear the original list and add the new rotated list to it

        List<int> rotatedList = new List<int>(data.Count);

        foreach (int number in data.GetRange(data.Count - amount, amount))
        {
            rotatedList.Add(number);
        }

        foreach (int number in data.GetRange(0, data.Count - amount))
        {
            rotatedList.Add(number);


        }
        data.Clear();
        data.AddRange(rotatedList);
    }
}