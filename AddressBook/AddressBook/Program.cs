using AddressBook;
internal class Program
{
    public static List<Contacts> addContacts = new List<Contacts>();
    public static void Main(String[] args)
    {
        Console.WriteLine("Select an option to perform\n1. Create Contacts\n2. Display Contacts\n3. Edit Contact\n4. Delect Contact\n5. Add Multiple Contacts\n6. End the Program");
        int num = Convert.ToInt32(Console.ReadLine());
        while (num != 6)
        { 
            switch (num)
            {
                case 1:
                    AddressBook.PersonData.CreateContacts();
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
                    AddressBook.PersonData.AddMultipleContacts();
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
            Console.WriteLine("Select an option\n1. Create Contacts\n2. Display Contacts\n3. Edit Contact\n4. Delect Contact\n5. Add Multiple Contacts\n6. End the Program");
            num = Convert.ToInt32(Console.ReadLine());
        }
    }
}