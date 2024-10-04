namespace iSortProj;
//Harrison Cook
//Solo Project 1 - Iterative Sorting
public static class Algorithms
{
    public static int[] makeRandomArray(int a) //handy method to make an array as long or short as you'd like
    {
        int[] j = new int[a];

        Random rnd = new Random();

        for (int l = 0; l < a; l++)
        {
            j[l] = rnd.Next(0, 101);
        }

        return j;
    }

    public static int[] InsertionSort(int[] a)
    {
        int index = 1;
        int saveIndex = index;
        while (index < a.Length)
        {
            if (a[index] < a[index - 1])
            {
                (a[index], a[index - 1]) = (a[index - 1], a[index]);
                while (index > 1 && a[index - 1] < a[index - 2])
                {
                    index--;
                    (a[index], a[index - 1]) = (a[index - 1], a[index]);
                }
            }
            index = saveIndex++;
        }
        return a;
    }


    public static int[] SelectionSort(int[] a)
    {
        for (int index = 0; index < a.Length; index++) //run through the array
        {
            int minIndex = FindMin(a, index);

            (a[index], a[minIndex]) = (a[minIndex], a[index]);
        }

        return a;
    }

    private static int FindMin(int[] a, int index)
    {
        int min = a[index]; // assume the start is the smallest

        int minIndex = index; //store the starting value

        for (int b = index + 1; b < a.Length; b++) //check the next value and every subsequent value
        {
            if (a[b] < min) //if any of those subsequent values are smaller, store that value and location, then continue comparing from there.
            {
                min = a[b];

                minIndex = b;
            }
        }

        return minIndex; //return the sorted list
    }

    public static int[] SlowerSelectionSort(int[] a)
    {
        for (int index = 0; index < a.Length; index++) //run through the array
        {
            int minIndex = FindMinShortCircuit(a, index);

            (a[index], a[minIndex]) = (a[minIndex], a[index]);
        }

        return a;
    }

    private static int FindMinShortCircuit(int[] a, int index)
    {
        if (index == 0)
            return FindMin(a, index);

        int runningMin = a[index - 1]; //store the previous value as a "running min" to make sure you can skip repeating numbers

        int min = a[index]; // assume the start is the smallest

        int minIndex = index; //store the starting value

        for (int b = index; b < a.Length; b++) //check the next value and every subsequent value
        {
            if (a[b] <= min) //if any of those subsequent values are smaller, store that value and location, then continue comparing from there.
            {
                if (a[b] == runningMin)
                    return b; //but if you run into a number and you know you won't find a smaller one, break out and stop looking

                min = a[b];

                minIndex = b;
            }
        }

        return minIndex; //return the sorted list
    }
}

public class Homework79Problem3B
{
    [Fact]
    public void Tests()
    {
        int[] x = Algorithms.makeRandomArray(20000);
        int[] a =
        {
            7,
            5,
            2,
            3,
            9,
            8,
            0,
            9,
            3,
            4,
            6,
            8,
            3,
            1,
            6,
            8,
            9,
            1,
            0,
            9,
            4,
            1,
            5,
            7,
            99,
            76,
            54,
            2,
            2,
            345,
            5,
        };
        int[] b =
        {
            0,
            0,
            1,
            1,
            1,
            2,
            2,
            2,
            3,
            3,
            3,
            4,
            4,
            5,
            5,
            5,
            6,
            6,
            7,
            7,
            8,
            8,
            8,
            9,
            9,
            9,
            9,
            54,
            76,
            99,
            345,
        };
        Assert.Equal(b, Algorithms.InsertionSort(a));
        Assert.Equal(Algorithms.InsertionSort(x), Algorithms.SelectionSort(x));
    }
}
