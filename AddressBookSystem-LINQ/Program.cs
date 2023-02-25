namespace AddressBookSystem_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To AddressBook System Using LINQ");
            //UC-01----->Create Object for DataTable
            ContactDataManager contactDataManager = new ContactDataManager();
            ContactDataManager contactDataManagers = new ContactDataManager();
            DataTableManager dataTableManger = new DataTableManager();
            dataTableManger.CreateDataTable();
        }
    }
}