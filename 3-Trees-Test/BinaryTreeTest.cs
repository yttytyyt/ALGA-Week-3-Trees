using System;
using NUnit.Framework;
using ALGA;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ALGA_test
{
    [Category("BinaryTree")]
    public class BinaryTreeTest
    {
        private BinaryTree empty_tree;

        private BinaryTree only_root_tree;

        private BinaryTree three_nodes_tree;

        private BinaryTree big_tree;


        [SetUp]
        public void Setup()
        {
            empty_tree = new BinaryTree();

            only_root_tree = new BinaryTree();
            only_root_tree.root = new Node(5);

            /**
             *  5
             * / \
             *3   7 
             */
            three_nodes_tree = new BinaryTree();
            three_nodes_tree.root = new Node(5);
            three_nodes_tree.root.left = new Node(3);
            three_nodes_tree.root.right = new Node(7);

            /**
             *      10
             *     / \
             *    5   13
             *   / \   \
             *  3   7   16
             * /       /
             *1       15
             */
            big_tree = new BinaryTree();
            big_tree.root = new Node(10);
            big_tree.root.left = new Node(5);
            big_tree.root.left.left = new Node(3);
            big_tree.root.left.right = new Node(7);
            big_tree.root.left.left.left = new Node(1);
            big_tree.root.right = new Node(13);
            big_tree.root.right.right = new Node(16);
            big_tree.root.right.right.left = new Node(15);
        }
        
        [Test]
        public void BinaryTreeInsert()
        {
            empty_tree.insert(3);
            Assert.That(empty_tree.root.number, Is.EqualTo(3));
            Assert.That(empty_tree.root.left, Is.Null);
            Assert.That(empty_tree.root.right, Is.Null);

            only_root_tree.insert(0);
            only_root_tree.insert(10);
            Assert.That(only_root_tree.root.left.number, Is.EqualTo(0));
            Assert.That(only_root_tree.root.right.number, Is.EqualTo(10));

            big_tree.insert(14);
            big_tree.insert(8);
            Assert.That(big_tree.root.left.right.right.number, Is.EqualTo(8));
            Assert.That(big_tree.root.right.right.left.left.number, Is.EqualTo(14));
        }

        [Test]
        public void BinaryTreeDelete()
        {
            empty_tree.delete(5);

            only_root_tree.delete(5);
            Assert.That(only_root_tree.root, Is.Null);

            three_nodes_tree.delete(5);
            if(three_nodes_tree.root.number == 7)
            {
                Assert.That(three_nodes_tree.root.left.number, Is.EqualTo(3));
                Assert.That(three_nodes_tree.root.right, Is.Null);
            } else if(three_nodes_tree.root.number == 3)
            {
                Assert.That(three_nodes_tree.root.right.number, Is.EqualTo(7));
                Assert.That(three_nodes_tree.root.left, Is.Null);
            } else
            {
                Assert.Fail();
            }

            big_tree.delete(7);
            big_tree.delete(16);
            Assert.That(big_tree.root.left.right, Is.Null);
            Assert.That(big_tree.root.right.right.number, Is.EqualTo(15));
        }

        [Test]
        public void BinaryTreeExists()
        {
            Assert.That(empty_tree.exists(6), Is.False);

            Assert.That(only_root_tree.exists(7), Is.False);
            Assert.That(only_root_tree.exists(5), Is.True);

            Assert.That(big_tree.exists(14), Is.False);
            Assert.That(big_tree.exists(15), Is.True);
            Assert.That(big_tree.exists(16), Is.True);
            Assert.That(big_tree.exists(1), Is.True);
        }

        [Test]
        public void BinaryTreeMin()
        {
            Assert.That(empty_tree.min(), Is.EqualTo(-1));
            Assert.That(only_root_tree.min(), Is.EqualTo(5));
            Assert.That(three_nodes_tree.min(), Is.EqualTo(3));
            Assert.That(big_tree.min(), Is.EqualTo(1));
        }

        [Test]
        public void BinaryTreeMax()
        {
            Assert.That(empty_tree.max(), Is.EqualTo(-1));
            Assert.That(only_root_tree.max(), Is.EqualTo(5));
            Assert.That(three_nodes_tree.max(), Is.EqualTo(7));
            Assert.That(big_tree.max(), Is.EqualTo(16));
        }

        [Test]
        public void BinaryTreeDepth()
        {
            Assert.That(empty_tree.depth(), Is.EqualTo(0));
            Assert.That(only_root_tree.depth(), Is.EqualTo(1));
            Assert.That(three_nodes_tree.depth(), Is.EqualTo(2));
            Assert.That(big_tree.depth(), Is.EqualTo(4));
        }

        [Test]
        public void BinaryTreeCount()
        {
            Assert.That(empty_tree.count(), Is.EqualTo(0));
            Assert.That(only_root_tree.count(), Is.EqualTo(1));
            Assert.That(three_nodes_tree.count(), Is.EqualTo(3));
            Assert.That(big_tree.count(), Is.EqualTo(8));
        }

        [Test]
        public void BinaryTreePrint()
        {
            Setup();
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                three_nodes_tree.print();
                string expected = "3 5 7";
                Assert.That(sw.ToString().TrimStart().TrimEnd().Replace(",",""), Is.EqualTo(expected));
                StringBuilder sb = sw.GetStringBuilder();
                sb.Remove(0, sb.Length);
                big_tree.print();
                expected = "1 3 5 7 10 13 15 16";
                Assert.That(Regex.Replace(sw.ToString(), "[^0-9]+", " ").Trim(), Is.EqualTo(expected));
            }
        }

        [Test]
        public void BinaryTreePrintInRange()
        {
            Setup();
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                big_tree.printInRange(5, 15);
                string expected = "5 7 10 13 15";
                Assert.That(Regex.Replace(sw.ToString(), "[^0-9]+", " ").Trim(), Is.EqualTo(expected));
            }
        }
    }
}
