using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGA
{
    public class BinaryTree
    {
        public Node root;

        /**
         * Inserts a number into the tree
         */
        public void insert(int number)
        {
            if(root == null)
            {
                root = new Node(number);
                return;
            }
            root.insert(number);
        }

        /**
         * Delete a number from the tree
         */
        public void delete(int number)
        {
            if (root == null) return;
            root = root.delete(number);
        }

        public bool exists(int number)
        {
            if(root == null) return false;
            return root.exists(number);

        }

        /**
         * Returns the smallest value in the tree (or -1 if tree is empty)
         */
        public int min()
        {
            if (root == null) return -1;
            return root.min();
        }

        /**
         * Returns the largest value in the tree (or -1 if tree is empty)
         */
        public int max()
        {
           if (root == null) return -1;
           return root.max();
        }

        /**
         * Returns how many levels deep the deepest level in the tree is
         * (the empty tree is 0 levels deep, the tree with only one root node is 1 deep)
         * @return
         */
        public int depth()
        {
            if (root == null) return 0;
            return root.depth();
        }

        /**
         * Returns the amount of nodes in the tree
         * @return
         */
        public int count()
        {
            if (root == null) return 0;
            return root.count();
        }

        public void print()
        {
            if (root == null) return;
            List<int> sorted = root.sort();
            Console.WriteLine(string.Join(", ", sorted));
        }

        public void printInRange(int min, int max)
        {
            if (root == null) return;
            List<int> inRange = root.sort().Where(x => x >= min && x <= max).ToList();
            Console.WriteLine(string.Join(", ", inRange));
        }
    }
}
