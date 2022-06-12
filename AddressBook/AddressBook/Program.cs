using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    internal class Program
    {
        public static List<Contacts> addContacts = new List<Contacts>();
        public static void Main(string[] args)
        {
            PersonData person = new PersonData();
            Console.WriteLine("apbcSelect an option to perform\n1. Create Contacts\n2. Display Contacts\n3. Edit Contact\n4. Delect Contact\n5. Add Multiple Contacts\n6. Add Multiple Address Books\n7. Search by City and State\n8. Display Contacts By City or State\n9. End the Program");
            int num = Convert.ToInt32(Console.ReadLine());
            while (num != 9)
            {
                switch (num)
                {
                    case 1:
                        person.CreateContacts();
                        break;
                    case 2:
                        AddressBook.PersonData.DisplayContacts();
                        break;
                    case 3:
                        AddressBook.PersonData.EditContact();
                        break;
                    case 4:
                        AddressBook.PersonData.DeleteContact();
                        break;
                    case 5:                        
                        person.AddMultipleContacts();
                        break;
                    case 6:
                        AddressBook.PersonData.AddMultipleAddressBooks();
                        break;
                    case 7:
                        person.SearchByCityorState();
                        break;
                    case 8:
                        person.DisplayByCityOrState();
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
                Console.WriteLine("Select an option\n1. Create Contacts\n2. Display Contacts\n3. Edit Contact\n4. Delect Contact\n5. Add Multiple Contacts\n6. Add Multiple Address Books\n7. Search by City and State\n8. Display Contacts By City or State\n9. End the Program");
                num = Convert.ToInt32(Console.ReadLine());
            }
        }
    }
}