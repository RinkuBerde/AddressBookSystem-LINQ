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

            //UC02------->Insert values in Data Table
            contactDataManager.FirstName = "Rinku";
            contactDataManager.LastName = "Berde";
            contactDataManager.PhoneNumber = 1234567890;
            contactDataManager.Email = "rinku@gmail.com";
            contactDataManager.Address = "4,B Block,SP Nagar";
            contactDataManager.City = "Mumbai";
            contactDataManager.State = "MH";
            contactDataManager.zip = 600072;
            dataTableManger.InsertintoDataTable(contactDataManager);

            //Insert Values into Table
            contactDataManagers.FirstName = "Abhi";
            contactDataManagers.LastName = "Mane";
            contactDataManagers.PhoneNumber = 7742905050;
            contactDataManagers.Email = "maneabhi@gmail.com";
            contactDataManagers.Address = "sasthri street";
            contactDataManagers.City = "Pune";
            contactDataManagers.State = "MH";
            contactDataManagers.zip = 123001;
            dataTableManger.InsertintoDataTable(contactDataManagers);
            dataTableManger.Display();

            //UC-03---->Modify
            int varl = dataTableManger.EditDataTable("lalita", "Lastname");
            Console.WriteLine("Success" + varl);
        }
    }
}
    