using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Excercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();
            TreeNode<string> root = tree.MakeTree();
            tree.PrintTree(root);
            Console.WriteLine(tree.GetHeight(root));
        }
    }
}