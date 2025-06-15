using Task2;
using Task2.Interfaces;
using Task2.Realisations;


public static class Test
{
    public static async Task Main(string[] args)
    {
        var userRepository = new UserRepository();
        var senders = new Dictionary<int, ISender>() {
            { 0, new Sender1() }, 
            { 1, new Sender2() }, 
            { 2, new Sender3() }, 
            { 3, new Sender4() }, 
            { 4, new Sender5() }, 
        };
        var postman = new Postman(userRepository, senders, 7, 2);
        var messages = new List<IMessage>()
        { 
            new Message(0,"a"), 
            new Message(0,"a"), 
            new Message(0,"a"), 
            new Message(0,"a"), 
            new Message(0,"a"), 
            new Message(0,"a"), 
            new Message(0,"a"), 
            new Message(0,"a"), 
            new Message(0,"a"), 
            new Message(0,"a"), 
            new Message(0,"a"), 
            new Message(0,"a"), 
            new Message(0,"a"), 
            new Message(0,"a"), 
            new Message(1,"b"), 
            new Message(1,"b"), 
            new Message(1,"b"), 
            new Message(2,"c"), 
            new Message(2,"c"), 
            new Message(2,"c"),
            new Message(3,"d"),
            new Message(3,"d"),
            new Message(3,"d"),
            new Message(4,"e"),
            new Message(4,"e"),
            new Message(4,"e"),
        };
        await postman.SendAsync(messages);
        await postman.SendAsync(messages);
    }
}



