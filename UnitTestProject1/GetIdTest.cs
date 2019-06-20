using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjektProgramowaniew59051.Klasy;

namespace UnitTestProject1
{
    [TestClass]
    public class GetIdTest
    {
        [TestMethod]
        public void TestMethodGetIdUser()
        {
            string nazwisko = "Nowak";
            int actual;  
            actual=GetId.GetIdUser(nazwisko);
            int expected = 0;
            Assert.AreEqual(expected, actual, 0.0001, "Wartosc inna niz spodziewana");
        }

        [TestMethod]
        public void TestMethodGetIdDepartment()
        {
            string dzial = "Testy";
            int actual;
            actual = GetId.GetIdDepartment(dzial);
            int expected = 1;
            Assert.AreEqual(expected, actual, 0.0001, "Wartosc inna niz spodziewana");
        }
        [TestMethod]
        public void TestMethodGetIdTask()
        {
            string opis = "Opis";
            int actual;
            actual = GetId.GetIdTask(opis);
            int expected = 0;
            Assert.AreEqual(expected, actual, 0.0001, "Wartosc inna niz spodziewana");
        }
        [TestMethod]
        public void TestMethodLogin()
        {

            bool success;
            success = Authentication.Login("Nowak", "haslo");
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void TestMethodLoginAdmin()
        {
            bool success;
            success = Authentication.LoginAdmin("Admin","maslo");
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void TestMethodInsertZadania()
        {
            
            InsertUpdate.InsertZadania("123", 0, 0, "Zadanie testowe", "200", "2019-08-22");
            

            
        }
        [TestMethod]
        public void TestMethodZamknijZadanie()
        {
            InsertUpdate.ZamknijZadanie(123,"2019-06-14");
        }
    }

    
    
        
    
}
