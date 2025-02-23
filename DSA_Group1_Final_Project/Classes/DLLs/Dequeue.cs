using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Group1_Final_Project.Classes.DLLs
{
    public class Dequeue
    {
        [DllImport("StackDataStructure.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void createDequeue(int size);

        [DllImport("StackDataStructure.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void deleteDequeue(IntPtr ptr);

        [DllImport("StackDataStructure.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool isEmpty(IntPtr ptr);

        [DllImport("StackDataStructure.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool isFull(IntPtr ptr);

        [DllImport("StackDataStructure.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void enqueueFront(IntPtr ptr, int x);

        [DllImport("StackDataStructure.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void enqueueRear(IntPtr ptr, int x);

        [DllImport("StackDataStructure.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int dequeueFront(IntPtr ptr);

        [DllImport("StackDataStructure.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int dequeueRear(IntPtr ptr);

        [DllImport("StackDataStructure.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern string returnDequeue(IntPtr ptr);


    }
}
