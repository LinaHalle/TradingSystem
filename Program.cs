/* 
A user needs to be able to register an account
A user needs to be able to log out.
A user needs to be able to log in.

A user needs to be able to upload information about the item they wish to trade.
A user needs to be able to browse a list of other users items.
A user needs to be able to request a trade for other users items.
A user needs to be able to browse trade requests.
A user needs to be able to accept a trade request.
A user needs to be able to deny a trade request.
A user needs to be able to browse completed requests.*/

using App;
//gör en lista med User som heter users
List<User> users = new List<User>();
//gör en lista med Item som heter items
List<Item> items = new List<Item>();

//adderar Users så att jag kan kolla att min kod fungerar
users.Add(new User("Lina", "tjokatt2000"));


User? active_user = null; //? = nullable, kna finnas en inloggad user eller en inte inloggad user

bool running = true;
while (running)
{
    if (active_user == null)
    {
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
                Console.Clear();
                Console.WriteLine("Enter username:");
                string username = Console.ReadLine();

                Console.Clear();
                Console.WriteLine("Enter password");
                string password = Console.ReadLine();

                Console.Clear();

                foreach (User user in users)
                {
                    if (user.TryLogin(username, password))
                    {
                        active_user = user;
                        break;
                    }
                }
                break;

            case "2":
                Console.Clear();
                Console.WriteLine("Enter your new username");
                string newUsername = Console.ReadLine();

                Console.Clear();
                Console.WriteLine("Enter your new password");
                string newPassword = Console.ReadLine();

                users.Add(new User(newUsername, newPassword));
                Console.Clear();
                Console.WriteLine("Account succesfully registerd, press ENTER to go back to login");
                Console.ReadLine();

                break;
        }
    }
    else
    {
        Console.Clear();
        Console.WriteLine("TradeHub main menu");
        Console.ReadLine();
    }

}

