namespace cricarba.BinaryTree
{
    public interface ITree
    {
        int AmountNodes { get; set; }
        void CreateRandomTree();
        int SearchAncestor(int nodeValue);
        int SearchCommonAncestor(int nodeOne, int nodeTwo);
        string PrintTree();

    }
}
