using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    internal class PersonData
    {
        public static void CreateContacts()
        {
            Contacts contacts = new Contacts();
            Console.WriteLine("Enter First Name");
            contacts.FirstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name");
            contacts.LastName = Console.ReadLine();
            Console.WriteLine("Enter Address");
            contacts.Address = Console.ReadLine();
            Console.WriteLine("Enter City");
            contacts.City = Console.ReadLine();
            Console.WriteLine("Enter State");
            contacts.State = Console.ReadLine();
            Console.WriteLine("Enter Zipcode");
            contacts.Zipcode = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Mobile Number");
            contacts.PhoneNumber = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Email");
            contacts.Email = Console.ReadLine();
            Program.addContacts.Add(contacts);
        }
        public static void DisplayContacts()
        {
            if (Program.addContacts.Count == 0)
            {
                Console.WriteLine("Address Book is Empty");
            }
            Console.WriteLine("Contacts List:");
            foreach (var contacts in Program.addContacts)
            {
                Console.WriteLine("First Name: " + contacts.FirstName + "\nLast Name: " + contacts.LastName + "\nAddress: " + contacts.Address + "\nCity: " + contacts.City + "\nState: " + contacts.State + "\nZipcode: " + contacts.Zipcode + "\nPhone Number: " + contacts.PhoneNumber + "\nEmail: " + contacts.Email);
            }
        }
        public static void EditContact()
        {
            Console.WriteLine("Enter First Name of the Person to Edit Details");
            string fName = Console.ReadLine();
            foreach (var contacts in Program.addContacts)
            {
                if (contacts.FirstName.Equals(fName))
                {
                    Console.WriteLine("Select option to edit: \n1. First Name\n2. Last Name\n3.Address\n4. City\n5. State\n6. Zipcode\n7. Phone Number\n8. Email");
                    int num = Convert.ToInt32(Console.ReadLine());
                    switch (num)
                    {
                        case 1:
                            Console.WriteLine("Enter First Name to Update");
                            contacts.FirstName = Convert.ToString(Console.ReadLine());
                            break;
                        case 2:
                            Console.WriteLine("Enter Last Name to Update");
                            contacts.LastName = Convert.ToString(Console.ReadLine());
                            break;
                        case 3:
                            Console.WriteLine("Enter Address to Update");
                            contacts.Address = Convert.ToString(Console.ReadLine());
                            break;
                        case 4:
                            Console.WriteLine("Enter City to Update");
                            contacts.City = Convert.ToString(Console.ReadLine());
                            break;
                        case 5:
                            Console.WriteLine("Enter State to Update");
                            contacts.State = Convert.ToString(Console.ReadLine());
                            break;
                        case 6:
                            Console.WriteLine("Enter Zipcode to Update");
                            contacts.Zipcode = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 7:
                            Console.WriteLine("Enter Phone Number to Update");
                            contacts.PhoneNumber = Convert.ToDouble(Console.ReadLine());
                            break;
                        case 8:
                            Console.WriteLine("Enter Email to Update");
                            contacts.Email = Convert.ToString(Console.ReadLine());
                            break;
                        default:
                            Console.WriteLine("Invalid Option");
                            break;
                    }
                }
            }          
        }
        public static void DeleteContact()
        {
            Console.WriteLine("Enter First Name of the Person to Delete Details");
            string Name = Console.ReadLine();
            foreach (var contacts in Program.addContacts.ToList())
            {
                if (contacts.FirstName.Equals(Name))
                {
                    Program.addContacts.Remove(contacts);
                }
            }
        }
        public static void AddMultipleContacts()
        {
            Console.WriteLine("Number of Contacts you want to add: ");
            int number = Convert.ToInt32(Console.ReadLine());
            while(number > 0)
            {
                CreateContacts();
                number--;
            }
        }
    }
}
