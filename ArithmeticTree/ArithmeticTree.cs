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
    class ArithmeticTree : BinaryTree<string> 
    {
        /// <summary>
        /// Main root of the tree
        /// </summary>
        private Node<string> _root;

        private int _size;

        /// <summary>
        /// Default constructor
        /// </summary>
        public ArithmeticTree()
        {
            
        }

        #region Implementation of BinaryTree<T>

        /// <summary>
        /// Return the data of the selected node
        /// </summary>
        /// <param name="index">Position of the element</param>
        /// <returns>The element</returns>
        public Node<string> GetElement(int index)
        {
            return null;
        }

        /// <summary>
        /// Return the root of the tree
        /// </summary>
        /// <returns>The root element</returns>
        public Node<string> GetRoot()
        {
            return null;
        }

        /// <summary>
        /// Return true or false depending if the tree is empty or not
        /// </summary>
        /// <returns>True if empty, else false</returns>
        public bool IsEmpty()
        {
            return false;
        }

        /// <summary>
        /// Return the number of node in the tree
        /// </summary>
        /// <returns>The size</returns>
        public int Size()
        {
            return 0;
        }

        /// <summary>
        /// Calculate the depth of the tree
        /// </summary>
        /// <returns>The height of the tree</returns>
        public int Height()
        {
            return 0;
        }

        /// <summary>
        /// The number of leaves (node without children) in the tree
        /// </summary>
        /// <returns>The number of leaves</returns>
        public int NumberOfLeaves()
        {
            return 0;
        }

        

        #endregion
    }
}
