using MartianRobots.Core.Models;
using NUnit.Framework;
using System;

namespace MartianRobots.Test.Models
{
    [TestFixture]
    public class SurfaceTests
    {
        [TestCase(5, 5)]
        [TestCase(55, 55)]
        [TestCase(-1, -1)]
        public void InitSurface_StateUnderTest_ExpectedBehavior(int maxX, int maxY)
        {
            var surface = Surface.SurfaceInstance;            
            try
            {
                surface.InitSurface(new Position(maxX, maxY));
                Assert.Pass();
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.Pass();
            }            
            // Assert
            Assert.Fail();
        }

        [TestCase(5, 5, 2, 3)]
        [TestCase(5, 5, 6, 3)]
        public void IsValidPosition_StateUnderTest_ExpectedBehavior(int maxX, int maxY, int testX, int testY)
        {
            var surface = Surface.SurfaceInstance;
            surface.InitSurface(new Position(maxX, maxY));            
            Assert.AreEqual(testX <= maxX, surface.IsValidPosition(new Position(testX, testY)));
            Assert.AreEqual(testX > maxX, !surface.IsValidPosition(new Position(testX, testY)));
            Assert.Pass();
        }

        [TestCase(5, 5, 4, 3, 4, 3)]
        [TestCase(5, 5, 4, 3, 6, 6)]
        public void TestScentPosition_StateUnderTest_ExpectedBehavior(int maxX, int maxY, int scentX, int scentY, int testX, int testY)
        {
            var surface = Surface.SurfaceInstance;
            surface.InitSurface(new Position(maxX, maxY));
            surface.AddScentPosition(new Position(scentX, scentY));
            surface.AddScentPosition(new Position(maxX, scentY));
            surface.AddScentPosition(new Position(scentX, maxY));
            // Act
            Assert.AreEqual(scentX == testX && scentY == testY, surface.IsScentPosition(new Position(testX, testY)));
            // Assert
            Assert.Pass();
        }        
    }
}
