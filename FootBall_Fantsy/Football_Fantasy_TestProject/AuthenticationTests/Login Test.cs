using FootBall_Fantasy.Data_Access;
using FootBall_Fantasy.Business.Users;
using FootBall_Fantasy.Business.Login;

namespace Football_Fantasy_TestProject;

[TestClass]
public class LoginTest
{
    [TestMethod]
    public void TestMethod1()
    {
        Assert.IsFalse(Login.CheckCredential("reza", "reza"));
    }
    [TestMethod]
    public void TestMethod2()
    {
        using (var Db = new DataBaseConfiguring())
        {
            Db.users.Add(new User("Erfan", "Erfan@gmail.com", "123456789", 999, "Erfanam", 100, 100));
            Assert.IsTrue(Login.CheckCredential("Erfanam", "123456789"));
        }
    }
    [TestMethod]
    public void TestMethod3()
    {
        using (var Db = new DataBaseConfiguring())
        {
            Db.users.Add(new User("Erfan", "Erfan@gmail.com", "123456789", 999, "Erfanam", 100, 100));
            Assert.IsTrue(Login.CheckCredential("Erfan@gmail.com", "123456789"));
        }
    }
    [TestMethod]
    public void TestMethod4()
    {
        using (var Db = new DataBaseConfiguring())
        {
            Db.users.Add(new User("Erfan", "Erfan@gmail.com", "123456789", 999, "Erfanam", 100, 100));
            Assert.IsFalse(Login.CheckCredential("Erfan@gmail.com", "12345678910"));
        }
    }
    [TestMethod]
    public void TestMethod5()
    {
        using (var Db = new DataBaseConfiguring())
        {
            Db.users.Add(new User("Erfan", "Erfan@gmail.com", "123456789", 999, "Erfanam", 100, 100));
            Assert.IsFalse(Login.CheckCredential("Erfanam", "12345678910"));
        }
    }
}