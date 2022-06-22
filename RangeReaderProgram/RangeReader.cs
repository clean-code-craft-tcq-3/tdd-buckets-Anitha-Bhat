using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace RangeReader
{

  public class RangeReader
  {
    public static int consecutiveNumTracker = 0;
    [ExcludeFromCodeCoverage]
    public static void Main(string[] args)
    {
      List<int> sampleList = new List<int>
      { 2, 3, 5,4, 5, 6, 8, 9, 10, 11, 12 };

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

    private static bool isLastNumbersConsecutive(List<int> samples,int currentIndex)
    {
      return isConsecutiveNumber(samples[currentIndex], samples[currentIndex + 1]) && isLastCompare(samples.Count, currentIndex);
    }

    private static bool isNumbersAreNotAtLastAndConsecutive(List<int> samples, int currentIndex)
    {
      return isConsecutiveNumber(samples[currentIndex], samples[currentIndex + 1]) && !isLastCompare(samples.Count, currentIndex);
    }

    private static List<int> sortSamples(List<int> samples)
    {
     return samples.OrderBy(item => item).ToList();
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
      validateSamples(Samples);
      Samples=sortSamples(Samples);
      List<string> rangeList = GetConsecutiveRangeReadings(Samples);
      printFunction(rangeList);
    }




    public static List<string> GetConsecutiveRangeReadings(List<int> Samples)
    {
      consecutiveNumTracker = 0;

      List<string> groupRangeList = new List<string>();
      for (int i = 0; i < Samples.Count - 1; i++)
      {
        updateRangeReader(groupRangeList, Samples, i);
      }
      return groupRangeList;
    }

    private static void updateRangeReader(List<string> rangeList, List<int> Samples, int index)
    {
      if (isConsecutiveNumber(Samples[index], Samples[index + 1]))
        consecutiveNumTracker++;
      if (isNumbersAreNotAtLastAndConsecutive(Samples,index))
        return;
      if (consecutiveNumTracker > 0)
      {
        rangeList.Add(GetFormatedString(Samples, index));
        consecutiveNumTracker = 0;
      }
    }

    private static string GetFormatedString(List<int> samples, int currentIndex)
    {
      bool isLastNumConsecutive = isLastNumbersConsecutive(samples, currentIndex);
      return string.Format("({0}-{1}),{2}",
        isLastNumConsecutive ? samples[currentIndex + 1 - consecutiveNumTracker] : samples[currentIndex - consecutiveNumTracker]
        ,
        isLastNumConsecutive ? samples[currentIndex + 1] : samples[currentIndex], consecutiveNumTracker + 1);

    }

    public static void PrintRangeData(List<string> range)
    {
      range.ForEach(r => Console.WriteLine($"{r}\n"));
    }

  }
}
