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
      List<int> sampleList =new List<int> { 2, 3, 4, 5, 5, 6, 8, 9, 10, 11, 12 };
      List<string> expectedRange=new List<string>{"(2-6),6","(8-12),5"};
    [Test]
    public void getNumberOfReadingTest()
    {
      
      var numberOfReading = RangeReader.GetConsecutiveRangeReadings(sampleList);
      Assert.AreEqual(numberOfReading, expectedRange);
    }

    [TestCase(new[]{})]
    public void getNumberOfReadingExceptionTest(List<int> sampleList)
    {
     
        var ex = Assert.Throws<NullReferenceException>(() => RangeReader.GetConsecutiveRangeReadings(sampleList.ToList()));
 
     
    }
    [Test]
    public void HandleRangeReader()
    {
     
      Action<List<string>> printFunction = Substitute.For<Action<List<string>>>();
      RangeReader.HandleRangeReader(sampleList,printFunction);
      printFunction.Received(1);
      Assert.AreEqual(expectedRange, printFunction.ReceivedCalls().First().GetArguments().First());
     

    }
  }
}
