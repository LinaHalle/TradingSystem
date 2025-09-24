namespace App;

enum TradeStatus
{
    Pending,
    Denied,
    Accepted
}
class Trade
{
    public string Sender;
    public string Reciever;
    public TradeStatus Status;

    public Trade(string sender, string reciever, TradeStatus status)
    {
        Sender = sender;
        Reciever = reciever;
        Status = status;
    }

}