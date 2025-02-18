using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace DSA_Group1_Final_Project.Classes.DLLs
{
    public class Stack
    {
        [DllImport("StackDataStructure.dll")]
        public static extern IntPtr createStack(int size);

        [DllImport("StackDataStructure.dll")]
        public static extern IntPtr deleteStack(IntPtr stack);

        [DllImport("StackDataStructure.dll")]
        public static extern void push(IntPtr stack, int x);

        [DllImport("StackDataStructure.dll")]
        public static extern int pop(IntPtr stack);

        [DllImport("StackDataStructure.dll")]
        public static extern int peek(IntPtr stack);

        [DllImport("StackDataStructure.dll")]
        public static extern bool isEmpty(IntPtr stack);

        [DllImport("StackDataStructure.dll")]
        public static extern bool isFull(IntPtr stack);

        [DllImport("StackDataStructure.dll")]
        public static extern int getCount(IntPtr stack);
    }
}
