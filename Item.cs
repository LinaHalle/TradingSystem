namespace App;

/* The item class represents an object that belongs to an user. An item can not exist without an user. The class has three fields, Name, Descprition and Owner (which links the item to an User) */

class Item
{
    public string Name;
    public string Description;

    public User Owner;

    public Item(string name, string description, User owner) //The constructor makes sure every new item is created with these values
    {
        Name = name;
        Description = description;
        Owner = owner;
    }

    public string ShowItem()  //A method that returns a string interpolation, showing the item's name, description and its owner's username
    {
        return ($"{Name}, {Description}, ({Owner.Username})\n");
    }


}