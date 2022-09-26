/* Dalton Wright MIS-221-002 PA-2 */
// can convert any of the 5 currencies to the other '4' // also handles cash more accurately using decimals // Runs until Exit or Improper Choice is made
// could handle cash better with a class which defines a fixed point type // Used arrays to store possible currency names & conversions // 
// Used the built in method 'Dictionary' to pair a key(currencyName) to a value (currencyConversionRate) *is a implementation of hash tables //

Menu();//calls menu Method

static void Menu()
{
    bool isRunning = true; // bool which defaults to true when the program is running, when user "Exits" it ends the program by being "false"
    while (isRunning == true) //menu repeats until bool == false
    {
        Console.WriteLine("Would you like to use the 'Budget Calculator', 'Currency Converter' or 'Exit'?"); //choices for Menu
        string? inputChoice = Console.ReadLine(); // I'm assuming input isn't null

        if (inputChoice.Contains("Budget Calculator")) Budget(); // start of selection panel; Call Budget
        else if (inputChoice.Contains("Currency Converter")) Converter(); // Call Converter
        else if (inputChoice.Contains("Exit"))
        { // Choice is to Exit
            System.Console.WriteLine("GoodBye!"); // bye message
            isRunning = false; // stops while Loop criteria
        }
        else
        {
            System.Console.WriteLine($"None of your selections were valid, GoodBye!\n");
            isRunning = false; // stops while Loop criteria
        }
    }//endWhile for selection panel;
}//endMenu;

static void Budget()// called from "Budget Calculator" in selection panel
{
    System.Console.WriteLine("What is your overall monthly income?"); // asking user for income
    decimal monthlyIncome = decimal.Parse(Console.ReadLine()); // reading input
    if (monthlyIncome <=0 )System.Console.WriteLine("You Don't have an Income, try again with a number greater than Zero!\n");
    else // checking if the User's income is valid
    {
        System.Console.WriteLine("You put $" + (decimal.Multiply((decimal)monthlyIncome, (decimal).20)).ToString("0.00") + " in Savings\nHow many people live in your house?");
        monthlyIncome = (decimal)monthlyIncome - (decimal.Multiply((decimal)monthlyIncome, (decimal).20)); // removing savings from money to spend
        int familyMembers = int.Parse(Console.ReadLine()); // assuming Readline isn't empty; how many family members live in the house 
        if(familyMembers<=0) // checking that user didn't input an invalid number of family members
        {
            Compare((decimal.Multiply(monthlyIncome, (decimal).25)), "Housing"); //calling method to compare budget to money spent & print output using the % allotted to each 
            Compare((decimal.Multiply(monthlyIncome, (decimal).16)), "Food");
            Compare((decimal.Multiply(monthlyIncome, (decimal).15)), "Transportation");
            Compare(((decimal.Multiply(monthlyIncome, (decimal).25)) / familyMembers), "Entertainment"); // extra step to split Entertainment by # of people in house
            Compare((decimal.Multiply(monthlyIncome, (decimal).11)), "Utilities");
            Compare((decimal.Multiply(monthlyIncome, (decimal).08)), "Clothing"); // last method call to compare budget
        }
        else System.Console.WriteLine("Try again, you inputed an invalid number of people living in your House!\n");
    }
}//endBudget

static void Compare(decimal budget, string string1)// method to compare budget to money spent & print output
{
    System.Console.WriteLine($"Your available Budget for {string1} is $" + budget.ToString("0.00") + "\nHow much did you spend?"); // asking how much you spent
    decimal moneySpent = decimal.Parse(Console.ReadLine());//input amount spent on a provided expense (ex housing, food)

    //checking if moneyspent is greater than, less than ,or equal to the budget
    if (budget - moneySpent < 0) System.Console.WriteLine($"You went over your Budget by ${(-(budget - moneySpent)).ToString("0.00")}\n"); //over budget
    else if (budget - moneySpent > 0) System.Console.WriteLine($"You are under your Budget! Your leftover money is ${(budget - moneySpent).ToString("0.00")}\n"); //under budget printLine
    else if (budget - moneySpent == 0) System.Console.WriteLine("Good Job! you are exactly on Budget.\n"); // on budget printLine
}

static void Converter()// method for "Currency Converter"
{//                                          0                1             2               3                 4
    string[] currency = new string[5] { "US Dollar", "British Pound", "Swiss Franc", "Indian Rupee", "Canadian Dollar" }; // arr of str to assign Currency to a position (0,1,2etc)
    decimal[] CR = new decimal[4] { 0.863m, 0.980m, 79.580m, 1.315m }; // array of base conversion rates from USD -> Other
    System.Console.WriteLine("Would you like to convert from US Dollar, British Pound, Swiss Franc, Indian Rupee, or Canadian Dollar?\n");
    string? begCurrency = Console.ReadLine(); //what currency would you like to convert from?
    System.Console.WriteLine("Would you like to convert to US Dollar, British Pound, Swiss Franc, Indian Rupee, or Canadian Dollar?\n");
    string? endCurrency = Console.ReadLine(); //what would you like to convert to?

    if (currency.Any(begCurrency.Contains) && currency.Any(endCurrency.Contains)) // checks if starting and ending currencies are valid
    {
        System.Console.WriteLine("How much money would you like to convert?");
        decimal moneyToConvert = decimal.Parse(Console.ReadLine()); // amount of $ to convert?

        Dictionary<string, decimal> conversionHoldDict = new Dictionary<string, decimal>(); // hash table implementation to bind a key(string) to a value(decimal)

        decimal[] conversionHold = new decimal[24]{ //array holding the "values" which will be bound to a key in the dictionary
        CR[0], CR[1], CR[2],CR[3], //array to hold all conversions possible from USD
        1/CR[0],0,(1/CR[0])*CR[1],(1/CR[0])*CR[2],(1/CR[0])*CR[3],//from British Pound
        1/CR[1],(1/CR[1])*CR[0],0,(1/CR[1])*CR[2],(1/CR[1])*CR[3],//from Swiss Franc
        1/CR[2],(1/CR[2])*CR[0],(1/CR[2])*CR[1],0,(1/CR[2])*CR[3],//from Indian Rupee
        1/CR[3],(1/CR[3])*CR[0],(1/CR[3])*CR[1],(1/CR[3])*CR[2],0};//from Canadian Dollar // could get rid of most of this if pulling directly from forex market?

        for (int i = 0; i < 5; i++) //  cannot convert to the currency you're converting from (EX.) cannot be USD -> USD
        {  // creating key & assigning conversion values for all possibles outcomes, the key depends on the currencies to be converted Ex.("US DollarBritish Pound" = 0.863m);
            if (i < 4 && currency[i + 1] != "US Dollar") conversionHoldDict.Add(currency[0] + currency[i + 1], conversionHold[i]);  //USD to Everything Else
            if (i < 5 && currency[i] != "British Pound") conversionHoldDict.Add(currency[1] + currency[i], conversionHold[i + 4]);  //BP to Everything Else // +4 increments to the next section of array
            if (i < 5 && currency[i] != "Swiss Franc") conversionHoldDict.Add(currency[2] + currency[i], conversionHold[i + 9]);  //SF to Everything Else // +9 incs to next section of arr
            if (i < 5 && currency[i] != "Indian Rupee") conversionHoldDict.Add(currency[3] + currency[i], conversionHold[i + 14]);  //IR to Everything Else // +14 incs to next section of arr
            if (i < 5 && currency[i] != "Canadian Dollar") conversionHoldDict.Add(currency[4] + currency[i], conversionHold[i + 19]); //CD to Everything Else // +19 incs to next section of arr
        }
        System.Console.WriteLine($"{moneyToConvert} {begCurrency} converts to {(moneyToConvert * conversionHoldDict[begCurrency + endCurrency]).ToString("0.00")} {endCurrency}\n");
    }// output of currency converter^
    else System.Console.WriteLine("The Currencies you Selected were not Valid\n"); // runs if the 2 inputed currencies aren't valid
} 