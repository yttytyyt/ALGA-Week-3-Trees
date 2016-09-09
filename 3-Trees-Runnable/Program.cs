using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGA
{
    class Program
    {
        static void Main(string[] args)
        {
            /**
             *      10
             *     / \
             *    5   13
             *   / \   \
             *  3   7   16
             * /       /
             *1       15
             */
            BinaryTree tree = new BinaryTree();
            tree.root = new Node(10);
            tree.root.left = new Node(5);
            tree.root.left.left = new Node(3);
            tree.root.left.right = new Node(7);
            tree.root.left.left.left = new Node(1);
            tree.root.right = new Node(13);
            tree.root.right.right = new Node(16);
            tree.root.right.right.left = new Node(15);

            tree.print(); // Should print: 1 3 5 7 10 13 15 16
            tree.printInRange(5, 13); // Should print: 5, 7, 10, 13
        }
    }
}
