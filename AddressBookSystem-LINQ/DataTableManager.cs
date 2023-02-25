using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem_LINQ
{
    public class DataTableManager
    {
        // UC01------->Create DataTable
        DataTable custTable;
        //Create Column in Datatable
        public void CreateDataTable()
        {
            custTable = new DataTable("AddressBookSystem");
            DataColumn dtColumn;

            // Create id column  
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(Int32);
            dtColumn.ColumnName = "Contactid";
            dtColumn.Caption = "Contact ID";
            dtColumn.AutoIncrement = true;
            dtColumn.ReadOnly = false;
            dtColumn.Unique = true;
            // Add column to the DataColumnCollection.  
            custTable.Columns.Add(dtColumn);

            // Create FirstName column.    
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "FirstName";
            dtColumn.Caption = "First Name";
            dtColumn.AutoIncrement = false;
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            /// Add column to the DataColumnCollection.  
            custTable.Columns.Add(dtColumn);

            // Create LastName column.    
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "LastName";
            dtColumn.Caption = "Last Name";
            dtColumn.AutoIncrement = false;
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            /// Add column to the DataColumnCollection.  
            custTable.Columns.Add(dtColumn);

            // Create Address column.    
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "Address";
            dtColumn.Caption = "Address";
            dtColumn.AutoIncrement = false;
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            /// Add column to the DataColumnCollection.  
            custTable.Columns.Add(dtColumn);

            // Create City column.    
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "City";
            dtColumn.Caption = "City";
            dtColumn.AutoIncrement = false;
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            /// Add column to the DataColumnCollection.  
            custTable.Columns.Add(dtColumn);

            // Create State column.    
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "State";
            dtColumn.Caption = "State";
            dtColumn.AutoIncrement = false;
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            /// Add column to the DataColumnCollection.  
            custTable.Columns.Add(dtColumn);

            // Create Email column.    
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "Email";
            dtColumn.Caption = "Email";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            // Add column to the DataColumnCollection.    
            custTable.Columns.Add(dtColumn);

            // Create PhoneNumber column.    
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(Int64);
            dtColumn.ColumnName = "PhoneNumber";
            dtColumn.Caption = "PhoneNumber";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            // Add column to the DataColumnCollection.    
            custTable.Columns.Add(dtColumn);

            // Create Zip column.    
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(Int64);
            dtColumn.ColumnName = "Zip";
            dtColumn.Caption = "Zip";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            // Add column to the DataColumnCollection.    
            custTable.Columns.Add(dtColumn);
        }
        //UC02------->Insert values in Data Table
        public int AddValues()
        {
            CreateDataTable();
            //Create Object for DataTable
            ContactDataManager contactDataManager = new ContactDataManager();
            ContactDataManager contactDataManagers = new ContactDataManager();
            //Insert Values into Table
            contactDataManager.FirstName = "Rinku";
            contactDataManager.LastName = "Berde";
            contactDataManager.PhoneNumber = 1234567890;
            contactDataManager.Email = "rinku@gmail.com";
            contactDataManager.Address = "4,B Block,SP Nagar";
            contactDataManager.City = "Mumbai";
            contactDataManager.State = "MH";
            contactDataManager.zip = 600072;
            InsertintoDataTable(contactDataManager);

            //Insert Values into Table
            contactDataManagers.FirstName = "Abhi";
            contactDataManagers.LastName = "Mane";
            contactDataManagers.PhoneNumber = 7742905050;
            contactDataManagers.Email = "maneabhi@gmail.com";
            contactDataManagers.Address = "Sasthri street";
            contactDataManagers.City = "Mumbai";
            contactDataManagers.State = "MH";
            contactDataManagers.zip = 123001;
            InsertintoDataTable(contactDataManagers);

            return custTable.Rows.Count;
        }

        //Insert values in Data Table
        public void InsertintoDataTable(ContactDataManager contactDataManager)
        {
            DataRow dtRow = custTable.NewRow();
            dtRow["FirstName"] = contactDataManager.FirstName;
            dtRow["LastName"] = contactDataManager.LastName;
            dtRow["Address"] = contactDataManager.Address;
            dtRow["City"] = contactDataManager.City;
            dtRow["State"] = contactDataManager.State;
            dtRow["Zip"] = contactDataManager.zip;
            dtRow["PhoneNumber"] = contactDataManager.PhoneNumber;
            dtRow["Email"] = contactDataManager.Email;
            custTable.Rows.Add(dtRow);

        }
        //UC03------->Ability to edit existing contact person using their name
        public int EditDataTable(string FirstName, string ColumnName)
        {
            AddValues();
            var modifiedList = (from ContactList in custTable.AsEnumerable() where ContactList.Field<string>("FirstName") == FirstName select ContactList).FirstOrDefault();
            if (modifiedList != null)
            {
                modifiedList[ColumnName] = "Sing";
                Display();
                return 1;
            }
            else return 0;
        }
        //UC-04---->Ability to delete a person using person'sname
        public int DeleteRowInDataTable(string FirstName)
        {
            AddValues();
            var modifiedList = (from ContactList in custTable.AsEnumerable() where ContactList.Field<string>("FirstName") == FirstName select ContactList).FirstOrDefault();
            if (modifiedList != null)
            {
                modifiedList.Delete();
                Console.WriteLine("--- After Deletion ---");
                Display();
                return 1;
            }
            else return 0;
        }
        //Retrieve values from DataTable based on City or State
        public string RetrieveBasedOnCityorState(string City, string State)
        {
            AddValues();
            string nameList = "";
            var modifiedList = (from ContactList in custTable.AsEnumerable() where (ContactList.Field<string>("State") == State || ContactList.Field<string>("City") == City) select ContactList);
            foreach (var dtRows in modifiedList)
            {
                nameList += dtRows["FirstName"] + " ";
                Console.WriteLine("{0} \t {1} \t {2} \t {3} \t {4} \t {5} \t {6} \t {7} \t {8}\n", dtRows["Contactid"], dtRows["FirstName"], dtRows["LastName"], dtRows["Address"], dtRows["City"], dtRows["State"], dtRows["Zip"], dtRows["PhoneNumber"], dtRows["Email"]);
            }
            return nameList;
        }
        //UC-06----->Retrieve Count values from DataTable based on City or State
        public string RetrieveCountBasedOnCityorState()
        {
            AddValues();
            string result = "";
            var modifiedList = (from ContactList in custTable.AsEnumerable().GroupBy(r => new { Col1 = r["City"], Col2 = r["State"] }) select ContactList);
            Console.WriteLine("Äfter count");
            foreach (var j in modifiedList)
            {
                result += j.Count() + " ";
                Console.WriteLine("Count Key" + j.Key);
                foreach (var dtRows in j)
                {
                    Console.WriteLine("{0} \t {1} \t {2} \t {3} \t {4} \t {5} \t {6} \t {7} \t {8}\n", dtRows["Contactid"], dtRows["FirstName"], dtRows["LastName"], dtRows["Address"], dtRows["City"], dtRows["State"], dtRows["Zip"], dtRows["PhoneNumber"], dtRows["Email"]);
                }
            }
            return result;
        }
        //UC-07---> Sort based on City
        public string SortBasedOnNameInDataTable(string City)
        {
            AddValues();
            string result = "";
            var modifiedList = (from ContactList in custTable.AsEnumerable() orderby ContactList.Field<string>("FirstName") where ContactList.Field<string>("City") == City select ContactList);
            Console.WriteLine("After sorting");
            foreach (var dtRows in modifiedList)
            {
                result += dtRows["FirstName"] + " ";
                Console.WriteLine("{0} \t {1} \t {2} \t {3} \t {4} \t {5} \t {6} \t {7} \t {8}\n", dtRows["Contactid"], dtRows["FirstName"], dtRows["LastName"], dtRows["Address"], dtRows["City"], dtRows["State"], dtRows["Zip"], dtRows["PhoneNumber"], dtRows["Email"]);

            }
            return result;
        }
        //Display all Values in DataRow
        public void Display()
        {
            foreach (DataRow dtRows in custTable.Rows)
            {
                Console.WriteLine("{0} \t {1} \t {2} \t {3} \t {4} \t {5} \t {6} \t {7}\n", dtRows["FirstName"], dtRows["LastName"], dtRows["Address"], dtRows["City"], dtRows["State"], dtRows["Zip"], dtRows["PhoneNumber"], dtRows["Email"]);
            }
        }
    }
}