namespace App;

/* The trade class concists of 5 fields, TradeStatus, Sender, RequestedItem, OfferedItem and Reciever. I need all of these fields to connect the trade to the concerning users for the right items, I choose an enum for TradeStatus because the status of a trade can only be one of the fixed set of values. */

enum TradeStatus
{
    Pending,
    Denied,
    Accepted,
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