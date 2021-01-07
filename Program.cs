using System;
using System.Collections.Generic;

namespace MyDotNetCoreProject
{
    public class Program
    {
        public unsafe static void Main(string[] args)
        {
            delegate* managed<int, void> action = &Foo;  //可简写为delegate*<int, void>，但delegate* unmanaged<int, void>不可简写
            delegate*<int, void>[] actions = new delegate*<int, void>[1];
            actions[0] = action;
            for (int i = 0; i < actions.Length; i++)
            {
                actions[i](5);
            }
            IntPtr intPtr = (IntPtr)action;
            action = (delegate*<int, void>)intPtr;
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
