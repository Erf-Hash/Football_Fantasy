using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Fantasy_TestProject.Player_Test
{

    [TestClass]
    public class SortTests
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
            player1.now_cost = 25;
            player2.now_cost = 12;
            player3.now_cost = 30;
            player4.now_cost = 5;
            player5.now_cost = 18;
            player6.now_cost = 40;
            TestPlayers.Add(player1);
            TestPlayers.Add(player2);
            TestPlayers.Add(player3);
            TestPlayers.Add(player4);
            TestPlayers.Add(player5);
            TestPlayers.Add(player6);

            list1Actual.Add(player4);
            list1Actual.Add(player2);
            list1Actual.Add(player5);
            list1Actual.Add(player1);
            list1Actual.Add(player3);
            list1Actual.Add(player6);
            list1Expected = Sort.SortBy(TestPlayers , Sort.SortType.CostSort);

            list2Actual.Add(player2);
            list2Actual.Add(player3);
            list2Actual.Add(player1);
            list2Actual.Add(player4);
            list2Actual.Add(player6);
            list2Actual.Add(player5);
            list2Expected = Sort.SortBy(TestPlayers, Sort.SortType.WebName, Sort.SortOrder.Descending);
        }
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(list1Actual[0] , list1Expected[0]);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(list1Actual[1], list1Expected[1]);
        }
        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual(list1Actual[2], list1Expected[2]);
        }
        [TestMethod]
        public void TestMethod4()
        {
            Assert.AreEqual(list1Actual[3], list1Expected[3]);
        }
        [TestMethod]
        public void TestMethod5()
        {
            Assert.AreEqual(list1Actual[4], list1Expected[4]);
        }
        [TestMethod]
        public void TestMethod6()
        {
            Assert.AreEqual(list1Actual[5], list1Expected[5]);
        }
        [TestMethod]
        public void TestMethod7()
        {
            Assert.AreEqual(list2Actual[0], list2Expected[0]);
        }
        [TestMethod]
        public void TestMethod8()
        {
            Assert.AreEqual(list2Actual[1], list2Expected[1]);
        }
        [TestMethod]
        public void TestMethod9()
        {
            Assert.AreEqual(list2Actual[2], list2Expected[2]);
        }
        [TestMethod]
        public void TestMethod10()
        {
            Assert.AreEqual(list2Actual[3], list2Expected[3]);
        }
        [TestMethod]
        public void TestMethod11()
        {
            Assert.AreEqual(list2Actual[4], list2Expected[4]);
        }
        [TestMethod]
        public void TestMethod12()
        {
            Assert.AreEqual(list2Actual[5], list2Expected[5]);
        }
        [TestMethod]
        public void TestMethod13()
        {
            Assert.AreEqual(list2Expected.Count , 6);
        }
    }
}
