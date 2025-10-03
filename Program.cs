//This is the code where the user interfare with the program through the console.

using App;
//creating an empty list of Users, named users
List<User> users = new List<User>();

//adding users to be able to see if my code compiles
users.Add(new User("Lina", "tjokatt2000"));
users.Add(new User("David", "tjokatt2000"));

//I assign the users to a name just to make it easier to call methods on them without writing users[0]/ users[1] everytime, but its not needed for the code to compile.
User lina = users[0];
User david = users[1];

//// I hardcode a few items for testing purposes, so I can verify that the trading system works without having to create items manually each time
lina.AddItem("Airpods PRO", "Helt nya", lina);
lina.AddItem("Monstrea", "50 cm", lina);
lina.AddItem("Läsglasögon", "Måttligt använda", lina);

david.AddItem("Nike keps", "Grön och skön", david);
david.AddItem("Lenovo dator", "Årsmodell 2018", david);
david.AddItem("En ryggsäck", "Väldigt rymlig", david);


User? active_user = null; //? = nullable, there can be an logged in user or a not logged in user. With this I keep track of the currently logged-in user.

bool running = true;
while (running) //The program runs inside a while loop until I explicitly decide to stop it running=false;
{
    if (active_user == null) //when no one is logged in the user sees the login/register menu
    {
        try { Console.Clear(); } catch { }
        Console.WriteLine("Welcome to TradeHub");
        Console.WriteLine("------------- Log-in page -------------");
        Console.WriteLine();
        Console.WriteLine("Do you already have an account, choose: 1. to login");
        Console.WriteLine("Do you want to create an account, choose: 2. to register");
        Console.WriteLine();
        Console.WriteLine("---------------------------------------");

        string registerOrLogin = Console.ReadLine();

        switch (registerOrLogin)
        {
            case "1":
                //If active_user has an account and it checks out with TryLogin the active_user is not null anymore and moves out from the login menu and moves to the else where the rest of the code is  

                try { Console.Clear(); } catch { } //workaround to allow debugging
                Console.WriteLine("Enter username:");
                string username = Console.ReadLine();

                try { Console.Clear(); } catch { }
                Console.WriteLine("Enter password");
                string password = Console.ReadLine();

                try { Console.Clear(); } catch { }

                //I use a foreach loop to go through the saved users and see if anything match the inputs, if it get a match the loop breaks and moves on to main menu
                foreach (User user in users)
                {
                    if (user.TryLogin(username, password))
                    {
                        active_user = user;
                        break;
                    }
                }
                //if the user isn't found
                if (active_user == null)
                {
                    Console.WriteLine("No matching user, try again or create an account, press ENTER to go back");
                    Console.ReadLine();
                }
                break;

            case "2":
                //here the new user is created and then relocated to the log in menu again because active_user is still null.
                try { Console.Clear(); } catch { }
                Console.WriteLine("Enter your new username");
                string newUsername = Console.ReadLine();

                try { Console.Clear(); } catch { }
                Console.WriteLine("Enter your new password");
                string newPassword = Console.ReadLine();

                users.Add(new User(newUsername, newPassword)); //the user is saved in the users list so after redirection to login page the user will be able to login
                try { Console.Clear(); } catch { }
                Console.WriteLine("Account succesfully registerd, press ENTER to go back to log-in page");
                Console.ReadLine();
                break;
        }
    }
    else //here's all functionality when active_user != null;
    {
        try { Console.Clear(); } catch { }
        Console.WriteLine("TradeHub main menu, choose any of the options");
        Console.WriteLine("Please chose one of the options below");
        Console.WriteLine("1. Upload an item");
        Console.WriteLine("2: Brows existing items of other users");
        Console.WriteLine("3: Request a trade for someone's item");
        Console.WriteLine("4: Accept/Deny a trade request");
        Console.WriteLine("5: Brows on already completed requests");
        Console.WriteLine("6: Logout");

        string input = Console.ReadLine();
        switch (input)
        {
            case "1":
                // here we get inputs from the user in the console, that creates an item that is added in the active_users item-list.  
                try { Console.Clear(); } catch { }
                Console.WriteLine("Enter the name of the item");
                string name = Console.ReadLine();
                Console.WriteLine("Enter a description of the item");
                string description = Console.ReadLine();
                User owner = active_user;
                active_user.AddItem(name, description, owner);
                Console.WriteLine("The item was succesfylly added to your list");
                Console.WriteLine("Press ENTER to go back to menu");
                Console.ReadLine();
                break;

            case "2":
                // Here I use a foreach loop to go through all users, all users that are != active_user a do another foreach loop to go thorugh their items and write it out in the console through my method ShowItem.  
                try { Console.Clear(); } catch { }
                Console.WriteLine("Here's all the items from other users");

                foreach (User user in users)
                {
                    if (user != active_user)
                    {
                        foreach (Item item in user.Items)
                        {
                            Console.WriteLine(item.ShowItem());
                        }
                    }
                }
                Console.WriteLine("Press ENTER to continue");
                Console.ReadLine();
                break;

            case "3":
                try { Console.Clear(); } catch { }
                List<Item> OtherUsersItems = new List<Item>();  //here I create a new list for only other users items
                foreach (User user in users)
                {
                    if (user != active_user)
                    {
                        foreach (Item item in user.Items)
                        {
                            OtherUsersItems.Add(item);          //here I fill the new list 
                        }
                    }
                }

                int i = 1; //I want the index to start on 1, its unnatural for a user to see a list from 0.
                Console.WriteLine("Enter the number of the item you want");
                foreach (Item item in OtherUsersItems)
                {
                    Console.WriteLine($"{i}.{item.ShowItem()}");    //writes out the new list with an index
                    i++;
                }

                int chosenIndex = int.Parse(Console.ReadLine()) - 1;  //convert the string input to an int chosenIndex and take -1 to match the real index number that always starts on 0.

                Item requestedItem = OtherUsersItems[chosenIndex];  //Here I give requestedItem the value of the choosen item.

                User reciever = requestedItem.Owner; // I connect the Reciever field to the owner of the requested item.

                Console.WriteLine("Enter the number of your item you want to offer as trade");
                i = 1;
                foreach (Item item in active_user.Items)
                {
                    Console.WriteLine($"{i}.{item.ShowItem()}"); //Loops through the active_users items and shows the items with an index 
                    i++;
                }
                int myItem = int.Parse(Console.ReadLine()) - 1; //convert the string input to an int myItem and take -1 to match the real index number that always starts on 0.

                Item offeredItem = active_user.Items[myItem];  //OfferedItem gets its value  
                // User Sender = OfferedItem.Owner; //unneccesary bc sender is always active_user 

                Trade trade = new Trade(active_user, requestedItem, offeredItem, reciever, TradeStatus.Pending); //Creates a Trade object 

                reciever.AddPendingTrade(trade); //The new trade is added to the recievers pendingtrade - list 

                Console.WriteLine($"Your trade request has succesfully been sent to: {reciever.Username}");
                Console.WriteLine("Press ENTER to go back to main menu");
                Console.ReadLine();
                break;

            case "4":
                try { Console.Clear(); } catch { }
                Console.WriteLine("Choose the Trade you want to Accept/Deny");
                i = 1; //want the list to start at 1

                if (active_user.pendingTrades.Count > 0)//If the list isn't empty
                {
                    foreach (Trade myTrades in active_user.pendingTrades) //loops though the active_users pending trades
                    {
                        Console.WriteLine($"{i}. {myTrades.Sender.Username} wants your {myTrades.RequestedItem.Name} in exchange for {myTrades.OfferedItem.Name}");  //displays the trades with an index
                        i++;
                    }
                    int chosenTrade = int.Parse(Console.ReadLine()) - 1; //the active_user chooses a index and here it's converted from a string to an int and is reduced with -1. 

                    Trade selectedTrade = active_user.pendingTrades[chosenTrade]; //I create a new variabel for the choosen trade

                    Console.WriteLine("Choose an option");
                    Console.WriteLine("1. Accept");
                    Console.WriteLine("2. Deny");

                    string acceptOrDeny = Console.ReadLine();
                    switch (acceptOrDeny)
                    {
                        case "1":
                            try { Console.Clear(); } catch { }
                            selectedTrade.RequestedItem.Owner = selectedTrade.Sender; //I change the owner to the sender

                            selectedTrade.OfferedItem.Owner = active_user; //I change the owner to the reciever(active_user)

                            //takes away Requested item från active_users itemList
                            active_user.Items.Remove(selectedTrade.RequestedItem);

                            //adds requested item to the the senders itemList
                            selectedTrade.Sender.Items.Add(selectedTrade.RequestedItem);

                            //adds offeredItem to active_users itemlist
                            active_user.Items.Add(selectedTrade.OfferedItem);

                            //removes the offered item from senders itemlist
                            selectedTrade.Sender.Items.Remove(selectedTrade.OfferedItem);

                            selectedTrade.Status = TradeStatus.Accepted; //I change status to accepted.


                            active_user.pendingTrades.Remove(selectedTrade); //I take the trade away from pending 

                            // I add it to the completed trades list for both users
                            active_user.completedTrades.Add(selectedTrade);
                            selectedTrade.Sender.completedTrades.Add(selectedTrade);

                            Console.WriteLine("Trade accepted");
                            Console.WriteLine("Press ENTER to go back to menu");
                            Console.ReadLine();
                            break;

                        case "2":
                            try { Console.Clear(); } catch { }
                            selectedTrade.Status = TradeStatus.Denied; //when denied I only change status to denied, and take away from pending list to completed list
                            active_user.pendingTrades.Remove(selectedTrade);

                            // I add it to the completed trades list for both users
                            active_user.completedTrades.Add(selectedTrade);
                            selectedTrade.Sender.completedTrades.Add(selectedTrade);

                            Console.WriteLine("Trade denied");
                            Console.WriteLine("Press ENTER to go back to menu");
                            Console.ReadLine();
                            break;

                    }

                }
                else
                {
                    //if there's no pending trades (pendingtrades.count < 0), it jumps to the else
                    try { Console.Clear(); } catch { }
                    Console.WriteLine("You have no pending requests");
                    Console.WriteLine("Press ENTER to go back");
                    Console.ReadLine();

                }
                break;

            case "5":
                try { Console.Clear(); } catch { }
                if (active_user.completedTrades.Count > 0) //if list is empty or not
                {
                    //if not empty loop trough the trades in active_users completedtrades list
                    Console.WriteLine("Here's a list of your already completed trades");
                    foreach (Trade doneTrades in active_user.completedTrades)
                    {
                        //if the trade sender was the active user, it displays one message in console
                        if (doneTrades.Sender == active_user)
                        {
                            Console.WriteLine($"You offered your {doneTrades.OfferedItem.Name} to {doneTrades.Reciever.Username} in exchange for {doneTrades.RequestedItem.Name}. Status: {doneTrades.Status}");
                        }
                        else
                        {
                            //if the sender was not the active_user it displays another message in console.
                            Console.WriteLine($"{doneTrades.Sender.Username} offered your their {doneTrades.OfferedItem.Name} in exchange for your {doneTrades.RequestedItem.Name}. You {doneTrades.Status} this trade.");
                        }
                    }
                }
                else
                {
                    //list empty 
                    try { Console.Clear(); } catch { }
                    Console.WriteLine("You have no completed trades");

                }
                Console.WriteLine("Press enter to go back to menu");
                Console.ReadLine();
                break;

            case "6":
                Console.WriteLine("1: If you're sure you want to logout");
                Console.WriteLine("2: If you want to go back to main menu");
                string logout = Console.ReadLine();
                switch (logout)
                {
                    case "1":
                        //to logout and go back to log-in menu, active_user= null again. 
                        active_user = null;
                        break;
                    case "2":
                        //this is just an extra break if the user changed it's mind about login out 
                        break;
                }

                break;

        }
    }

}

