namespace App;

class User
{
    public string Username;
    string _password;
    public List<Item> Items = new List<Item>();

    public User(string username, string password)
    {
        Username = username;
        _password = password;
        Items = new List<Item>();
    }

    public bool TryLogin(string username, string password)
    {
        return username == Username && password == _password;
    }

    // AddItem är funktionen som kan lägga till ett item i en users item list. Denna anropas i program.cs
    public void AddItem(string name, string description, User owner)
    {
        Item item = new Item(name, description, owner);

        Items.Add(item);
    }
}