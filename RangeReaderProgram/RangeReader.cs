using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace RangeReader
{

  public class RangeReader
  {
    public static int consecutiveNumTracker=0;
    [ExcludeFromCodeCoverage]
    public static void Main(string[] args)
    {
      List<int> sampleList = new List<int>
      { 2, 3, 4, 5, 5, 6, 8, 9, 10, 11, 12 };

      HandleRangeReader(sampleList, PrintRangeData);

    }

    private static bool isConsecutiveNumber(int currentNumber, int nextNumber)
    {
      return nextNumber - currentNumber == 1 || nextNumber - currentNumber == 0;
    }

    private static bool isLastCompare(int sampleCount, int currentIndex)
    {
      return sampleCount - 1 == currentIndex + 1;
    }

    public static void validateSamples(List<int> Samples)
    {
      if (Samples == null)
      {
        throw new NullReferenceException("value cannot be null");
      }
    }

    public static void HandleRangeReader(List<int> Samples, Action<List<string>> printFunction)
    {
     
      List<string> rangeList = GetConsecutiveRangeReadings(Samples);
      printFunction(rangeList);
    }


  

    public static List<string> GetConsecutiveRangeReadings(List<int> Samples)
    {
      consecutiveNumTracker = 0;

      validateSamples(Samples);

      Samples = Samples.OrderBy(item => item).ToList();

      List<string> groupRangeList = new List<string>();
      for (int i = 0; i < Samples.Count-1; i++)
      {
        updateRangeList(groupRangeList, Samples, i);
      }
      return groupRangeList;
    }

    private static void updateRangeList(List<string> rangeList,List<int> Samples, int index)
    {
      bool isConsecutive = isConsecutiveNumber(Samples[index], Samples[index + 1]);
      if (isConsecutive)
        consecutiveNumTracker++;
      bool checkIfLastCompare = isLastCompare(Samples.Count, index);
      if (isConsecutive && !checkIfLastCompare)
        return;

      if (consecutiveNumTracker > 0)
      {
        rangeList.Add(string.Format("({0}-{1}),{2}",
          isConsecutive && checkIfLastCompare ? Samples[index + 1 - consecutiveNumTracker] : Samples[index - consecutiveNumTracker]
          ,
          isConsecutive && checkIfLastCompare ? Samples[index + 1] : Samples[index], consecutiveNumTracker + 1));
        consecutiveNumTracker = 0;
      }

    }
    public static void PrintRangeData(List<string> range)
    {
      range.ForEach(r => Console.WriteLine($"{r}\n"));
    }

  }
}
