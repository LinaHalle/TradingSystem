namespace App;

class Item
{
    public string Name;
    public string Description;

    public User Owner; //ett item måste vara kopplat till en User

    public Item(string name, string description, User owner)
    {
        Name = name;
        Description = description;
        Owner = owner;
    }
}