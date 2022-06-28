using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute.ReceivedExtensions;

namespace RangeReader
    List<int> sampleList = new List<int> { 2, 3, 4, 5, 5, 6, 8, 9, 10, 11, 12 };
{

  public class RangeReaderTest
  {
    List<string> expectedRange = new List<string> { "(2-6),6", "(8-12),5" };
    [Test]
    public void getNumberOfReadingTest()
    {

      var numberOfReading = RangeReader.GetConsecutiveRangeReadings(sampleList);
      Assert.AreEqual(numberOfReading, expectedRange);
      List<int> sampleList1 = new List<int> { -1, 3, 4, 5, 20, 21, 25 };

      List<string> expectedRange1 = new List<string> { "(3-5),3", "(20-21),2" };
      var numberOfReading1 = RangeReader.GetConsecutiveRangeReadings(sampleList1);
      Assert.AreEqual(numberOfReading1, expectedRange1);
      List<int> sampleList2 = new List<int> { -1, 0, 1, 2, 5, 6, 8 };

      List<string> expectedRange2 = new List<string> { "(-1-2),4", "(5-6),2" };
      var numberOfReading2 = RangeReader.GetConsecutiveRangeReadings(sampleList2);
      Assert.AreEqual(numberOfReading2, expectedRange2);
    }


    public void getNumberOfReadingExceptionTest()
    {

      var ex = Assert.Throws<NullReferenceException>(() =>
        RangeReader.HandleRangeReader(new List<int> { }, Substitute.For<Action<List<string>>>()));


    }
    [Test]
    public void HandleRangeReader()
    {

      Action<List<string>> printFunction = Substitute.For<Action<List<string>>>();
      RangeReader.HandleRangeReader(sampleList, printFunction);
      printFunction.Received(1);



    }
    
    public void TestGetConvertedAmpList(){
       Assert.AreEqual(ConvertA2DToAmps(0),0);
       Assert.AreEqual(ConvertA2DToAmps(4095),10);
       Assert.AreEqual(ConvertA2DToAmps(1146),3);
           
    }
    
  }
}
