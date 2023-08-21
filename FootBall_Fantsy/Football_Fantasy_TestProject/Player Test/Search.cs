using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Fantasy_TestProject.Player_Test
{
    [TestClass]
    public class SearchTests
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
            //Test Players:
            //Lionel Andres messi
            //HAJI Poor ronaldo
            //AlMohammad HAJ Allah neymar
            //mohammad Mahdi JAVADI embappe
            //Kazem Fahimi Saleh
            //Haj Ahmad Beyravand Beyravand

            player1.web_name = "messi";
            player2.web_name = "ronaldo";
            player3.web_name = "neymar";
            player4.web_name = "embappe";
            player5.web_name = "Saleh";
            player6.web_name = "Beyravand";

            player1.first_name = "Lionel";
            player2.first_name = "HAJI";
            player3.first_name = "AlMohammad";
            player4.first_name = "mohammad Mahdi";
            player5.first_name = "Kazem";
            player6.first_name = "Haj Ahmad";

            player1.second_name = "Andres";
            player2.second_name = "Poor";
            player3.second_name = "HAJ Allah";
            player4.second_name = "JAVADI";
            player5.second_name = "Fahimi";
            player6.second_name = "Beyravand";

            TestPlayers.Add(player1);
            TestPlayers.Add(player2);
            TestPlayers.Add(player3);
            TestPlayers.Add(player4);
            TestPlayers.Add(player5);
            TestPlayers.Add(player6);

            //searching "haj mess"
            list1Actual.Add(player2);
            list1Actual.Add(player3);
            list1Actual.Add(player6);
            list1Actual.Add(player1);
            list1Expected = Search.SearchBy(TestPlayers ,"haj mess");

            //searching " beyra "
            list2Actual.Add(player6);
            list2Expected = Search.SearchBy(TestPlayers, " beyra ");
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
            Assert.AreEqual(list1Expected[0].web_name , list1Actual[0].web_name);
        }
        [TestMethod]
        public void TestMethod4()
        {
            Assert.AreEqual(list1Expected[1].web_name, list1Actual[1].web_name);
        }
        [TestMethod]
        public void TestMethod5()
        {
            Assert.AreEqual(list1Expected[2].web_name, list1Actual[2].web_name);
        }
        [TestMethod]
        public void TestMethod6()
        {
            Assert.AreEqual(list1Expected[3].web_name, list1Actual[3].web_name);
        }
        [TestMethod]
        public void TestMethod7()
        {
            Assert.AreEqual(list2Expected[0].web_name, list2Actual[0].web_name);
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
