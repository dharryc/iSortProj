namespace iSortProj;

public static class Algorithms
{
    // I messed around with this quite a bit, and I think it's tail call optimized, I'm writing this as I run a test with a 500,000 int long array.
    // IT WORKS!!! The 500,000 long array takes like 10 min, but it works for the assignment. I'm going to submit some code that's just showy for the assignment, maybe 50,000 long.
    // I fixed it further, it's like twice as fast now!!!
    public static int[] insertionSort(int[] a)
    {
        //First, get a starting point for the algorithm to start making comparisons
        int index = 1;
        //Now make sure that the algorithm inspects each element in the array
        while (index < a.Length)
        {
            //Check if the current element is smaller than the element behind it
            if (a[index] < a[index - 1])
            {
                //Create a placeholder so you can get back to the right place once you've "inserted" your element into the right place
                int saveIndex = index;
                //Swap values
                (a[index], a[index - 1]) = (a[index - 1], a[index]);
                //After you make the swap you have to check back through until you hit values that are the same as your current value
                while (index > 1 && a[index - 1] < a[index - 2])
                {
                    index--;
                    (a[index], a[index - 1]) = (a[index - 1], a[index]);
                }
                //make sure you go back to your working index location
                index = saveIndex;
            }
            //Go back through your loop at the next index
            index++;
        }
        //Return the sorted index
        return a;
    }
}

public class Homework79Problem3B
{
    [Fact]
    public void Tests()
    {
        int[] a = { 7, 5, 2, 3, 9, 8, 0, 9, 3, 4, 6, 8, 3, 1, 6, 8, 9, 1, 0, 9, 4, 1, 5, 7, 99, 76, 54, 2, 2, 345, 5 };
        int[] b = { 0, 0, 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 5, 5, 5, 6, 6, 7, 7, 8, 8, 8, 9, 9, 9, 9, 54, 76, 99, 345 };
        Assert.Equal(b, Algorithms.insertionSort(a));
    }
}