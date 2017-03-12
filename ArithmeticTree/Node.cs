using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticTree
{
    /// <summary>
    /// Represent a node of type T of a data structure
    /// </summary>
    /// <typeparam name="T">Element to contain</typeparam>
    class Node<T>
    {
        /// <summary>
        /// Data that the node hold
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Node()
        {
            
        }

        /// <summary>
        /// Constructor with data
        /// </summary>
        /// <param name="data">Information to hold</param>
        public Node(T data)
        {
            Data = data;
        }

        /// <summary>
        /// Parent node
        /// </summary>
        public Node<T> ParentNode { get; set; }

        /// <summary>
        /// Left sibling
        /// </summary>
        public Node<T> LeftNode { get; set; }

        /// <summary>
        /// Right sibling
        /// </summary>
        public Node<T> RightNode { get; set; }
        
        /// <summary>
        /// Return an array with all the siblings
        /// </summary>
        /// <param name="node">Parent node</param>
        /// <returns>Table of Nodes</returns>
        IEnumerable<Node<T>> GetChildren(Node<T> node)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Check if the tree has siblings, if yes, it's internal
        /// </summary>
        /// <returns>True if internal, else external</returns>
        public bool IsInternal()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Check if the tree has siblings, if no, it's external
        /// </summary>
        /// <returns>True if external, else internal</returns>
        public bool IsExternal()
        {
            throw new NotImplementedException();
        }
    }
}
