using AddressBook;
internal class Program
{
    public static List<Contacts> addContacts = new List<Contacts>();
    public static void Main(String[] args)
    { 
       AddressBook.PersonData.CreateContacts();
    }
}