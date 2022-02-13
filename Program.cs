using Roulette;

CurrentNumber[] numbers = new CurrentNumber[37];
double startmoney = 1000;

initialize();
PlayGame();


void initialize()
{
    for(int i=0; i<numbers.Length; i++)
    {
        numbers[i] = new CurrentNumber(i, ColorToReturn(i));
    }
}

void PlayGame()
{
    Random rand = new Random();
    List<int> betnumbers = new List<int>();
    while (startmoney > 0)
    {
        Console.WriteLine("Enter bet type");
        string BetType = Console.ReadLine();
        if(BetType == "exit") { break; } 
        else if(BetType == "many")
        {
            Console.WriteLine("Choose how much you bet! ");
            int userbet = Convert.ToInt32(Console.ReadLine());
            while (true)
            {
                Console.WriteLine("Choose Number To Bet! ");
                int userbetumber = Convert.ToInt32(Console.ReadLine());
                if(userbetumber == -1) { Console.WriteLine("Bets are accepted"); break; }
                else { betnumbers.Add(userbetumber); }
            }
            int roulettenumber = rand.Next(0, 36);
            CheckForManyNumbers(numbers, betnumbers, userbet, roulettenumber);
        } else if(BetType == "single")
        {
            Console.WriteLine("Choose Number To Bet! ");
            int userbetnumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("how much you bet! ");
            int userbet = Convert.ToInt32(Console.ReadLine());
            int roulettenumber = rand.Next(0, 36);
            CheckForSingleNumber(userbetnumber, roulettenumber, userbet);
        } else if(BetType == "color")
        {
            Console.WriteLine("how much you bet! ");
            int userbet = Convert.ToInt32(Console.ReadLine());
            
                Console.WriteLine("enter color to bet");
                string userbetcolor = Console.ReadLine();
                int roulettenumber = rand.Next(0, 36);
                CheckForColor(numbers, roulettenumber, userbet, userbetcolor);
            
        } else if(BetType == "zerogame")
        {
            Console.WriteLine("how much you bet on zero game?");
            int userbet = Convert.ToInt32(Console.ReadLine());
            int roulettenumber = rand.Next(0, 36);
            CheckZeroGame(roulettenumber,userbet);
        }
        else if (BetType == "orphelins")
        {
            Console.WriteLine("how much you bet on orphelins game?");
            int userbet = Convert.ToInt32(Console.ReadLine());
            int roulettenumber = rand.Next(0, 36);
            CheckForOrphelins(roulettenumber, userbet);
        }
    }
}

string ColorToReturn(int interval)
{
    if (((interval >= 1) && (interval <= 10) && (interval % 2 == 1)) || ((interval >= 19) && (interval <= 28) && (interval % 2 == 1)))
    {
        return "red";
    }
    else if (((interval >= 1) && (interval <= 10) && (interval % 2 == 0)) || ((interval >= 19) && (interval <= 28) && (interval % 2 == 0)))
    {
        return "black";
    }
    else if (((interval >= 11) && (interval <= 18) && (interval % 2 == 1)) || ((interval >= 29) && (interval <= 36) && (interval % 2 == 1)))
    {
        return "black";
    }
    else if (((interval >= 11) && (interval <= 18) && (interval % 2 == 0)) || ((interval >= 29) && (interval <= 36) && (interval % 2 == 0)))
    {
        return "red";
    }
    return "green";
}

void CheckForManyNumbers(CurrentNumber[] numbers, List<int> betnumbers, int userbet, int roulettenumber)
{
    int counter = 0;
    for (int i = 0; i < betnumbers.Count; i++)
    {
        if (betnumbers.ElementAt(i) == roulettenumber)
        {
            int wonmoney = userbet * 18 / betnumbers.Count;
            startmoney += wonmoney;
            Console.WriteLine("You win, " + wonmoney + " ,winning number was" + roulettenumber + " now you have " + startmoney + "$");
            break;
        }
        else
        {
            counter++;
            if (betnumbers.Count == counter)
            {
                startmoney -= userbet;
                Console.WriteLine("You lose " + userbet + " dollars and you have left " + startmoney + " $");
                break;
            }
        }
    }
}

void CheckForSingleNumber(int userbetnumber, int roulettenumber, int userbet)
{
    if (userbetnumber == roulettenumber)
    {
        userbet *= 36;
        startmoney += userbet;
        Console.WriteLine("You Win " + userbet + "$" + " ,you have " + startmoney + " dollars");
    }else
    {
        startmoney -= userbet;
        Console.WriteLine("You lose, winngin number was " + roulettenumber + " ,now you have left "  + startmoney + "$");
    }
}

void CheckForColor(CurrentNumber[] numbers, int roulettenumber, int userbet, string userbetcolor)
{
    if(numbers[roulettenumber].Color == userbetcolor)
    {
        startmoney += userbet * 0.2;
        Console.WriteLine("You win " + (double)(userbet + (userbet * 0.2)) + " dollars and now you have " + startmoney + "$");
    } else
    {
        startmoney -= userbet;
        Console.WriteLine("You lose, winning color was " + numbers[roulettenumber].Color + " and you lose " + userbet + " dollars, you have left " + startmoney);
    }
}

void CheckZeroGame(int roulettenumber, int userbet)
{
    if(roulettenumber == 12 || roulettenumber == 35 || roulettenumber == 3 || roulettenumber == 26 || roulettenumber == 0 || roulettenumber == 32 || roulettenumber == 15)
    {
        int wonmoney = userbet * 15 / 6;
        startmoney += wonmoney;
        Console.WriteLine("You win " + wonmoney + " dollars and now you have " + startmoney + "$");
    } else
    {
        startmoney -= userbet;
        Console.WriteLine("You lose, winngin number was " + roulettenumber + " ,now you have left " + startmoney + "$");
    }
}


void CheckForOrphelins(int roulettenumber, int userbet)
{
    if (roulettenumber == 17 || roulettenumber == 34 || roulettenumber == 6 || roulettenumber == 20 || roulettenumber == 1 || roulettenumber == 14 || roulettenumber == 31 || roulettenumber == 9)
    {
        int wonmoney = userbet * 9 / 7;
        startmoney += wonmoney;
        Console.WriteLine("You win " + wonmoney + " dollars and now you have " + startmoney + "$");
    }
    else
    {
        startmoney -= userbet;
        Console.WriteLine("You lose, winngin number was " + roulettenumber + " ,now you have left " + startmoney + "$");
    }
}