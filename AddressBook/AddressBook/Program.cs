using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    internal class Program
    {        
        public static void Main(string[] args)
        {
            PersonData person = new PersonData();
            Console.WriteLine("Select an option\n1.Create Contacts\n2.Display Contacts\n3.Edit Contact\n4.Delect Contact\n5.Add Multiple Contacts\n" + 
                    "6. Add Multiple Address Books\n7. Search by City and State\n8. Display Contacts By City or State\n9. Get Count\n10. Write & Read Contact Details using Text file\n" +
                    "11. Write & Read Details using CSV Files\n12. Write And Read Details using JSON Files\n13. End the Program");
            int num = Convert.ToInt32(Console.ReadLine());
            while (num != 13)
            {
                switch (num)
                {
                    case 1:
                        person.CreateContacts();
                        break;
                    case 2:
                        person.DisplayContacts();
                        break;
                    case 3:
                        person.EditContact();
                        break;
                    case 4:
                        person.DeleteContact();
                        break;
                    case 5:                        
                        person.AddMultipleContacts();
                        break;
                    case 6:
                        person.AddMultipleAddressBooks();
                        break;
                    case 7:
                        person.SearchByCityorState();
                        break;
                    case 8:
                        person.DisplayByCityOrState();
                        break;
                    case 9:
                        person.GetCount();
                        break;
                    case 10:
                        person.WriteTextFile();
                        person.ReadTextFile();
                        break;
                    case 11:
                        person.WriteCSVFile();
                        person.ReadCSVFile();
                        break;
                    case 12:
                        person.WriteJSONFile();
                        person.ReadJSONFile();
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
                Console.WriteLine("Select an option\n1. Create Contacts\n2. Display Contacts\n3. Edit Contact\n4. Delect Contact\n5. Add Multiple Contacts\n" + 
                    "6. Add Multiple Address Books\n7. Search by City and State\n8. Display Contacts By City or State\n9. Get Count\n10. Write & Read Contact Details using Text file\n" +
                    "11. Write & Read Details using CSV Files\n12. Write And Read Details using JSON Files\n13. End the Program");
                num = Convert.ToInt32(Console.ReadLine());
            }
        }
    }
}