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
    [TestCase(3, 10, 5, new[] { 3, 3, 5, 4, 10, 11, 12 })]
    [TestCase(5, 10, 2, new[] { 3, 3, 5, 4, 10})]
    public void getNumberOfReadingTest(int rangeFrom,int rangeTo,int expectedOutput,int[] sampleList)
    {
      
      var numberOfReading = RangeReader.GetNumberOfReading(sampleList.ToList(), rangeFrom, rangeTo);
      Assert.AreEqual(numberOfReading, expectedOutput);
    }

    [TestCase(0, 1, null)]
    public void getNumberOfReadingExceptionTest(int rangeFrom, int rangeTo,List<int> sampleList)
    {
     
        var ex = Assert.Throws<NullReferenceException>(() => RangeReader.GetNumberOfReading(sampleList, rangeFrom, rangeTo));
 
     
    }
    [Test]
    public void HandleRangeReader()
    {
      List<int> sampleList = new List<int> { 3, 3, 5, 4, 10, 11, 12 };
      Action<int, int, int> printFunction = Substitute.For<Action<int, int, int>>();
      RangeReader.HandleRangeReader(sampleList, 3, 10, printFunction);
      printFunction.Received(1);
      Assert.AreEqual(3, printFunction.ReceivedCalls().First().GetArguments().First());
      Assert.AreEqual(10, printFunction.ReceivedCalls().First().GetArguments()[1]);

    }
  }
}
