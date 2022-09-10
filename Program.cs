Console.WriteLine("Would you like to use the 'Budget Calculator', 'Currency Converter' or 'Exit'?");

string inputChoice = Console.ReadLine(); //assuming input isn't null / empty; could fix with if(null) but this is a simple program
if(inputChoice.Contains("Budget Calculator")) Budget();
else if(inputChoice.Contains("Currency Converter"))Converter();
else if(inputChoice.Contains("Exit"))
{
    System.Console.WriteLine($"Goodbye!\n{Environment.ExitCode}");
}
else  
{
    System.Console.WriteLine($"None of your selections were valid, Goodbye!\n{Environment.ExitCode}");
}
static void Budget()
{
    System.Console.WriteLine("What is your overall monthly income?");
    decimal monthlyIncome = decimal.Parse(Console.ReadLine());
    System.Console.WriteLine("You put $" + (decimal.Multiply((decimal)monthlyIncome,(decimal).20)).ToString("0.00")+" in Savings\n");
    System.Console.WriteLine("How many people live in your house?");
    int familyMembers = int.Parse(Console.ReadLine()); // assuming Readline isn't empty
    Creator((decimal.Multiply(monthlyIncome,(decimal).25)), "housing");
    Creator((decimal.Multiply(monthlyIncome,(decimal).16)), "Food");
    Creator((decimal.Multiply(monthlyIncome,(decimal).15)), "Transportation");
    Creator(((decimal.Multiply(monthlyIncome,(decimal).25))/familyMembers), "Entertainment");
    Creator((decimal.Multiply(monthlyIncome,(decimal).11)),"Utilities");
    Creator((decimal.Multiply(monthlyIncome,(decimal).08)), "Clothing");
}
static void Converter()
{
    string begCurrency = System.String.Empty;
    string finalCurrency = System.String.Empty;
    System.Console.WriteLine("How much money would you like to convert?");
    decimal totalCurrency = decimal.Parse(Console.ReadLine());
    System.Console.WriteLine("Which Currency would you like to transfer from?");
    begCurrency = Console.ReadLine();
    System.Console.WriteLine("Which Currency would you like to transfer to?");
    finalCurrency = Console.ReadLine();

    const decimal US_Dollar = 1.00M;
    const decimal British_Pound = 0.863M;
    const decimal Swiss_Franc = 0.980M;
    const decimal Indian_Rupee = 79.580M;
    const decimal Canadian_Dollar = 1.315M;

    if(begCurrency == "US Dollar")
    {
        if(finalCurrency == "British Pound") ConvertUSD(begCurrency, finalCurrency,US_Dollar, British_Pound, totalCurrency);
        else if(finalCurrency == "Swiss Franc") ConvertUSD(begCurrency, finalCurrency,US_Dollar, Swiss_Franc, totalCurrency);
        else if(finalCurrency == "Indian Rupee") ConvertUSD(begCurrency, finalCurrency,US_Dollar, Indian_Rupee, totalCurrency);
        else if(finalCurrency == "Canadian Dollar") ConvertUSD(begCurrency, finalCurrency,US_Dollar, Canadian_Dollar, totalCurrency);
    }
    if(begCurrency == "British Pound") 
    {
        if (finalCurrency =="Swiss Franc")ConvertUSD(begCurrency,finalCurrency,ConvertUSDnoPrint(begCurrency,finalCurrency,British_Pound,US_Dollar,totalCurrency),Swiss_Franc,totalCurrency);
        else if(finalCurrency =="US Dollar")ConvertUSD(begCurrency,finalCurrency,ConvertUSDnoPrint(begCurrency,finalCurrency,British_Pound,US_Dollar,totalCurrency),US_Dollar,totalCurrency);
        else if(finalCurrency =="Indian Rupee")ConvertUSD(begCurrency,finalCurrency,ConvertUSDnoPrint(begCurrency,finalCurrency,British_Pound,US_Dollar,totalCurrency),Indian_Rupee,totalCurrency);
        else if(finalCurrency =="Canadian Dollar")ConvertUSD(begCurrency,finalCurrency,ConvertUSDnoPrint(begCurrency,finalCurrency,British_Pound,US_Dollar,totalCurrency),Canadian_Dollar,totalCurrency);
    }
    if(begCurrency == "Swiss Franc") 
    {
        if (finalCurrency =="US Dollar")ConvertUSD(begCurrency,finalCurrency,Swiss_Franc,US_Dollar,totalCurrency);
        else if(finalCurrency =="British Pound")ConvertUSD(begCurrency,finalCurrency,ConvertUSDnoPrint(begCurrency,finalCurrency,Swiss_Franc,US_Dollar,totalCurrency),British_Pound,totalCurrency);
        else if(finalCurrency =="Indian Rupee")ConvertUSD(begCurrency,finalCurrency,ConvertUSDnoPrint(begCurrency,finalCurrency,Swiss_Franc,US_Dollar,totalCurrency),Indian_Rupee,totalCurrency);
        else if(finalCurrency =="Canadian Dollar")ConvertUSD(begCurrency,finalCurrency,ConvertUSDnoPrint(begCurrency,finalCurrency,Swiss_Franc,US_Dollar,totalCurrency),Canadian_Dollar,totalCurrency);
    }
    if(begCurrency == "Indian Rupee") 
    {
        if(finalCurrency =="US Dollar")System.Console.WriteLine(totalCurrency + " " + begCurrency + " converts to " + (totalCurrency/Indian_Rupee).ToString("0.00")+" "+ finalCurrency);
        else if(finalCurrency =="British Pound") System.Console.WriteLine(totalCurrency + " " + begCurrency + " converts to " + ((totalCurrency/Indian_Rupee)*British_Pound).ToString("0.00")+" "+finalCurrency); 
        else if(finalCurrency =="Swiss Franc") System.Console.WriteLine(totalCurrency + " " + begCurrency + " converts to " + ((totalCurrency/Indian_Rupee)*Swiss_Franc).ToString("0.00")+" "+finalCurrency); 
        else if(finalCurrency =="Canadian Dollar") System.Console.WriteLine(totalCurrency + " " + begCurrency + " converts to " + ((totalCurrency/Indian_Rupee)*Canadian_Dollar).ToString("0.00")+" "+finalCurrency); 
    }
    if(begCurrency == "Canadian Dollar") 
    {
        if(finalCurrency =="US Dollar")System.Console.WriteLine(totalCurrency + " " + begCurrency + " converts to " + (totalCurrency/Canadian_Dollar).ToString("0.00")+" "+ finalCurrency);
        else if(finalCurrency =="British Pound") System.Console.WriteLine(totalCurrency + " " + begCurrency + " converts to " + ((totalCurrency/Canadian_Dollar)*British_Pound).ToString("0.00")+" "+finalCurrency); 
        else if(finalCurrency =="Swiss Franc") System.Console.WriteLine(totalCurrency + " " + begCurrency + " converts to " + ((totalCurrency/Canadian_Dollar)*Swiss_Franc).ToString("0.00")+" "+finalCurrency); 
        else if(finalCurrency =="Indian Rupee") System.Console.WriteLine(totalCurrency + " " + begCurrency + " converts to " + ((totalCurrency/Canadian_Dollar)*Indian_Rupee).ToString("0.00")+" "+finalCurrency); 

    }
}  
static void Creator(decimal num1, string string1)
{
    System.Console.WriteLine($"Your available Budget for {string1} is $" + num1.ToString("0.00") + "\nHow much did you spend?");
    PrintBudget((decimal)num1, decimal.Parse(Console.ReadLine()));
}
static void PrintBudget(decimal budget, decimal moneySpent)
{
    if(budget-moneySpent<0)
    {
        System.Console.WriteLine($"You went over your Budget by ${(-(budget-moneySpent)).ToString("0.00")}\n");
    }
    else if(budget-moneySpent>0) // known issue: If leftover money > 0.001 it shows overage but total leftover is 0.00 due to bank rounding;
    {
        System.Console.WriteLine($"You are under your Budget! Your leftover money is ${(budget-moneySpent).ToString("0.00")}\n");
    }
    else if(budget-moneySpent==0) System.Console.WriteLine("Good Job! you are exactly on Budget.\n");
}
static void ConvertUSD(string begCurrency, string finalCurrency, decimal num1, decimal num2, decimal totalCurrency)
{
    System.Console.WriteLine(totalCurrency + " "+ begCurrency+ " converts to "+((num1*num2)*totalCurrency).ToString("0.00")+ " "+finalCurrency);
}
static decimal ConvertUSDnoPrint(string begCurrency, string finalCurrency, decimal num1, decimal num2, decimal totalCurrency)
{
    return ((num1*num2));
}