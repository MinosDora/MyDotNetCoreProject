using System;
using System.Collections.Generic;

namespace MyDotNetCoreProject
{
    public class Program
    {
        public unsafe static void Main(string[] args)
        {
            delegate* managed<int, void> action = &Foo;
            delegate* managed<int, void>[] actions = new delegate* managed<int, void>[1];
            actions[0] = action;
            for (int i = 0; i < actions.Length; i++)
            {
                actions[i](5);
            }
            IntPtr intPtr = (IntPtr)action;
            action = (delegate* managed<int, void>)intPtr;
            action(10);
            Console.WriteLine("Hello World!");
            Console.Read();
        }

        private static void Foo(int value)
        {
            Console.WriteLine(value); ;
        }
    }
}