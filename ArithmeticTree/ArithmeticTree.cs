using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticTree
{
    /// <summary>
    /// Represent an ArithmeticTree for calculating arithmetic expression
    /// </summary>
    /// <typeparam name="T">Type of the node data</typeparam>
    class ArithmeticTree<T> : BinaryTree<T> 
    {
        /// <summary>
        /// Main root of the tree
        /// </summary>
        private Node<T> root;

        /// <summary>
        /// Default constructor
        /// </summary>
        public ArithmeticTree()
        {
            
        }

        /// <summary>
        /// Return the data of the selected node
        /// </summary>
        /// <param name="index">Position of the element</param>
        /// <returns>The element</returns>
        public T GetElement(int index)
        {
            throw new NotImplementedException();
        }
    }
}
