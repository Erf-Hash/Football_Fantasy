using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Fantasy_TestProject.Player_Test
{
    [TestClass]
    public class PaginationTests
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

            TestPlayers.Add(player1);
            TestPlayers.Add(player2);
            TestPlayers.Add(player3);
            TestPlayers.Add(player4);
            TestPlayers.Add(player5);
            TestPlayers.Add(player6);

            // page = 2 , length = 3
            list1Actual.Add(player4);
            list1Actual.Add(player5);
            list1Actual.Add(player6);
            list1Expected = Pagination.PaginationBy(TestPlayers, 2 , 3);

            // page = 2 , length = 4
            list2Actual.Add(player5);
            list2Actual.Add(player6);
            list2Expected = Pagination.PaginationBy(TestPlayers, 2, 4);
        }
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(list1Expected.Count, list1Actual.Count);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(list2Expected.Count, list2Actual.Count);
        }
        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual(list1Expected[0].web_name , list1Actual[0].web_name );
        }
        [TestMethod]
        public void TestMethod4()
        {
            Assert.AreEqual(list1Expected[1].web_name , list1Actual[1].web_name);
        }
        [TestMethod]
        public void TestMethod5()
        {
            Assert.AreEqual(list1Expected[2].web_name, list1Actual[2].web_name);
        }
        [TestMethod]
        public void TestMethod6()
        {
            Assert.AreEqual(list2Expected[0].web_name, list2Actual[0].web_name);
        }
        [TestMethod]
        public void TestMethod7()
        {
            Assert.AreEqual(list2Expected[1].web_name, list2Actual[1].web_name);
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
