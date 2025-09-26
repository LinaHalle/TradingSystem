namespace App;

class User
{
    public string Username;
    string _password;
    public List<Item> Items = new List<Item>();

    public List<Trade> pendingTrades = new List<Trade>();

    public List<Trade> completedTrades = new List<Trade>();

    public User(string username, string password)
    {
        Username = username;
        _password = password;
        Items = new List<Item>();
        pendingTrades = new List<Trade>();
        completedTrades = new List<Trade>();
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

    public void AddPendingTrade(Trade trade)
    {
        pendingTrades.Add(trade);
    }

    public void AddcompletedTrades(Trade trade)
    {
        completedTrades.Add(trade);
    }


}