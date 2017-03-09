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
        T GetElement(int index);

    }
}
