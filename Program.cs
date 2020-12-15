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

            Console.WriteLine("====================");

            int v1 = 0b01111111_11111111_11111111_11111111;
            Console.WriteLine(v1);
            Console.WriteLine(BitConverter.ToString(BitConverter.GetBytes(v1)));
            Console.WriteLine(v1 << 1);
            Console.WriteLine(BitConverter.ToString(BitConverter.GetBytes(v1 << 1)));

            Console.WriteLine("====================");

            v1 = -1;    //0b11111111_11111111_11111111_11111111;
            Console.WriteLine(v1);
            Console.WriteLine(BitConverter.ToString(BitConverter.GetBytes(v1)));
            Console.WriteLine(v1 << 1);
            Console.WriteLine(BitConverter.ToString(BitConverter.GetBytes(v1 << 1)));

            Console.WriteLine("====================");

            v1 = -1073741825;  //0b10111111_11111111_11111111_11111111;
            Console.WriteLine(v1);
            Console.WriteLine(BitConverter.ToString(BitConverter.GetBytes(v1)));
            Console.WriteLine(v1 << 1);
            Console.WriteLine(BitConverter.ToString(BitConverter.GetBytes(v1 << 1)));

            Console.Read();
        }

        private static void Foo(int value)
        {
            Console.WriteLine(value);
        }
    }
}