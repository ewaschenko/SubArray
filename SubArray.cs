public int FindShortestSubArray(int[] nums)
{
    // The solution we discussed:
    // - Create HashMap to store frequency of each element
    // - Create HashSet to store which elements shared the highest frequency
    // - Double For loop using left and right pointer to find all subarrays that have the same degree
    // - This For loop is O(n^2) and can be improved to O(n)

    // HashMap to store elements along with a List with all the indexes it occurs
    Dictionary<int, List<int>> frequency = new Dictionary<int, List<int>>();

    int degree = 0;
    int minLength = Int32.MaxValue;

    for (int i = 0; i < nums.Length; i++)
    {
        // If element occurs in Map then add its current index
        if (frequency.ContainsKey(nums[i]))
        {
            frequency[nums[i]].Add(i);
        }
        else
        {
            // If element does not occur in Map then add element along with current index
            List<int> init = new List<int>();
            init.Add(i);

            frequency.Add(nums[i], init);
        }
    }

    foreach (var element in frequency)
    {
        // If this element has a higher degree
        if (element.Value.Count() > degree)
        {
            // Update degree, reset min length to the length of the sub array
            degree = element.Value.Count();
            minLength = element.Value[element.Value.Count() - 1] - element.Value[0] + 1;
        }
        else if (element.Value.Count() == degree)
        {
            // If this element has the same degree then see if its sub array is smaller
            minLength = Math.Min(minLength, element.Value[element.Value.Count() - 1] - element.Value[0] + 1);
        }
    }

    return minLength;
}