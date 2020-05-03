using System.Collections.Generic;

namespace cricarba.BinaryTree
{
    internal class Node
    {
        internal int Id { get; set; }
        internal Node Left { get; set; }
        internal Node Right { get; set; }
        internal Node Parent { get; set; }
        internal Node()
        {
            Left = null;
            Right = null;
        }

        internal void InsertChildNodes()
        {
            if (Left == null)
                Left = new Node { Parent = this, Id = RandomGenerator.RandomNumber() };
            if (Right == null)
                Right = new Node { Parent = this, Id = RandomGenerator.RandomNumber() };
        }

        internal void InsertRandomChildNode(int child)
        {

            if (child < (RandomGenerator.Max / 2))
            {
                if (Left == null)
                    Left = new Node { Parent = this, Id = child };
                else
                    Left.InsertRandomChildNode(RandomGenerator.RandomNumber());
            }
            else
            {
                if (Right == null)
                    Right = new Node { Parent = this, Id = child };
                else
                    Right.InsertRandomChildNode(RandomGenerator.RandomNumber());
            }
        }

        internal Node SearchNodeAncestor(Node root, int idSearched)
        {
            Node result = null;
            if (root.Left?.Id == idSearched || root.Right?.Id == idSearched)
                result = root;

            if (result == null && root.Left != null)
                result = SearchNodeAncestor(root.Left, idSearched);

            if (result == null && root.Right != null)
                result = SearchNodeAncestor(root.Right, idSearched);

            return result;
        }

        internal Node SearchNode(Node root, int idSearched)
        {
            Node result = null;
            if (root.Left?.Id == idSearched)
                result = root.Left;
            if (root.Right?.Id == idSearched)
                result = root.Right;

            if (result == null && root.Left != null)
                result = SearchNode(root.Left, idSearched);

            if (result == null && root.Right != null)
                result = SearchNode(root.Right, idSearched);

            return result;
        }

        internal void PrintNode(Node root, List<string> list)
        {
            if (root.Left != null)
                list.Add($"Node {root.Id} Left Child {root.Left.Id}");

            if (root.Right != null)
                list.Add($"Node {root.Id} Rigth Child {root.Right.Id}");
            
            if (root.Left != null)
                PrintNode(root.Left, list);

            if (root.Right != null)
                PrintNode(root.Right, list);
        }

        internal int SearchCommonParent(Node one, Node two)
        {
            int ancestor = 0;
            List<int> parentsNodeOne = new List<int>();
            List<int> parentsNodeTwo = new List<int>();

            SearchCommonParent(one, parentsNodeOne);
            SearchCommonParent(two, parentsNodeTwo);

            int greaterCount = parentsNodeOne.Count > parentsNodeTwo.Count ? parentsNodeOne.Count : parentsNodeTwo.Count;
            int lessCount = parentsNodeOne.Count > parentsNodeTwo.Count ? parentsNodeTwo.Count : parentsNodeOne.Count;

            for (int i = 0; i < greaterCount -1; i++)
            {
                for (int j = 0; j < lessCount -1 ; j++)
                {
                    if (parentsNodeOne[i] == parentsNodeTwo[j])
                    {
                        ancestor = parentsNodeOne[i];
                        break;
                    }
                }
                if (ancestor > 0)
                    break;
            }

            return ancestor;

        }

        internal void SearchCommonParent(Node one, List<int> list)
        {
            if (one?.Parent != null)
            {
                list.Add(one.Parent.Id);
                SearchCommonParent(one.Parent, list);
            }
        }
    }
}
