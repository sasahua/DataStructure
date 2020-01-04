using System;

namespace ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList<int> intList = new ArrayList<int>();
            intList.Add(11);
            intList.Add(22);
            intList.Add(33);
            intList.Add(44);
            intList.Add(55);
            intList.Add(66);
            intList.Add(77);
            int delNum = intList.Remove(2);
            intList.Add(2, 333);
            intList.Set(2, 300);
            System.Console.WriteLine($"List:{intList},delete element:{delNum}");
        }
    }
}
