using System;

namespace cricarba.BinaryTree
{
    internal static class RandomGenerator
    {
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        internal const int Max = 10000;
        public static int RandomNumber()
        {
            lock (syncLock)
            {
                return random.Next(1, Max);
            }
        }
    }
}
