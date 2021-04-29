using System;

namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = System.ConsoleColor.Red;
            var i = 1;
            while (i<100)
            {
                SenderMessage sm = new SenderMessage();
                sm.SetConfigs();
                i++;
            }
            Console.ReadLine();
         
            
    
        }
    }
}
