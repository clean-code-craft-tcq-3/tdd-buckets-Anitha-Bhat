using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace RangeReader
{

  public class RangeReader
  {
    private static bool isLastCompare(int sampleCount, int currentIndex)
    {
      return sampleCount - 1 == currentIndex + 1;
    }

    [ExcludeFromCodeCoverage]
    public static void Main(string[] args)
    {
      List<int> sampleList = new List<int>
      { 2, 3, 4, 5, 5, 6, 8, 9, 10, 11, 12 };

      HandleRangeReader(sampleList, PrintRangeData);

    }
    public static void HandleRangeReader(List<int> Samples, Action<List<string>> printFunction)
    {
      List<string> rangeList = GetConsecutiveRangeReadings(Samples);
      printFunction(rangeList);
    }

    public static List<string> GetConsecutiveRangeReadings(List<int> Samples)
    {

      if (Samples == null)
      {
        throw new NullReferenceException("value cannot be null");
      }
      List<string> groupRangeList = new List<string>();
      Samples = Samples.OrderBy(item => item).ToList();
      int consecutiveNumTracker = 0;
      for (int i = 0; i < Samples.Count-1; i++)
      {
       
        bool isConsecutive = isConsecutiveNumber(Samples[i], Samples[i + 1]);
        if (isConsecutive)
          consecutiveNumTracker++;
        
        bool checkIfLastCompare = isLastCompare(Samples.Count, i);
        if (isConsecutive && !checkIfLastCompare)
           continue;

        if (consecutiveNumTracker > 0)
        {
          groupRangeList.Add(string.Format("({0}-{1}),{2}", 
            isConsecutive && checkIfLastCompare?Samples[i+1 - consecutiveNumTracker] : Samples[i -consecutiveNumTracker]
                             , 
            isConsecutive && checkIfLastCompare ? Samples[i+1]: Samples[i], consecutiveNumTracker+1));
          consecutiveNumTracker = 0;
        }
      

      }

      return groupRangeList;
    }

    private static bool isConsecutiveNumber(int currentNumber, int nextNumber)
    {
      if (nextNumber - currentNumber == 1 || nextNumber - currentNumber == 0)
      {
        return true;
      }

      return false;

    }
    public static void PrintRangeData(List<string> range)
    {
      range.ForEach(r => Console.WriteLine($"{r}\n"));


    }

  }
}
