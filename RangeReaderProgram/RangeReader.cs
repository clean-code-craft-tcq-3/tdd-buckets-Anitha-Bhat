using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace RangeReader
{
  public interface IRangeReader
  {
    void HandleRangeReader(List<int> sortedSamples, int rangeFrom, int rangeTo, Action<int, int, int> printFunction);
    int GetNumberOfReading(List<int> sortedSamples, int rangeFrom, int rangeTo);
    void PrintRangeData(int rangeFrom, int rangeTo, int ReaderCount);

  }
  public class RangeReader: IRangeReader
  {
    public static void Main(string[] args)
    {

    }

    public void HandleRangeReader(List<int> sortedSamples,int rangeFrom,int rangeTo,Action<int,int,int> printFunction)
    {
      throw new Exception("Not implemented");
    }

    public  int GetNumberOfReading(List<int> sortedSamples, int rangeFrom, int rangeTo)
    {
     throw new Exception("Not implemented");
    }
    

    public  void PrintRangeData(int rangeFrom,int rangeTo,int ReaderCount)
    {
      throw new Exception("Not implemented");
    }

  }
}
