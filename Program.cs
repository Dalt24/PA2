Console.WriteLine("Would you like to use the 'Budget Calculator', 'Currency Converter' or 'Exit'?");

string inputChoice = Console.ReadLine();
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
    int familyMembers = int.Parse(Console.ReadLine());
    Creator((decimal.Multiply(monthlyIncome,(decimal).25)), "housing");
    Creator((decimal.Multiply(monthlyIncome,(decimal).16)), "Food");
    Creator((decimal.Multiply(monthlyIncome,(decimal).15)), "Transportation");
    Creator(((decimal.Multiply(monthlyIncome,(decimal).25))/familyMembers), "Entertainment");
    Creator((decimal.Multiply(monthlyIncome,(decimal).11)),"Utilities");
    Creator((decimal.Multiply(monthlyIncome,(decimal).08)), "Clothing");
}
static void Converter()
{
    System.Console.WriteLine("hiiiii");
}
static void Creator(decimal num1, string string1)
{
    System.Console.WriteLine($"Your available Budget for {string1} is $" + num1.ToString("0.00") + "\nHow much did you spend?");
    Print((decimal)num1, decimal.Parse(Console.ReadLine()));
}
static void Print(decimal budget, decimal moneySpent)
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
