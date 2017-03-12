using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticTree
{
    /// <summary>
    /// Use to create an tree from different type of information
    /// </summary>
    class TreeFactory
    {
        private static string _operators = "^*/+-()";
        private static string[][] _binaryOperator =
                                { 
                                 new[] {"^"},
                                 new[] {"*", "/"},
                                 new[] {"+", "-"},
                                };

        /// <summary>
        /// Create an arithmetic tree from a string expression
        /// </summary>
        /// <param name="expression">The mathematical expression</param>
        /// <returns>A Tree</returns>
        public static ArithmeticTree CreateArithmeticTree(string expression)
        {
            // Transform the expression into infix notation
            List<string> listPostFix = InfixToPostFix(ExpressionToList(expression));
            // Set root and current nood
            Node<string> root = new Node<string>(listPostFix.Last());
            Node<string> current = root;

            // Until we created every root
            for (int i = listPostFix.Count - 2; i >= 0; i--)
            {
                // Set parent, left or right 
                Node<string> next = new Node<string>(listPostFix[i]);
                next.ParentNode = current;

                if ((current.RightNode == null))
                    current.RightNode = next;
                else
                    current.LeftNode = next;

                // If next is an operator than change position
                // else go back up to find the next available left spot
                if (_operators.Contains(listPostFix[i]))
                    current = next;
                else if (current.LeftNode != null)
                {
                    while (true)
                    {
                        if (current.ParentNode == null)
                            break;
                        else if (current.ParentNode.LeftNode != null)
                            current = current.ParentNode;
                        else
                        {
                            current = current.ParentNode;
                            break;
                        }
                    }
                }
            }

            return new ArithmeticTree(root, listPostFix.Count);
        }

        /// <summary>
        /// Transform Infix notation to Postfix for easier tree creation
        /// </summary>
        /// <param name="expression">The mathematical expression</param>
        /// <returns>List of operators and numbers</returns>
        private static List<string> InfixToPostFix(List<string> expression)
        {
            List<string> output = new List<string>();
            Stack<string> operators = new Stack<string>();

            foreach (string element in expression)
            {
                // If open bracket, push
                if (element.Equals("("))
                    operators.Push(element);
                else if (element.Equals(")") && operators.Any())
                {
                    // Here we calculate everything in the bracket
                    // Until we reach the starting bracket
                    // We pop and put everything in the output array
                    while (!operators.Peek().Equals("("))
                        output.Add((operators.Pop().ToString()));
                    operators.Pop();
                }
                else if (_operators.Contains(element))
                {
                    if (operators.Any() && !operators.Peek().ToString().Equals("("))
                    {
                        // Get the priority of the new expression
                        int priority = HighestPriority(element, operators.Peek().ToString());

                        // If higher priority, just push. Else add the first in the stack on the output
                        if (priority == 1)
                            operators.Push(element);
                        else if (element.Equals(operators.Peek()))
                            operators.Push(element);
                        else if (priority < -1)
                        {
                            output.Add(operators.Pop().ToString());
                            bool continu = true;
                            while (continu)
                            {
                                if (operators.Any() && !operators.Peek().ToString().Equals("("))
                                {
                                    priority = HighestPriority(element, operators.Peek().ToString());
                                    output.Add(operators.Pop().ToString());
                                }
                                else
                                    continu = false;
                            }
                            operators.Push(element);
                        }
                    }
                    else
                        operators.Push(element);
                }
                else
                    // If it's a number, we simply push it
                    output.Add(element);
            }
            // Add remaining operators on the ouput list
            while (operators.Any())
                output.Add(operators.Pop().ToString());
            

            return output; 
        }

        /// <summary>
        /// Check which operator has to highest priority
        /// </summary>
        /// <param name="operator1">The first operator</param>
        /// <param name="operator2">The second operator</param>
        /// <returns>1 for op1 is higher, -1 for op2 is higher, 0 if equal</returns>
        private static int HighestPriority(string operator1, string operator2)
        {
            int op1Pos = 0;
            int op2Pos = 0;

            // Loop through the table
            for (int i = 0 ; i < _binaryOperator.Length ; i++)
            {
                for (int j = 0; j < _binaryOperator[j].Length; j++)
                {
                    if (_binaryOperator.Equals(operator1))
                        op1Pos = i;
                    if (_binaryOperator.Equals(operator2))
                        op2Pos = i;
                }

                // Break when found
                if (op1Pos == op2Pos)
                    return 0;
                if (op1Pos < op2Pos)
                    return 1;
                if (op1Pos > op2Pos)
                    return -1;
            }

            return 0;
        }

        /// <summary>
        /// Transform an string into a list of string. Include negative numbers and decimals
        /// </summary>
        /// <param name="expression">String representing an arithmetic expression</param>
        /// <returns>The list of string</returns>
        private static List<string> ExpressionToList(string expression)
        {
            List<string> listExpression = new List<string>();
            int index = 0;
            while (index < expression.Length)  
                listExpression.Add(NextNumberOperator(expression, ref index));

            return listExpression;
        }

        /// <summary>
        /// Get the next number or operators
        /// </summary>
        /// <param name="expression">The entire expression</param>
        /// <param name="index">Current position</param>
        /// <returns>The next operator or number</returns>
        private static string NextNumberOperator(string expression, ref int index)
        {
            string next = "";

            // Check for negative numbers
            if (expression[index].Equals('-') && (index == 0 || (index > 0 && _operators.IndexOf(expression[index - 1]) != -1)))
            {
                next += expression[index].ToString();
                index++;
                next += GetNumber(expression, ref index);
            }
            // Check if decimal
            else if ((expression[index] >= 48 && expression[index] <= 57) || expression[index].Equals('.'))
                next += GetNumber(expression, ref index);
            else
            {
                next += expression[index].ToString();
                index++;
            }

            return next;
        }

        /// <summary>
        /// Get all the digits of a number including decimals
        /// </summary>
        /// <param name="expression">The entire expression</param>
        /// <param name="index">Current position</param>
        /// <returns>A number </returns>
        private static string GetNumber(string expression, ref int index)
        {
            string next = "";
            
            // Look for more didigt
            while (index < expression.Length && ((expression[index] >= 48 && expression[index] <= 57) || expression[index].Equals('.')))
            {
                next += expression[index].ToString();
                index++;
            }

            return next;
        }

    }
}
