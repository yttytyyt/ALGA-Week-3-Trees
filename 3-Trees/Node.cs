using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGA
{
    public class Node
    {
        public int number { get; private set; }

        public Node left;
        public Node right;

        public Node(int number)
        {
            this.number = number;
        }

        public void insert(int number)
        {
            if (number < this.number)
            {
                    
                if (left == null) left = new Node(number);
                else left.insert(number);
            }
            else
            {
                if (right == null) right = new Node(number);
                else right.insert(number);
            }
        }
        public void delete(int number)
        {
        }

        public bool exists(int number)
        {
            if (number == this.number) return true;
            if (number < this.number)
            {
                if (left == null) return false;
                return left.exists(number);
            }
            else
            {
                if (right == null) return false;
                return right.exists(number);
            }

        }

        public int min()
        {
            if (left == null) return number;
            return left.min();
        }

        public int max()
        {
            if (right == null) return number;
            return right.max();
        }

        public int depth()
        {
            int leftS = left?.depth() ?? 0;
            int rightS = right?.depth() ?? 0;
            return 1 + Math.Max(leftS, rightS);
        }

        public int count()
        {
            int leftTotal = left?.count() ?? 0;
            int rightTotal = right?.count() ?? 0;
            return 1 + leftTotal + rightTotal;
        }

        public List<int> sort()
          {
            List<int> result = new List<int>();
            if (left != null) result.AddRange(left.sort());
            result.Add(number);
            if (right != null) result.AddRange(right.sort());
            return result;
        }
    }
}
