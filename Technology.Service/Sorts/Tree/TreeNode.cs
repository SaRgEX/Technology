using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technology.Service.Sorts.Tree
{
    public class TreeNode
    {
        public TreeNode(char data)
        {
            Data = data;
        }

        public char Data { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public void Insert(TreeNode node)
        {
            if (node.Data < Data)
            {
                if (Left == null)
                    Left = node;
                else
                    Left.Insert(node);
            }
            else
            {
                if (Right == null)
                    Right = node;
                else
                    Right.Insert(node);
            }
        }

        public char[] Transform(List<char> elements = null)
        {
            if (elements == null)
                elements = new List<char>();

            if (Left != null)
                Left.Transform(elements);

            elements.Add(Data);

            if (Right != null)
                Right.Transform(elements);

            return elements.ToArray();
        }
    }
}
