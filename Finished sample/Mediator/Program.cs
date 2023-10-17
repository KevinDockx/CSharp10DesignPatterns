using Mediator;

Console.Title = "Mediator";

TeamChatRoom teamChatroom = new();

var sven = new Lawyer("Sven");
var kenneth = new Lawyer("Kenneth");
var ann = new AccountManager("Ann");
var john = new AccountManager("John");
var kylie = new AccountManager("Kylie");

teamChatroom.Register(sven);
teamChatroom.Register(kenneth);
teamChatroom.Register(ann);
teamChatroom.Register(john);
teamChatroom.Register(kylie);

ann.Send("Hi everyone, can someone have a look at file ABC123?  I need a compliance check.");
sven.Send("On it!");
sven.Send("Ann", "Could you join me in a Teams call?");
sven.Send("Ann", "All good :)");
ann.SendTo<AccountManager>("The file was approved!");

Console.ReadKey();