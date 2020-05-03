using System.Collections.Generic;

namespace cricarba.BinaryTree
{
    public class BinaryTree : ITree
    {
         

        /// <summary>
        /// El valor no puede ser mayor al definido en RandomGenerator.Max
        /// </summary>
        public int AmountNodes
        {
            get { return _AmountNodes; }
            set
            {
                if (value > RandomGenerator.Max)
                    _AmountNodes = RandomGenerator.Max;
                else
                    _AmountNodes = value;

            }
        }
        private int _AmountNodes { get; set; }
        internal Node Root { get; set; }
        public BinaryTree()
        {
            Root = new Node();
        }
        public void CreateRandomTree()
        {
            int ammount = 0;
            while (ammount < _AmountNodes)
            {
                int child = RandomGenerator.RandomNumber();
                Root.InsertRandomChildNode(child);
                ammount++;
            }
        }
        public int SearchAncestor(int nodeValue)
        {
            return Root.SearchNodeAncestor(Root, nodeValue).Id;
        }
        public int SearchCommonAncestor(int nodeOne, int nodeTwo)
        {
            Node firstNode = Root.SearchNode(Root, nodeOne);
            Node secondNode = Root.SearchNode(Root, nodeTwo);
            return Root.SearchCommonParent(firstNode, secondNode);
        }

        public string PrintTree()
        {
            List<string> ids = new List<string>();
            Root.PrintNode(Root, ids);
            return string.Join("\n", ids);
        }

    }
}
