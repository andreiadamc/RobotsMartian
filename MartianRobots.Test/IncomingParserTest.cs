using MartianRobots.Core.CommandPlugin;
using MartianRobots.Core.Helpers;
using MartianRobots.Core.Models;
using MartianRobots.Core.Parser.Models;
using NUnit.Framework;
using System;

namespace MartianRobots.Test
{
    [TestFixture]
    public class IncomingParserTest
    {        
        [TestCase("5 3")]        
        public void TopLineParser_IsOk(string inputText)
        {
            var topLine = new TopLineCommand();
            topLine.Deserialize(inputText);
            Assert.AreEqual(5, topLine.LimitX);
            Assert.AreEqual(3, topLine.LimitY);
            Assert.Pass();
        }

        [TestCase("666 -1")]
        public void TopLineParser_IsNotOk(string inputText)
        {
            var topLine = new TopLineCommand();
            Assert.Catch(typeof(ValidationRobotCommandException), () => { topLine.Deserialize(inputText); });
            Assert.Pass();
        }

        [TestCase("1 1 E")]
        public void FirstLineParser_IsOk(string inputText)
        {
            var firstLine = new FirstLineCommand();
            firstLine.Deserialize(inputText);
            Assert.AreEqual(1, firstLine.OriginX);
            Assert.AreEqual(1, firstLine.OriginY);
            Assert.AreEqual('E', firstLine.Orientation);
            Assert.Pass();
        }

        [TestCase("555 -221 A")]
        [TestCase("   F")]
        public void FirstLineParser_IsNotOk(string inputText)
        {
            var firstLine = new FirstLineCommand();
            try
            {
                firstLine.Deserialize(inputText);
            }
            catch (Exception e)
            {
                TestContext.Out.WriteLine(e.Message);
                Assert.Pass();
            }                        
        }

        [TestCase(@"5 3 
1 2 E
RFRFRFRF")]
        public void WholeParserTest_IsOk(string inputText)
        {
            var plugins = new CommandPlugins();
            
            plugins.AddPlugin<RobotLeftInstruction>();
            plugins.AddPlugin<RobotRightInstruction>();
            plugins.AddPlugin<RobotForwardInstruction>();

            Assert.Throws<InvalidCastException>(() =>
                {
                    plugins.AddPlugin<Robot>();
                });

            var commandBunch = new CommandBunch(inputText, plugins);
            Assert.AreEqual(5, commandBunch.TopLineCommand.LimitX);
            Assert.AreEqual(3, commandBunch.TopLineCommand.LimitY);
            Assert.AreEqual(1, commandBunch.RobotCommandPackages.Count);
            foreach (var item in commandBunch.RobotCommandPackages)
            {
                Assert.AreEqual('E', item.FirstLineCommand.Orientation);
                Assert.AreEqual(1, item.FirstLineCommand.OriginX);
                Assert.AreEqual(2, item.FirstLineCommand.OriginY);
                Assert.AreEqual(8, item.SecondLineCommands.CommandQueue.Count);
                var isOdd = true;
                foreach (var itemCommand in item.SecondLineCommands.CommandQueue)
                {
                    if (isOdd)
                    {
                        Assert.AreEqual('R', itemCommand);
                    }
                    else
                    {
                        Assert.AreEqual('F', itemCommand);
                    }
                    isOdd = !isOdd;
                }
            }
            Assert.Pass();
        }
    }
}