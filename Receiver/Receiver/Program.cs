
using System;
using System.Text;

namespace Receiver
{
    class Program
    {
        static void Main(string[] args)
        {
            ReceiverMessage rm = new ReceiverMessage();
            rm.GetMessage();
            Console.ReadLine();
        }
    }
    
}
