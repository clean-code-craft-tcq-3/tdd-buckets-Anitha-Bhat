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
    [TestCase(new[] {"(2-6),6","(8-12),5"}, new[]  { 2, 3, 4, 5, 5, 6, 8, 9, 10, 11, 12 };)]
    public void getNumberOfReadingTest(string[] expectedList,int[] sampleList)
    {
      
      var numberOfReading = RangeReader.GetConsecutiveRangeReadings(sampleList.ToList());
      Assert.AreEqual(numberOfReading, expectedList.toList());
    }

    [TestCase(null)]
    public void getNumberOfReadingExceptionTest(List<int> sampleList)
    {
     
        var ex = Assert.Throws<NullReferenceException>(() => RangeReader.GetConsecutiveRangeReadings(sampleList.ToList());
 
     
    }
    [Test]
    public void HandleRangeReader()
    {
      List<int> sampleList = new List<int> { 2, 3, 4, 5, 5, 6, 8, 9, 10, 11, 12 };
      List<string> expecedRange=new List<string>{"(2-6),6","(8-12),5"};
      Action<int, int, int> printFunction = Substitute.For<Action<int, int, int>>();
      RangeReader.HandleRangeReader(sampleList,printFunction);
      printFunction.Received(1);
      Assert.AreEqual(expecedRange, printFunction.ReceivedCalls().First().GetArguments().First());
     

    }
  }
}
