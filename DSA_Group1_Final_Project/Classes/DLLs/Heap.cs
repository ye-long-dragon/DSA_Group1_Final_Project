using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Group1_Final_Project.Classes.DLLs
{
    public class Heap
    {
        [DllImport("StackDataStructure.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr createHeap(int size);

        [DllImport("StackDataStructure.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr deleteHeap(IntPtr ptr);

        [DllImport("StackDataStructure.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void heapify(IntPtr ptr);

        [DllImport("StackDataStructure.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int searchElementIndex(IntPtr ptr, int index);

        [DllImport("StackDataStructure.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int searchElemet(IntPtr ptr, int index);

        [DllImport("StackDataStructure.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int searchParent(IntPtr ptr, int index);

        [DllImport("StackDataStructure.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int searchChildL(IntPtr ptr, int index);

        [DllImport("StackDataStructure.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int searchChildR(IntPtr ptr, int index);

        [DllImport("StackDataStructure.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getMin(IntPtr ptr);

        [DllImport("StackDataStructure.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern string returnTree(IntPtr ptr);

        [DllImport("StackDataStructure.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int height(IntPtr ptr);

        [DllImport("StackDataStructure.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void insertElement(IntPtr ptr, int value);

        [DllImport("StackDataStructure.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int extractMin(IntPtr ptr);

        [DllImport("StackDataStructure.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void deleteElement(IntPtr ptr, int i);

    }
}
