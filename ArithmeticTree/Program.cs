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
            IBinaryTree<string> expression1 = TreeFactory.CreateArithmeticTree("(1+2)+4/3");

            foreach (Node<string> element in expression1)
                Console.WriteLine(element.Data.ToString());

            Console.WriteLine("--------------------------");
            Console.WriteLine("Answer : " + ((ArithmeticTree) expression1).SolveTree());
            Console.WriteLine("--------------------------");

            foreach (Node<string> element in expression1.Clone())
                Console.WriteLine(element.Data.ToString());

            Console.Write("\nPress a key to continue . . .");
            Console.ReadKey();
        }
    }
}
