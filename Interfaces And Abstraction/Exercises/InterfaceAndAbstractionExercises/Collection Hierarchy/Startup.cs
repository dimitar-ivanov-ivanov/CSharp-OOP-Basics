namespace Collection_Hierarchy
{
    using Collection_Hierarchy.Models;
    using System;
    using System.Text;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var addCollection = new AddCollection<string>();
            var addRemoveCollection = new AddRemoveCollection<string>();
            var myList = new MyList<string>();

            PrintAddingItems(addCollection, addRemoveCollection, myList);
            PrintRemoveItems(addRemoveCollection, myList);
        }

        private static void PrintRemoveItems(AddRemoveCollection<string> addRemoveCollection, MyList<string> myList)
        {
            var n = int.Parse(Console.ReadLine());
            var addRemoveCollectionOutput = new StringBuilder();
            var myListOutput = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                addRemoveCollectionOutput.Append(addRemoveCollection.Remove() + " ");
                myListOutput.Append(myList.Remove() + " ");
            }

            Console.WriteLine(addRemoveCollectionOutput);
            Console.WriteLine(myListOutput);
        }

        private static void PrintAddingItems(AddCollection<string> addCollection, AddRemoveCollection<string> addRemoveCollection, MyList<string> myList)
        {
            var addCollectionOutput = new StringBuilder();
            var addRemoveCollectionOutput = new StringBuilder();
            var myListOutput = new StringBuilder();

            var args = Console.ReadLine().Split(' ');

            for (int i = 0; i < args.Length; i++)
            {
                addCollectionOutput.Append(addCollection.Add(args[i]) + " ");

                addRemoveCollectionOutput.Append(addRemoveCollection.Add(args[i]) + " ");

                myListOutput.Append(myList.Add(args[i]) + " ");
            }

            Console.WriteLine(addCollectionOutput);
            Console.WriteLine(addRemoveCollectionOutput);
            Console.WriteLine(myListOutput);
        }
    }
}
