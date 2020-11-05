using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBookSystem;

namespace AddressBookDBTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenDataFromDatabase_RetrievedData()
        {
            ContactDatabase expected = new ContactDatabase()
            {
                firstname = "Shakira",
                lastname = "Shamina",
                city = "Mumbai",
                phone = "7452166",
                B_Name = "Book1",
                B_Type = "Family"
            };
            var actual = AddressBookRepo.GetAllContacts();

            Assert.AreEqual(expected.firstname, actual.firstname);
            Assert.AreEqual(expected.lastname, actual.lastname);
            Assert.AreEqual(expected.city, actual.city);
            Assert.AreEqual(expected.phone, actual.phone);
            Assert.AreEqual(expected.B_Name, actual.B_Name);
            Assert.AreEqual(expected.B_Type, actual.B_Type);

        }
        [TestMethod]
        public void GivenUpdate_ShouldBeUpdateInDatabase()
        {
            string expected = "California";

            string actual = AddressBookRepo.UpdateDatabase();

            Assert.AreEqual(expected, actual);
        }
    }
}
