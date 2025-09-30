namespace App;

/* The user class represents a user in the system. Each user has a Username, a private _password, and lists for their Items, pendingTrades and completedTrades. */
class User
{
    public string Username;
    string _password;
    public List<Item> Items = new List<Item>();

    public List<Trade> pendingTrades = new List<Trade>();

    public List<Trade> completedTrades = new List<Trade>();

    public User(string username, string password) //The constructor initializes these values. 
    {
        Username = username;
        _password = password;
        Items = new List<Item>();
        pendingTrades = new List<Trade>();
        completedTrades = new List<Trade>();
    }

    //this method checks if the provided username and password match the user's login details
    public bool TryLogin(string username, string password)
    {
        return username == Username && password == _password;
    }

    // A method that creates a new item and adds it to the user's collction of items. 
    public void AddItem(string name, string description, User owner)
    {
        Item item = new Item(name, description, owner);

        Items.Add(item);
    }

    //AddPendingTrade and AddCompletedTrades are methods that manage the user's trade history. Both are needed to be able to search on both pending trades and completed
    public void AddPendingTrade(Trade trade)
    {
        pendingTrades.Add(trade);
    }

    public void AddcompletedTrades(Trade trade)
    {
        completedTrades.Add(trade);
    }


}