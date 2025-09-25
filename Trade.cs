namespace App;

enum TradeStatus
{
    Pending,
    Denied,
    Accepted
}
class Trade
{
    public User Sender;
    public Item RequestedItem;
    public Item OfferedItem;
    public User Reciever;
    public TradeStatus Status;

    public Trade(User sender, Item requestedItem, Item offeredItem, User reciever, TradeStatus status)
    {
        Sender = sender;
        RequestedItem = requestedItem;
        OfferedItem = offeredItem;
        Reciever = reciever;
        Status = status;
    }

}