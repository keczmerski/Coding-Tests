using NUnit.Framework;
using System.Drawing;
using System.Collections.Generic;
using WorldThatIsNotVeryBig;

namespace NUnitTest_SmallWorld
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_GetTheClosestAsString()
        {
            string InputListOfPoints = $"1 0.0, 0.0 {System.Environment.NewLine}2  10.1 -10.1 {System.Environment.NewLine}3 -12.2 12.2{System.Environment.NewLine}4 38.3    38.3{System.Environment.NewLine}5    79.99, 179.99";
            
            string Expected = $"1 2,3,4{System.Environment.NewLine}2 1,3,4{System.Environment.NewLine}3 1,2,4{System.Environment.NewLine}4 1,2,3{System.Environment.NewLine}5 4,3,1";
            PointColection collectionOfPoints = new PointColection(InputListOfPoints);
            Assert.AreEqual(Expected, collectionOfPoints.GetClosestPointsForEachPoint().Trim());
        }
        [Test]
        public void Test_GetTheClosestAsString_WithLessThenEnoughForThreeClosest2()
        {
            string InputListOfPoints = $"1 0.0, 0.0 {System.Environment.NewLine}2  10.1 -10.1";

            string Expected = $"1 2{System.Environment.NewLine}2 1";
            PointColection collectionOfPoints = new PointColection(InputListOfPoints);
            Assert.AreEqual(Expected, collectionOfPoints.GetClosestPointsForEachPoint().Trim());
        }
        [Test]
        public void Test_GetTheClosestAsString_WithLessThenEnoughForThreeClosest3()
        {
            string InputListOfPoints = $"1 0.0, 0.0 {System.Environment.NewLine}2  10.1 -10.1 {System.Environment.NewLine}3 -12.2 12.2";

            string Expected = $"1 2,3{System.Environment.NewLine}2 1,3{System.Environment.NewLine}3 1,2";
            PointColection collectionOfPoints = new PointColection(InputListOfPoints);
            Assert.AreEqual(Expected, collectionOfPoints.GetClosestPointsForEachPoint().Trim());
        }
        [Test]
        public void Test_GetTheClosest()
        {
            Dictionary<int, PointF> ListOfPoints = new Dictionary<int, PointF>
                {
                    { 1, new PointF(0.0F, 0.0F) },
                    { 2, new PointF( 10.1F, -10.1F) },
                    { 3, new PointF(-12.2F, 12.2F) },
                    { 4, new PointF(38.3F, 38.3F ) },
                    { 5, new PointF(79.99F, 179.99F ) }
                };
            Assert.AreEqual(new int[] { 2, 3, 4 }, PointColection.GetTheClosest(ListOfPoints, 1));
            Assert.AreEqual(new int[] { 1, 3, 4 }, PointColection.GetTheClosest(ListOfPoints, 2));
            Assert.AreEqual(new int[] { 1, 2, 4 }, PointColection.GetTheClosest(ListOfPoints, 3));
            Assert.AreEqual(new int[] { 1, 2, 3 }, PointColection.GetTheClosest(ListOfPoints, 4));
            Assert.AreEqual(new int[] { 4, 3, 1 }, PointColection.GetTheClosest(ListOfPoints, 5));
        }

        [Test]
        public void Test_GetClosestPointsForEachPoint()
        {
            Dictionary<int, PointF> ListOfPoints = new Dictionary<int, PointF>
            {
                { 1, new PointF(0.0F, 0.0F) },
                { 2, new PointF( 10.1F, -10.1F) },
                { 3, new PointF(-12.2F, 12.2F) },
                { 4, new PointF(38.3F, 38.3F ) },
                { 5, new PointF(79.99F, 179.99F ) }
            };

            Dictionary<int, int[]> ExpectedResult = new Dictionary<int, int[]>
            {
                {1,new int[]{2,3,4} },
                {2,new int[]{1,3,4} },
                {3,new int[]{1,2,4} },
                {4,new int[]{1,2,3} },
                {5,new int[]{4,3,1} }
            };

            Assert.AreEqual(ExpectedResult, PointColection.GetClosestPointsForEachPoint(ListOfPoints));
        }


    }
}