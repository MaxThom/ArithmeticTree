using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticTree
{


    
    interface BinaryTree<T>
    {
        /** <summary>
         * Return the data of the selected node
         * </summary>
         */
        T GetElement(int index);

    }
}
