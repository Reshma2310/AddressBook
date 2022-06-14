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
        Dictionary<string, List<Contacts>> DisplayCity = new Dictionary<string, List<Contacts>>();
        Dictionary<string, List<Contacts>> DisplayState = new Dictionary<string, List<Contacts>>();
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
            addContacts.Add(contacts);
            Console.WriteLine();
        }
        public void DisplayContacts()
        {
            if (addContacts.Count == 0)
            {
                Console.WriteLine("Address Book is Empty");
            }
            Console.WriteLine("Contacts List:");
            foreach (var contacts in addContacts)
            {
                Console.WriteLine("First Name: " + contacts.FirstName + "\nLast Name: " + contacts.LastName + "\nAddress: " + contacts.Address + "\nCity: " + contacts.City + "\nState: " + contacts.State + "\nZipcode: " + contacts.Zipcode + "\nPhone Number: " + contacts.PhoneNumber + "\nEmail: " + contacts.Email);
            }
        }
        public void EditContact()
        {
            Console.WriteLine("Enter First Name of the Person to Edit Details");
            string fName = Console.ReadLine();
            foreach (var contacts in addContacts)
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
        public void DeleteContact()
        {
            Console.WriteLine("Enter First Name of the Person to Delete Details");
            string Name = Console.ReadLine();
            foreach (var contacts in addContacts.ToList())
            {
                if (contacts.FirstName.Equals(Name))
                {
                    addContacts.Remove(contacts);
                }
            }
        }
        public void AddMultipleContacts()
        {
            Console.WriteLine("Number of Contacts you want to add: ");
            int number = Convert.ToInt32(Console.ReadLine());
            addContacts = new List<Contacts>();
            while (number > 0)
            {
                CreateContacts();
                number--;
            }
        }
        public void AddMultipleAddressBooks()
        {
            Console.WriteLine("Number of Address Books you want to add");
            int no = Convert.ToInt32(Console.ReadLine());
            while (no > 0)
            {
                Console.WriteLine("Enter Address Book name");
                string name = Console.ReadLine();
                AddMultipleContacts();
                addMultiple.Add(name, addContacts);
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
            Console.WriteLine("Enter your choice:\n1. Search contacts by City\n2.Search contacts by State");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("Enter a city Name to be search: ");
                        string searchCity = Console.ReadLine();
                        foreach (var contact in addMultiple)
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
            AddMultipleAddressBooks();

            foreach (var bookName in addMultiple)
            {
                foreach (var data in bookName.Value)
                {
                    if (DisplayCity.ContainsKey(data.City))
                    {
                        DisplayCity[data.City].Add(data);
                    }
                    else
                    {
                        DisplayCity.Add(data.City, new List<Contacts>() { data });
                    }
                    if (DisplayState.ContainsKey(data.State))
                    {
                        DisplayState[data.State].Add(data);
                    }
                    else
                    {
                        DisplayState.Add(data.State, new List<Contacts>() { data });
                    }
                }
            }
            Console.WriteLine("Display Contacts in Cities");
            foreach (var key in DisplayCity.Keys)
            {
                Console.WriteLine("Contacts in " + key + "\n");
                DisplayCity[key].ForEach(e => Console.WriteLine("First Name: " + e.FirstName + "\nCity: " + e.City + "\n"));
            }
            Console.WriteLine("Display Contacts in States");
            foreach (var key in DisplayState.Keys)
            {
                Console.WriteLine("Contacts in " + key + "\n");
                DisplayState[key].ForEach(e => Console.WriteLine("First Name: " + e.FirstName + "\nCity: " + e.State + "\n"));
            }
        }
        public void GetCount()
        {
            DisplayByCityOrState();
            int cityCount = 0, stateCount = 0;
            Console.WriteLine("Enter City Name to list Number of Contacts");
            string searchCity = Console.ReadLine();
            foreach (var key in DisplayCity.Keys)
            {
                foreach (var value in DisplayCity[key].FindAll(e => (e.City.StartsWith(searchCity))))
                {
                    cityCount++;
                }
            }
            Console.WriteLine("Number of Contacts in " + searchCity + ": " + cityCount);
            Console.WriteLine("Enter State Name to list Number of Contacts");
            string searchState = Console.ReadLine();
            foreach (var key in DisplayState.Keys)
            {
                foreach (var value in DisplayState[key].FindAll(e => (e.State.StartsWith(searchState))))
                {
                    stateCount++;
                }
            }
            Console.WriteLine("Number of Contacts in " + searchState + ": " + stateCount);
        }
        public void WriteTextFile()
        {
            string file = @"D:\BridgeLabs\AddressBook\AddressBook\AddressBook\DetailsTextFile.txt";
            using StreamWriter writer = File.AppendText(file);
            {
                Console.WriteLine("\nFirst Name, LastName, Address, City, State, Zip Code, Phone Number, Email");
                writer.WriteLine(Console.ReadLine());
                writer.Close();
            }
        }
        public void ReadTextFile()
        {
            string file = @"D:\BridgeLabs\AddressBook\AddressBook\AddressBook\DetailsTextFile.txt";
            string[] reader = File.ReadAllLines(file);
            string[] array = { "First Name", "LastName", "Address", "City", "State", "Zip Code", "Phone Number", "Email" };

            for (int i = 0; i < reader.Length; i++)
            {
                string[] details = reader[i].Split(",");
                for (int j = 0; j < details.Length; j++)
                {
                    Console.WriteLine(array[j] + ": " + details[j]);
                }
                Console.WriteLine();
            }
        }
        public void WriteCSVFile()
        {
            string file = @"D:\BridgeLabs\AddressBook\AddressBook\AddressBook\DetailsFileCSV.csv";
            using StreamWriter writer = File.AppendText(file);
            {
                Console.WriteLine("\nFirst Name, Address, City, State, Zip Code, Phone Number, Email");
                writer.WriteLine(Console.ReadLine());
                writer.Close();
            }
        }
        public void ReadCSVFile()
        {
            string file = @"D:\BridgeLabs\AddressBook\AddressBook\AddressBook\DetailsFileCSV.csv";
            string[] reader = File.ReadAllLines(file);
            string[] array = { "First Name", "Address", "City", "State", "Zip Code", "Phone Number", "Email" };

            for (int i = 0; i < reader.Length; i++)
            {
                string[] details = reader[i].Split(",");
                for (int j = 0; j < details.Length; j++)
                {
                    Console.WriteLine(array[j] + ": " + details[j]);
                }
                Console.WriteLine();
            }
        }
    }
}