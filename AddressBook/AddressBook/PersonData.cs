using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AddressBook
{
    public class PersonData
    {
        Contacts contacts;
        List<Contacts> addContacts = new List<Contacts>();
        Dictionary<string, List<Contacts>> addMultiple = new Dictionary<string, List<Contacts>>();
        Dictionary<string, List<string>> ByCity = new Dictionary<string, List<string>>();
        Dictionary<string, List<string>> ByState = new Dictionary<string, List<string>>();
        public void CreateContacts()
        {
            contacts = new Contacts();
            bool value = true;
            while (value)
            {
                Console.WriteLine("Enter First Name");
                contacts.FirstName = Console.ReadLine();
                if (addContacts.Any(p => p.FirstName.Equals(contacts.FirstName)))
                {

                    Console.WriteLine("Contact already exit in  your address book:");
                }
                else
                {
                    value = false;
                }
            }
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
        public void AddMultipleContacts()
        {
            Console.WriteLine("Number of Contacts you want to add: ");
            int number = Convert.ToInt32(Console.ReadLine());
            while (number > 0)
            {
                CreateContacts();
                number--;
            }
        }
        public static void AddMultipleAddressBooks()
        {
            Dictionary<string, List<Contacts>> addMultiple = new Dictionary<string, List<Contacts>>();
            Console.WriteLine("Number of Address Books you want to add");
            int no = Convert.ToInt32(Console.ReadLine());
            while (no > 0)
            {
                Console.WriteLine("Enter Address Book name");
                string name = Console.ReadLine();
                PersonData personData = new PersonData();
                personData.AddMultipleContacts();
                addMultiple.Add(name, Program.addContacts);
                no--;
            }
            foreach (var book in addMultiple)
            {
                Console.WriteLine("Grouping Name is :" + book.Key + "\n");
                foreach (var person in book.Value)
                {
                    Console.WriteLine("First Name: " + person.FirstName + "\nLast Name: " + person.LastName + "\nAddress: " + person.Address + "\nCity: " + person.City + "\nState: " + person.State + "\nZipcode: " + person.Zipcode + "\nPhone Number: " + person.PhoneNumber + "\nEmail: " + person.Email);
                }
            }
        }
        public void SearchByCityorState()
        {
            AddMultipleAddressBooks();
            Console.WriteLine("1. Search contacts by City\n2.Search contacts by State");
            Console.WriteLine("Enter your choice:");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("Enter a city Name to be search: ");
                        string searchCity = Console.ReadLine();
                        foreach (var contact in addMultiple.ToList())
                        {
                            Console.WriteLine("Group Name is :" + contact.Key + " \n");
                            foreach (var person in contact.Value.FindAll(e => (e.City.Equals(searchCity))).ToList())
                            {
                                Console.WriteLine("First Name: " + person.FirstName + "\nLast Name: " + person.LastName + "\nAddress: " + person.Address + "\nCity: " + person.City + "\nState: " + person.State + "\nZipcode: " + person.Zipcode + "\nPhone Number: " + person.PhoneNumber + "\nEmail: " + person.Email);
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Enter a state Name to be search: ");
                        string searchState = Console.ReadLine();
                        foreach (var contact in addMultiple)
                        {
                            Console.WriteLine("Group Name is :" + contact.Key + " \n");
                            foreach (var person in contact.Value.FindAll(e => (e.State.Equals(searchState))).ToList())
                            {
                                Console.WriteLine("First Name: " + person.FirstName + "\nLast Name: " + person.LastName + "\nAddress: " + person.Address + "\nCity: " + person.City + "\nState: " + person.State + "\nZipcode: " + person.Zipcode + "\nPhone Number: " + person.PhoneNumber + "\nEmail: " + person.Email);
                            }
                        }
                        break;
                    }                    
            }
        }
        public void DisplayByCityOrState()
        {
            foreach (var key in addMultiple.Keys)
            {
                foreach (var item in addMultiple[key])
                {

                    if (ByCity.ContainsKey(item.City))
                        ByCity[item.City].Add(item.FirstName + " " + item.LastName);
                    else
                        ByCity.Add(item.City, new List<string>() { item.FirstName + " " + item.LastName });
                    if (ByState.ContainsKey(item.State))
                        ByState[item.State].Add(item.FirstName + " " + item.LastName);
                    else
                        ByState.Add(item.State, new List<string>() { item.FirstName + " " + item.LastName });
                }
            }
            Console.WriteLine("Contacts by city:");
            foreach (var key in ByCity.Keys)
            {
                Console.WriteLine("Contacts from city:" + key);
                ByCity[key].ForEach(x => Console.WriteLine(x));

            }
            Console.WriteLine("Contacts by state:");
            foreach (var key in ByState.Keys)
            {
                Console.WriteLine("Contacts from state: " + key);
                ByState[key].ForEach(x => Console.WriteLine(x));
            }
        }
        public void GetCount()
        {
            foreach (var key in addMultiple.Keys)
            {
                foreach (var item in addMultiple[key])
                {

                    if (ByCity.ContainsKey(item.City))
                        ByCity[item.City].Add(item.FirstName + " " + item.LastName);
                    else
                        ByCity.Add(item.City, new List<string>() { item.FirstName + " " + item.LastName });
                    if (ByState.ContainsKey(item.State))
                        ByState[item.State].Add(item.FirstName + " " + item.LastName);
                    else
                        ByState.Add(item.State, new List<string>() { item.FirstName + " " + item.LastName });
                }
            }
            Console.WriteLine("No. of contacts by city.");
            foreach (var key in ByCity.Keys)
            {
                Func<int, int> count = x =>
                {
                    foreach (var value in ByCity[key])
                        x += 1;
                    return x;
                };
                Console.WriteLine("No. of contacts in city " + key + " are " + count(0));
            }
            Console.WriteLine("No. of contacts by state.");
            foreach (var key in ByState.Keys)
            {
                Func<int, int> count = x =>
                {
                    foreach (var value in ByState[key])
                        x += 1;
                    return x;
                };
                Console.WriteLine("No. of contacts in state " + key + " are " + count(0));
            }
        }
    }
}