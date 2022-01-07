using MartianRobots.Core.Helpers;
using MartianRobots.Core.Interfaces;
using MartianRobots.Core.Models;
using NUnit.Framework;
using System;

namespace MartianRobots.Test.Models
{
    [TestFixture]
    public class RobotTests
    {        
        [TestCase(5, 5, 1, 2, 'E')]
        public void SetInitialLocation_IsOk(int maxX, int maxY, int initX, int initY, char initOrientation)
        {
            // Arrange
            var surface = Surface.SurfaceInstance;
            surface.InitSurface(new Position(maxX, maxY));
            var robot = new Robot();
            var location = new LocationRobot(initX, initY, initOrientation);            

            robot.SetInitialLocation(surface, location);

            var position = robot.GetPosition();
            Assert.AreEqual(initX, position.X);
            Assert.AreEqual(initY, position.Y);
            var orientation = robot.GetOrientation();
            Assert.AreEqual(initOrientation, (char)orientation);
            Assert.Pass();
        }

        [TestCase(5, 5, 15, 24, 'E')]
        public void SetInitialLocation_IsNotOk(int maxX, int maxY, int initX, int initY, char initOrientation)
        {
            // Arrange
            var surface = Surface.SurfaceInstance;
            surface.InitSurface(new Position(maxX, maxY));
            var robot = new Robot();
            var location = new LocationRobot(initX, initY, initOrientation);
            
            Assert.Catch<RobotNeedsSurfaceException>(() => { robot.SetInitialLocation(null, location); });
            Assert.Catch<RobotIsLostException>(() => { robot.SetInitialLocation(surface, location); });
            var position = robot.GetPosition();
            Assert.AreNotEqual(initX, position.X);
            Assert.AreNotEqual(initY, position.Y);
            var orientation = robot.GetOrientation();
            Assert.AreEqual(initOrientation, (char)orientation);
            Assert.Pass();
        }
    }
}
