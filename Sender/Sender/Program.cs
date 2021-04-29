using System;

namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------------Sender-------------------------");
 
            
            TaskPublisher tb=new TaskPublisher();
            tb.Publish();
            int i = 1;
            while (true)
            {
                Console.WriteLine("Type Message: ");
                string s = Console.ReadLine();
                tb.Message(s,i);
                i++;
            }
            
           
         
            
    
        }
    }
}
