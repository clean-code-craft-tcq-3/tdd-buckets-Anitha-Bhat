using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework.Constraints;

namespace RangeReader
{

  public class RangeReader
  {
    [ExcludeFromCodeCoverage]
    public static void Main(string[] args)
    {
      List<int> sampleList = new List<int> { 3, 3, 5, 4, 10, 11, 12 };

      HandleRangeReader(sampleList, 3, 10, PrintRangeData);

    }
    public static void HandleRangeReader(List<int> Samples,int rangeFrom,int rangeTo,Action<int,int,int> printFunction)
    {
      int numberOfReading=GetNumberOfReading(Samples, rangeFrom, rangeTo);
      printFunction(rangeFrom, rangeTo, numberOfReading);
    }

    public static int GetNumberOfReading(List<int> Samples, int rangeFrom, int rangeTo)
    {
      if (Samples == null)
      {
        throw new NullReferenceException("value cannot be null");
      }
      Samples= Samples.Distinct().OrderBy(item => item).ToList();
      int readingCount = Samples.Where(x => x >= rangeFrom && x <= rangeTo).Count();
     return readingCount;
    }
    

    public static void PrintRangeData(int rangeFrom,int rangeTo,int ReaderCount)
    {
      Console.WriteLine("Range {0}-{1},Reading {2}",rangeFrom,rangeTo,ReaderCount);
    
    }

  }
}
