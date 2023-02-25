using AddressBookSystem_LINQ;

namespace ContactManagerMSTesting
{
    [TestClass]
    public class AddressBookTesting
    {
        // UC01------->Create DataTable
        DataTableManager dataTableManger;

        [TestInitialize]
        public void SetUp()
        {
            dataTableManger = new DataTableManager();
        }
        //UC02------->Insert values in Data Table
        [TestMethod]
        [TestCategory("Insert Values in Data Table")]
        public void GivenInsertValues_returnInteger()
        {
            int expected = 2;
            int actual = dataTableManger.AddValues();
            Assert.AreEqual(actual, expected);
        }

        //UC03------->Ability to edit existing contact person using their name
        [TestMethod]
        [TestCategory("Modify Values in Data Table")]
        public void GivenModifyValues_returnInteger()
        {
            int expected = 1;
            int actual = dataTableManger.EditDataTable("Abhi", "Lastname");
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        [TestCategory("Modify Values in Data Table-Negative Test Case")]
        public void GivenWrong_ModifyValues_returnInteger()
        {
            int expected = 0;
            int actual = dataTableManger.EditDataTable("mam", "Lastname");
            Assert.AreEqual(actual, expected);
        }
        //UC-04---->Ability to delete a person using person'sname
        [TestMethod]
        [TestCategory("Delete Row in Data Table")]
        public void GivenDeleteQuery_returnInteger()
        {
            int expected = 1;
            int actual = dataTableManger.DeleteRowInDataTable("Abhi");
            Assert.AreEqual(actual, expected);
        }
        //UC-05----->Retrieve values from DataTable based on City or State
        [TestMethod]
        [TestCategory("Retrieve Row in Data Table based on City ")]
        public void GivenRetrieveQuery_BasedOnCityandState_returnString()
        {
            string expected = "Rinku";
            string actual = dataTableManger.RetrieveBasedOnCityorState("Mumbai", "MH");
            Assert.AreEqual(actual, expected);
        }
        //UC-06----> Retrieve count values from DataTable based on City or State
        [TestMethod]
        [TestCategory("Retrieve Row in Data Table based on City ")]
        public void GivenRetrieveCountQuery_BasedOnCityandState_returnString()
        {
            string expected = "1 2";
            string actual = dataTableManger.RetrieveCountBasedOnCityorState();
            Assert.AreEqual(actual, expected);
        }
    }
}
