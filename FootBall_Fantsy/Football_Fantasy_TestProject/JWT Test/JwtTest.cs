using Microsoft.VisualStudio.TestTools.UnitTesting;
using FootBall_Fantasy.Business.JWT;
using FootBall_Fantasy.Business.Users;

namespace Football_Fantasy_TestProject;

[TestClass]
public class JwtTest
{
    [TestMethod]
    public void TestMethod1()
    {
        string a = JWT.GenerateToken(new User("Erfan", "Erfan@gmail.com", "123456789", 999, "Erfanam", 100, 100));
        Assert.AreEqual(999, JWT.ValidateToken(a));
    }
    [TestMethod]
    public void TestMethod2()
    {
        string a = JWT.GenerateToken(new User("Erfan", "Erfan@gmail.com", "123456789", 999, "Erfanam", 100, 100));
        Assert.AreEqual(a, JWT.GenerateToken(new User("Erfan", "Erfan@gmail.com", "123456789", 999, "Erfanam", 100, 100)));
    }
}