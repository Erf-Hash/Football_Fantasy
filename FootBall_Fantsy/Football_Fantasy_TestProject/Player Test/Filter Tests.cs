using FootBall_Fantasy.Business.Players;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Fantasy_TestProject.Player_Test
{
    [TestClass]
    public class FilterTests
    {
        public static List<Player> TestPlayers = new List<Player>();
        public static Player player1 = new Player();
        public static Player player2 = new Player();
        public static Player player3 = new Player();
        public static Player player4 = new Player();
        public static Player player5 = new Player();
        public static Player player6 = new Player();
        public static List<Player> list1Expected = new List<Player>();
        public static List<Player> list1Actual = new List<Player>();
        public static List<Player> list2Expected = new List<Player>();
        public static List<Player> list2Actual = new List<Player>();
        public static bool isInitialize = false;
        [TestInitialize]
        public void Initialize()
        {
            if (!isInitialize)
            {
                CreatePlayerList();
                isInitialize = true;
            }
        }
        public static void CreatePlayerList()
        {
            player1.web_name = "messi";
            player2.web_name = "ronaldo";
            player3.web_name = "neymar";
            player4.web_name = "embappe";
            player5.web_name = "Ali shafiee";
            player6.web_name = "beyravand";
            player1.element_type = 1;
            player2.element_type = 2;
            player3.element_type = 3;
            player4.element_type = 4;
            player5.element_type = 4;
            player6.element_type = 3;
            TestPlayers.Add(player1);
            TestPlayers.Add(player2);
            TestPlayers.Add(player3);
            TestPlayers.Add(player4);
            TestPlayers.Add(player5);
            TestPlayers.Add(player6);
            
            list1Actual.Add(player4);
            list1Actual.Add(player5);
            list1Expected = Filter.FilterByPositionAndTeam(TestPlayers ,Filter.Position.Forwards);

            list2Actual.Add(player1);
            list2Expected = Filter.FilterByPositionAndTeam(TestPlayers, Filter.Position.Goalkeepers);
        }
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(list1Actual[1].web_name , list1Expected[1].web_name);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(list1Actual[0].web_name, list1Expected[0].web_name);
        }
        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual(list2Actual[0].web_name, list2Expected[0].web_name);
        }
        [TestMethod]
        public void TestMethod4()
        {
            Assert.AreEqual(list1Expected.Count , 2);
        }
        [TestMethod]
        public void TestMethod5()
        {
            Assert.AreEqual(list2Expected.Count, 1);
        }
        [TestMethod]
        public void TestMethod6()
        {

        }
        [TestMethod]
        public void TestMethod7()
        {

        }
        [TestMethod]
        public void TestMethod8()
        {

        }
        [TestMethod]
        public void TestMethod9()
        {

        }
        [TestMethod]
        public void TestMethod10()
        {

        }
    }
}
