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
    }
}
