namespace iSortProj;

public static class Algorithms
{
    // I messed around with this quite a bit, and I think it's tail call optimized, I'm writing this as I run a test with a 500,000 int long array.
    // IT WORKS!!! The 500,000 long array takes like 10 min, but it works for the assignment. I'm going to submit some code that's just showy for the assignment, maybe 50,000 long.
    public static int[] insertionSort(int[] a)
    {
        int index = 1;
        while (index < a.Length)
        {
            if (a[index] < a[index - 1])
            {
                int saveIndex = index;
                indexSwap(a, index);
                while (index > 1)
                {
                    index--;
                    if (a[index] < a[index - 1])
                        indexSwap(a, index);
                }
                index = saveIndex;
            }
            index++;
        }
        return a;
    }
    public static int[] indexSwap(int[] a, int index)
    {
        int tempStore = a[index];
        a[index] = a[index - 1];
        a[index - 1] = tempStore;
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