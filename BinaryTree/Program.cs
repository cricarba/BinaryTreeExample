using cricarba.BinaryTree;
using System;

namespace BinaryTreeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ITree binaryTree = CreateTree();

            SearchAncestor(binaryTree);

            SearchCommonAncestor(binaryTree);

            Console.ReadLine();

        }

        private static void SearchCommonAncestor(ITree binaryTree)
        {
            WriteTitle("Primer Número para buscar ancestro común");
            string numberOne = Console.ReadLine();
            int.TryParse(numberOne, out int idOne);

            WriteTitle("Segundo número para buscar ancestro común");
            string numberTwo = Console.ReadLine();
            int.TryParse(numberTwo, out int idTwo);

            int ancestorCommon = binaryTree.SearchCommonAncestor(idOne, idTwo);
            WriteTitle("Ancestro común");
            Console.WriteLine(ancestorCommon);
        }

        private static void SearchAncestor(ITree binaryTree)
        {
            WriteTitle("Numero a buscar su ancestro");
            string number = Console.ReadLine();
            int.TryParse(number, out int idSearch);

            int ancestor = binaryTree.SearchAncestor(idSearch);
            WriteTitle("Ancestro");
            Console.WriteLine(ancestor);
        }

        private static ITree CreateTree()
        {
   

            WriteTitle("Cantidad de nodos a crear");
            string nodes = Console.ReadLine();
            int.TryParse(nodes, out int node);

            ITree binaryTree = new BinaryTree
            {               
                AmountNodes = node
            };

            binaryTree.CreateRandomTree();
            Console.WriteLine(binaryTree.PrintTree());
            return binaryTree;
        }

        private static void WriteTitle(string title)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(title);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
