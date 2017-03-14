using System;
using System.Collections;
using System.Collections.Generic;

namespace ArithmeticTree
{
    /// <summary>
    /// Enumerator using inOrder traversal
    /// </summary>
    /// <typeparam name="T">Type of the tree</typeparam>
    public class InOrderTraversal<T> : IEnumerator<Node<T>>
    {
        private Node<T> _root;
        private Node<T> _next;

        #region Implementation of IEnumerator

        /// <summary>Gets the element in the collection at the current position of the enumerator.</summary>
        /// <returns>The element in the collection at the current position of the enumerator.</returns>
        public Node<T> Current { get; private set; }        

        /// <summary>
        /// Constructor for the iterator
        /// </summary>
        /// <param name="tree">Tree to iterate</param>
        public InOrderTraversal(IBinaryTree<T> tree)
        {
            _root = tree.GetRoot();
            _next = tree.GetRoot();

            if (_next == null)
                return;

            // Go far left
            while (_next.LeftNode != null)
                _next = _next.LeftNode;
        }

        /// <summary>Advances the enumerator to the next element of the collection.</summary>
        /// <returns>true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.</returns>
        /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception>
        public bool MoveNext()
        {
            // If next is null
            if (_next == null)
                return false;
            

            // Save the node to display or use. Then find the next
            Current = _next;

            // If you can go right then go right, then far left.
            // Otherwise, go up until you come from left.
            if (_next.RightNode != null)
            {
                // Go to right node
                _next = _next.RightNode;
                // Then far left
                while (_next.LeftNode != null)
                    _next = _next.LeftNode;
                // Return current node because we have found the next one
                return true;
            }
            else while (true)
            {
                // We reached the end of the tree
                if (_next.ParentNode == null)
                {
                    // Set to null and return current node
                    _next = null;
                    return true;
                }
                // To go back up.
                if (_next.ParentNode.LeftNode == _next)
                {
                    // Set next node to parent and return current
                    _next = _next.ParentNode;
                    return true;
                }
                // Until we are were we came from
                _next = _next.ParentNode;
            }
        }

        /// <summary>Sets the enumerator to its initial position, which is before the first element in the collection.</summary>
        /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception>
        public void Reset()
        {
            _next = _root;

            if (_next == null)
                return;

            // Go far left
            while (_next.LeftNode != null)
                _next = _next.LeftNode;
        }

        /// <summary>Gets the current element in the collection.</summary>
        /// <returns>The current element in the collection.</returns>
        object IEnumerator.Current => Current;

        #endregion

        #region Implementation of IDisposable

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
        }

        #endregion
    }

    /// <summary>
    /// Enumerable for the InOrderTraversal
    /// </summary>
    /// <typeparam name="T">Type of IEnumerable</typeparam>
    public class InOrderTraversalTree<T> : IEnumerable<Node<T>>
    {
        private IBinaryTree<T> _tree;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="pTree">Tree of the to traverse</param>
        public InOrderTraversalTree(IBinaryTree<T> pTree)
        {
            _tree = pTree;
        }

        #region Implementation of IEnumerable

        /// <summary>Returns an enumerator that iterates through the collection.</summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<Node<T>> GetEnumerator()
        {
            return new InOrderTraversal<T>(_tree);
        }

        /// <summary>Returns an enumerator that iterates through a collection.</summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new InOrderTraversal<T>(_tree);
        }

        #endregion
    }
}