using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute.ReceivedExtensions;

namespace RangeReader
{

  public class RangeReaderTest
  {
    [Test]
   public void getNumberOfReadingTest()
    {
      List<int> sampleList = new List<int> { 3, 3, 5, 4, 10, 11, 12 };
      RangeReader reader = new RangeReader();
      int numberOfReading = reader.GetNumberOfReading(sampleList, 3, 10);
      Assert.AreEqual(numberOfReading, 4);
    }

    [Test]
    public void HandleRangeReader()
    {
      List<int> sampleList = new List<int> { 3, 3, 5, 4, 10, 11, 12 };
      Action<int, int, int> printFunction = Substitute.For<Action<int, int, int>>();
      var iRangeReader = Substitute.For<IRangeReader>();
      RangeReader reader = new RangeReader();
      reader.HandleRangeReader(sampleList, 3, 10, printFunction);
      printFunction.Received(1);
      iRangeReader.Received(1).GetNumberOfReading(sampleList, 3, 10);
      Assert.AreEqual(3, printFunction.ReceivedCalls().First().GetArguments().First());
      Assert.AreEqual(10, printFunction.ReceivedCalls().First().GetArguments()[1]);

    }
  }
}
