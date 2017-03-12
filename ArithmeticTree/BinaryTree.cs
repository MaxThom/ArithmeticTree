using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticTree
{
    /// <summary>
    /// Represent different fonctions all binary tree should have
    /// </summary>
    /// <typeparam name="T">Type of the node data</typeparam>
    interface BinaryTree<T>
    {
        /// <summary>
        /// Return the data of the selected node
        /// </summary>
        /// <param name="index">Position of the element</param>
        /// <returns>The element</returns>
        Node<T> GetElement(int index);

        /// <summary>
        /// Return the root of the tree
        /// </summary>
        /// <returns>The root element</returns>
        Node<T> GetRoot();

        /// <summary>
        /// Return true or false depending if the tree is empty or not
        /// </summary>
        /// <returns>True if empty, else false</returns>
        bool IsEmpty();

        /// <summary>
        /// Return the number of node in the tree
        /// </summary>
        /// <returns>The size</returns>
        int Size();

        /// <summary>
        /// Calculate the depth of the tree
        /// </summary>
        /// <returns>The height of the tree</returns>
        int Height();

        /// <summary>
        /// The number of leaves (node without children) in the tree
        /// </summary>
        /// <returns>The number of leaves</returns>
        int NumberOfLeaves();
    }
}
