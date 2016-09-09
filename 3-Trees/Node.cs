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
    }
}
