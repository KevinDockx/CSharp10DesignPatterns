using State;

Console.Title = "State";

BankAccount bankAccount = new();
bankAccount.Deposit(100);
bankAccount.Withdraw(500);
bankAccount.Withdraw(100);
// deposit enough to go to gold
bankAccount.Deposit(2000);
// should be in gold now
bankAccount.Deposit(100);
// back to overdraw
bankAccount.Withdraw(3000);
// should transition to regular
bankAccount.Deposit(3000);
// should still be in regular
bankAccount.Deposit(100);
Console.ReadKey();