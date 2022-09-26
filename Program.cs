﻿//can convert any of the 5 currencies to the other '4' // also handles cash more accurately than with doubles//

Menu();//calls menu Method

static void Budget()// called from "Budget Calculator" in selection panel
{
    System.Console.WriteLine("What is your overall monthly income?"); // asking user for income
    decimal monthlyIncome = decimal.Parse(Console.ReadLine()); // reading input and depositing 20% to savings
    System.Console.WriteLine("You put $" + (decimal.Multiply((decimal)monthlyIncome,(decimal).20)).ToString("0.00")+" in Savings\nHow many people live in your house?");
    monthlyIncome = (decimal)monthlyIncome -(decimal.Multiply((decimal)monthlyIncome,(decimal).20)); // removing savings from money to spend
    int familyMembers = int.Parse(Console.ReadLine()); // assuming Readline isn't empty; how many family members live in the house
    
    Compare((decimal.Multiply(monthlyIncome,(decimal).25)), "Housing"); //calling method to compare budget to money spent & print output using the % allotted to each 
    Compare((decimal.Multiply(monthlyIncome,(decimal).16)), "Food");
    Compare((decimal.Multiply(monthlyIncome,(decimal).15)), "Transportation");
    Compare(((decimal.Multiply(monthlyIncome,(decimal).25))/familyMembers), "Entertainment"); // extra step to split Entertainment by # of people in house
    Compare((decimal.Multiply(monthlyIncome,(decimal).11)),"Utilities");
    Compare((decimal.Multiply(monthlyIncome,(decimal).08)), "Clothing"); // last method call to compare budget
}

static void Compare(decimal budget, string string1)// method to compare budget to money spent & print output
{
    System.Console.WriteLine($"Your available Budget for {string1} is $" + budget.ToString("0.00") + "\nHow much did you spend?"); // asking how much you spent
    decimal moneySpent = decimal.Parse(Console.ReadLine());//input amount spent on a provided expense (ex housing, food)

    //checking if moneyspent is > < or = to the budget
    if(budget-moneySpent<0)System.Console.WriteLine($"You went over your Budget by ${(-(budget-moneySpent)).ToString("0.00")}\n"); //over budget
    else if(budget-moneySpent>0)System.Console.WriteLine($"You are under your Budget! Your leftover money is ${(budget-moneySpent).ToString("0.00")}\n"); //under budget printLine
    else if(budget-moneySpent==0) System.Console.WriteLine("Good Job! you are exactly on Budget.\n"); // on budget printLine
}

static void Converter()// method for "Currency Converter"
{
    System.Console.WriteLine("Would you like to convert from US Dollar, British Pound, Swiss Franc, Indian Rupee, or Canadian Dollar?");
        string? begCurrency = Console.ReadLine(); //what currency would you like to convert from?
    System.Console.WriteLine("Would you like to convert to US Dollar, British Pound, Swiss Franc, Indian Rupee, or Canadian Dollar?\n");
        string? endCurrency = Console.ReadLine(); //what would you like to convert to?
    System.Console.WriteLine("How much money would you like to convert?");
        decimal moneyToConvert = decimal.Parse(Console.ReadLine()); // amount of $ to convert?
    
    Dictionary<string, decimal> conversionHoldDict = new Dictionary<string, decimal>(); // hash table(kind of) implementation to bind a key to a value
    string[] currency = new string [5]{"US Dollar", "British Pound","Swiss Franc","Indian Rupee","Canadian Dollar"}; // arr of str to assign Currency to a position (0,1,2etc)
    decimal[] CR = new decimal[4]{0.863m,0.980m,79.580m,1.315m}; // array of base conversion rates from USD -> Other

    decimal[] conversionHold = new decimal [24]{ //array holding the "values" which will be bound to a key in the dictionary
        CR[0], CR[1], CR[2],CR[3], //array to hold all conversions possible from USD
        1/CR[0],0,(1/CR[0])*CR[1],(1/CR[0])*CR[2],(1/CR[0])*CR[3],//from British Pound
        1/CR[1],(1/CR[1])*CR[0],0,(1/CR[1])*CR[2],(1/CR[1])*CR[3],//from Swiss Franc
        1/CR[2],(1/CR[2])*CR[0],(1/CR[2])*CR[1],0,(1/CR[2])*CR[3],//from Indian Rupee
        1/CR[3],(1/CR[3])*CR[0],(1/CR[3])*CR[1],(1/CR[3])*CR[2],0};//from Canadian Dollar
        
    for(int i=0; i<5; i++) //  cannot convert to the currency you're converting from (EX.) cannot be USD -> USD
    {  // creating key & assigning conversion values for all possibles outcomes, the key depends on the currencies to be converted ("US DollarBritish Pound" = 0.863m);
        if(i<4 && currency[i+1]!="US Dollar")conversionHoldDict.Add(currency[0] + currency[i+1], conversionHold[i]);  //USD to Everything Else
        if(i<5 && currency[i]!="British Pound")conversionHoldDict.Add(currency[1] + currency[i], conversionHold[i+4]);  //BP to Everything Else
        if(i<5 && currency[i]!="Swiss Franc")conversionHoldDict.Add(currency[2] + currency[i], conversionHold[i+9]);  //SF to Everything Else
        if(i<5 && currency[i]!="Indian Rupee")conversionHoldDict.Add(currency[3] + currency[i], conversionHold[i+14]);  //IR to Everything Else
        if(i<5 && currency[i]!="Canadian Dollar")conversionHoldDict.Add(currency[4] + currency[i], conversionHold[i+19]); //CD to Everything Else
    }
    System.Console.WriteLine($"{moneyToConvert} {begCurrency} converts to {(moneyToConvert * conversionHoldDict[begCurrency + endCurrency]).ToString("0.00")} {endCurrency}"); 
} // output of currency converter^

static void Menu()
{
    bool isRunning = true; // bool which defaults to true when the program is running, when user "Exits" it ends program by being "false"
    while(isRunning == true) //menu repeater until bool == false
    {
        Console.WriteLine("Would you like to use the 'Budget Calculator', 'Currency Converter' or 'Exit'?"); //choices for Menu
        string? inputChoice = Console.ReadLine(); // I'm assuming input isn't null / empty; could fix by checking readline !null

        if(inputChoice.Contains("Budget Calculator")) Budget(); // start of selection panel; Call Budget
        else if(inputChoice.Contains("Currency Converter")) Converter(); // Call Converter
        else if(inputChoice.Contains("Exit"))
        { // Choice is to Exit
            System.Console.WriteLine("GoodBye!"); // bye message
            isRunning = false;
        }
        else
        {
            System.Console.WriteLine($"None of your selections were valid, GoodBye!\n");
            isRunning = false;
        }
    }//endWhile for selection panel;
}//endMenu;