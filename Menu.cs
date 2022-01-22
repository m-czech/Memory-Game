using System;
using System.IO;

public class Menu
{
    public static void display()
    {
        Console.WriteLine("Choose game difficulty: ");
        Console.WriteLine("[ 1 ] Easy");
        Console.WriteLine("[ 2 ] Hard");
        Console.WriteLine("Enter your choice: ");

        int choice = int.Parse(Console.ReadLine());
    }


}