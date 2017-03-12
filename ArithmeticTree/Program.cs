using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticTree
{
    /// <summary>
    /// Main class for the project
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Enter point of the project
        /// </summary>
        /// <param name="args">argument when launching project</param>
        static void Main(string[] args)
        {
            BinaryTree<string> expression1 = TreeFactory.CreateArithmeticTree("(5+2.24)*(2--1)");
        }
    }
}
