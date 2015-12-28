namespace TestTicketRequest
{
    using Argentina.Access;

    public class MainClass
    {
        public static void Main (string[] args)
        {
            string cert;
            string key;
            uint minutes;
            if (args.Length != 3)
            {
                System.Console.WriteLine ("Forma de uso: TestTicketRequest certficado key minutos");
            }
            else
            {
                cert = args[0];
                key = args[1];
                minutes = uint.Parse (args[2]);
                LoginTicket ticket = new LoginTicket (cert, key, minutes, true);
            }
        }
    }
}
