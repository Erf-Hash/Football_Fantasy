using FootBall_Fantasy.Data_Access;
using FootBall_Fantasy.Business.Users;
using FootBall_Fantasy.Business.SignUp;

namespace Football_Fantasy_TestProject;

[TestClass]
public class PasswordValidation_Test
{
    [TestMethod]
    public void TestMethod1()
    {
        Assert.AreEqual(false, PasswordValidation.HasCorrectLength("12321"));
    }
    [TestMethod]
    public void TestMethod2()
    {
        Assert.AreEqual(true, PasswordValidation.IsPredictablePattern("125554aaaaa4"));
    }
    [TestMethod]
    public void TestMethod3()
    {
        Assert.AreEqual(false, PasswordValidation.EmptyField("12321"));
    }
    [TestMethod]
    public void TestMethod4()
    {
        Assert.AreEqual(true, PasswordValidation.HasCorrectLength("123245481"));
    }
    [TestMethod]
    public void TestMethod5()
    {
        Assert.AreEqual(true, PasswordValidation.EmptyField(""));
    }
    [TestMethod]
    public void TestMethod6()
    {
        Assert.AreEqual(true, PasswordValidation.ContainsPersonalInformation("MahdiEs82","Mahdi","MES82","mahdi1333@hotmail.com"));
    }
    [TestMethod]
    public void TestMethod7()
    {
        Assert.AreEqual(false, PasswordValidation.ContainsPersonalInformation("MahdiEs82", "Mahdi Esmaili", "ES82", "mahdi1333@hotmail.com"));
    }
    [TestMethod]
    public void TestMethod8()
    {
        Assert.AreEqual(true, PasswordValidation.ContainsPersonalInformation("MahdiEs82", "Mahdi Esmaili", "Es82", "mahdi1333@hotmail.com"));
    }
    [TestMethod]
    public void TestMethod9()
    {
        Assert.AreEqual(true, PasswordValidation.HasAnyUpperCase("Ali"));
    }
    [TestMethod]
    public void TestMethod10()
    {
        Assert.AreEqual(false, PasswordValidation.HasAnyUpperCase("ali"));
    }
    [TestMethod]
    public void TestMethod11()
    {
        Assert.AreEqual(false, PasswordValidation.HasAnyLowerCase("ALI"));
    }
    [TestMethod]
    public void TestMethod12()
    {
        Assert.AreEqual(true, PasswordValidation.HasAnyNumber("ALI6"));
    }
    [TestMethod]
    public void TestMethod13()
    {
        Assert.AreEqual(true, PasswordValidation.HasAnySymbol("=Ali"));
    }
    [TestMethod]
    public void TestMethod14()
    {
        Assert.AreEqual(false, PasswordValidation.HasAnySymbol("MahdiEs"));
    }
    [TestMethod]
    public void TestMethod15()
    {
        Assert.AreEqual(true, PasswordValidation.HasAnySymbol("ALI6.fs83"));
    }
}

[TestClass]
public class NameValidation_Test
{
    [TestMethod]
    public void TestMethodEmptyFied1()
    {
        Assert.AreEqual(true, NameValidation.EmptyField(""));
    }
    [TestMethod]
    public void TestMethodEmptyField2()
    {
        Assert.AreEqual(false, NameValidation.EmptyField("hi"));
    }
    [TestMethod]
    public void TestMethodHasCorrectLength()
    {
        Assert.AreEqual(true, NameValidation.HasCorrectLength("salam"));
    }
}

[TestClass]
public class UserNameValidation_Test
{
    [TestMethod]
    public void TestMethodEmptyFied1()
    {
        Assert.AreEqual(true, UserNameValidation.EmptyField(""));
    }
    [TestMethod]
    public void TestMethodEmptyField2()
    {
        Assert.AreEqual(false, UserNameValidation.EmptyField("hi"));
    }
    [TestMethod]
    public void TestMethodHasCorrectLength1()
    {
        Assert.AreEqual(true, UserNameValidation.HasCorrectLength("salam"));
    }
    [TestMethod]
    public void TestMethodIsDuplicated1()
    {
        using(var testDB = new DataBaseConfiguring())
        {
            User testUser = new User();
            testUser.UserName= "erfanam";
            testDB.users.Add(testUser);
            Assert.AreEqual(true, UserNameValidation.IsDuplicated("erfanam"));
        }
    }
    [TestMethod]
    public void TestMethodIsDuplicated2()
    {
        using (var testDB = new DataBaseConfiguring())
        {
            User testUser = new User();
            testUser.UserName = "erfanam";
            testDB.users.Add(testUser);
            Assert.AreEqual(false, UserNameValidation.IsDuplicated("SensianNoor"));
        }
    }
    [TestMethod]
    public void TestMethodIsValidFormat1()
    {
        Assert.AreEqual(false, UserNameValidation.IsValidFormat("123456"));
    }
    [TestMethod]
    public void TestMethodIsValidFormat2()
    {
        Assert.AreEqual(true, UserNameValidation.IsValidFormat("erfanam"));
    }
    [TestMethod]
    public void TestMethodIsValidFormat3()
    {
        Assert.AreEqual(false, UserNameValidation.IsValidFormat("erfanam h"));
    }
}

[TestClass]
public class EmailValidation_Test
{
    [TestMethod]
    public void TestMethodIsValidFormat1()
    {
        Assert.AreEqual(false, EmailValidation.IsValidFormat("hola"));
    }
    [TestMethod]
    public void TestMethodIsValidFormat2()
    {
        Assert.AreEqual(false, EmailValidation.IsValidFormat("12364653"));
    }
    [TestMethod]
    public void TestMethodIsValidFormat3()
    {
        Assert.AreEqual(false, EmailValidation.IsValidFormat("gang@holyCow"));
    }
    [TestMethod]
    public void TestMethodIsValidFormat5()
    {
        Assert.AreEqual(true, EmailValidation.IsValidFormat("erfan@ham.co.uk"));
    }
    [TestMethod]
    public void TestMethodIsValidFormat6()
    {
        Assert.AreEqual(true, EmailValidation.IsValidFormat("erfanam@erfan.org"));
    }
    [TestMethod]
    public void TestMethodIsValidFormat7()
    {
        Assert.AreEqual(false, EmailValidation.IsValidFormat(""));
    }
    [TestMethod]
    public void TestMethodIsDuplicated1()
    {
        using (var testDB = new DataBaseConfiguring())
        {
            User testUser = new User();
            testUser.Email = "erfanam@gmail.com";
            testDB.users.Add(testUser);
            Assert.AreEqual(true, EmailValidation.IsDuplicated("erfanam@gmail.com"));
        }
    }
    [TestMethod]
    public void TestMethodIsDuplicated2()
    {
        using (var testDB = new DataBaseConfiguring())
        {
            User testUser = new User();
            testUser.Email = "erfanam@gmail.com";
            testDB.users.Add(testUser);
            Assert.AreEqual(true, EmailValidation.IsDuplicated("erfanam@gmail.com"));
        }
    }
}

[TestClass]
public class ConnectSignUpMethodsTest
{
    [TestMethod]
    public void TestIsValidationsCorrect()
    {
        Assert.AreEqual(true, BusinessSignUp.SignUpValidation("erfanam@gmail.com", "salam", "ALI6.fs83", "12321"));
    }
}