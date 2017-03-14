using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticTree
{
    /// <summary>
    /// Represent an ArithmeticTree for calculating arithmetic expression
    /// </summary>    
    public class ArithmeticTree : IBinaryTree<string>
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
        
        /// <summary>
        /// Constructor with root
        /// </summary>
        /// <param name="pRoot">Root of the tree</param>
        /// <param name="pSize">Number of nodes</param>
        public ArithmeticTree(Node<string> pRoot, int pSize)
        {
            _root = pRoot;
            _size = pSize;
        }

        /// <summary>
        /// Clone a tree and all is nodes
        /// </summary>
        /// <returns>A copy of the original tree</returns>
        public IBinaryTree<string> Clone()
        {
            IBinaryTree<string> clone = new ArithmeticTree(this._root.Clone(null), this._size);
            return clone;
        }

        /// <summary>
        /// Solve the tree 
        /// </summary>
        /// <returns>The answer</returns>
        public double SolveTree()
        {
            return SolveLevel(_root.Clone(null));
        }

        /// <summary>
        /// Solve if level if the tree until reaching top using recursion
        /// </summary>
        /// <param name="current">the current nodee</param>
        /// <returns>double with the answer</returns>
        private double SolveLevel(Node<string> current)
        {
            double answer, answerLeft, answerRight;
           
            // Check if we can navigate right or left
            while (!double.TryParse(current.LeftNode.Data, NumberStyles.Any, CultureInfo.InvariantCulture, out answerLeft) ||
                   !double.TryParse(current.RightNode.Data, NumberStyles.Any, CultureInfo.InvariantCulture, out answerRight))
            {
                if (!double.TryParse(current.LeftNode.Data, NumberStyles.Any, CultureInfo.InvariantCulture, out answerLeft))
                    current = current.LeftNode;
                if (!double.TryParse(current.RightNode.Data, NumberStyles.Any, CultureInfo.InvariantCulture, out answerRight))
                    current = current.RightNode;
            }
            
            // Make the calculation with the data
            answer = GetCalulation(Double.Parse(current.LeftNode.Data.Replace('.', ',')), current.Data.ToString(), Double.Parse(current.RightNode.Data.Replace('.', ',')));

            //Set the old data to null
            current.Data = answer.ToString();
            current.RightNode = null;
            current.LeftNode = null;

            // Base condition to break
            if  (current.ParentNode == null)
                return answer;

            return SolveLevel(current.ParentNode);
        }

        /// <summary>
        /// Make the math according to the operators
        /// </summary>
        /// <param name="nb1">first number</param>
        /// <param name="op">operator</param>
        /// <param name="nb2">second number</param>
        /// <returns>the calculated number</returns>
        private double GetCalulation(double nb1, string op, double nb2)
        {
            double answer = 0.0;

            switch (op)
            {
                case "+":
                    answer = nb1 + nb2;
                    break;
                case "-":
                    answer = nb1 - nb2;
                    break;
                case "*":
                    answer = nb1 * nb2;
                    break;
                case "/":
                    answer = nb1 / nb2;
                    break;
                case "^":
                    answer = Math.Pow(nb1, nb2);
                    break;
                default:
                    throw new Exception("Invalid operator");
            }

            return answer;
        }


        #region Implementation of IBinaryTree<T>

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
            return _root;
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


        #region Implementation of IEnumerable

        /// <summary>Returns an enumerator that iterates through the collection.</summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<Node<string>> GetEnumerator()
        {
            return new InOrderTraversal<string>(this);
        }

        /// <summary>Returns an enumerator that iterates through a collection.</summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Return an InOrderTraversal Enumerator for this tree
        /// </summary>
        /// <returns>Enumerator</returns>
        public InOrderTraversalTree<string> GetInOrderTraversalEnumerator()
        {
            return new InOrderTraversalTree<string>(this);
        }

       

        #endregion
    }

    
}
