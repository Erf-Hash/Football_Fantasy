using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Fantasy_TestProject.Player_Test
{
    [TestClass]
    public class PlayerManipulationTest
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

            player1.element_type = (int)Filter.Position.Defenders;
            player2.element_type = (int)Filter.Position.Goalkeepers;
            player3.element_type = (int)Filter.Position.Goalkeepers;
            player4.element_type = (int)Filter.Position.Forwards;
            player5.element_type = (int)Filter.Position.Midfielders;
            player6.element_type = (int)Filter.Position.Forwards;

            player1.now_cost = 12;
            player2.now_cost = 15;
            player3.now_cost = 20;
            player4.now_cost = 8;
            player5.now_cost = 17;
            player6.now_cost = 10;

            TestPlayers.Add(player1);
            TestPlayers.Add(player2);
            TestPlayers.Add(player3);
            TestPlayers.Add(player4);
            TestPlayers.Add(player5);
            TestPlayers.Add(player6);

            // search = "ha" : 2 3 4 6
            // filter = Forward  : 4 6
            // sort = descending cost : 6 4
            // page = 2 length = 1  : 4
            var p1 = new PlayersManipulation(/*TestPlayers,*/ "ha", Sort.SortType.CostSort, Sort.SortOrder.Descending, Filter.Position.Forwards, 2, 1);
            list1Expected = p1.GetManipulatedPlayers();
            list1Actual = new List<Player>() { player4 };
        }
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(list1Expected.Count, list1Actual.Count);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(list1Expected[0].web_name, list1Actual[0].web_name);
        }
        [TestMethod]
        public void TestMethod3()
        {
            
        }
        [TestMethod]
        public void TestMethod4()
        {
            
        }
        [TestMethod]
        public void TestMethod5()
        {
            
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
