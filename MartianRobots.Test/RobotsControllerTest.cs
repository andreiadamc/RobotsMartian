using MartianRobots.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MartianRobots.Test
{
    [TestFixture]
    class RobotsControllerTest
    {
        [TestCase(@"5 3 
1 1 E
RFRFRFRF
3 2 N
FRRFLLFFRRFLL
0 3 W
LLFFFLFLFL")]        
        public void RobotsController_IsOk(string input)
        {
            var robotsController = new RobotsController((s) => { TestContext.Out.WriteLine(s); });
            robotsController.ProcessIncomingScript(input);            
        }
    }
}
