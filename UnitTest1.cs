namespace iSortProj;

public static class Algorithms
{
    public static int[] insertionSort(int[] a)
    {
        int index = 1;
        while (index < a.Length)
        {
            if (a[index] < a[index - 1])
            {
                indexSwap(a, index);
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
        if (index > 1)
        {
            index--;
            if (a[index] < a[index - 1])
                return indexSwap(a, index);
            else
                return a;
        }
        else
            return a;
    }
}

public class Homework79Problem3B
{
    [Fact]
    public void WhenAddingZeroThenTheResultIsTheStartingValue()
    {
        int[] a = { 7, 5, 2, 3, 9, 8, 0, 9 };
        int[] b = { 0, 2, 3, 5, 7, 8, 9, 9 };
        Assert.Equal(b, Algorithms.insertionSort(a));
    }
}