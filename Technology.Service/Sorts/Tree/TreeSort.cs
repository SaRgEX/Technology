using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technology.Service.Sorts.Tree
{
    public static class TreeSort
    {
        public static string Sort(string data)
        {
            var tree = new TreeNode(data[0]);
            foreach (var item in data[1..])
            {
                tree.Insert(new TreeNode(item));
            }

            return new string(tree.Transform());
        }
    }
}
