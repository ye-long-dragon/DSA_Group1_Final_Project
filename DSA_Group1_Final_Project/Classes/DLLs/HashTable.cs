using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Group1_Final_Project.Classes.DLLs
{
    public class HashTable
    {
        [DllImport("StackDataStructure.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void createHashtable(int size);

        [DllImport("StackDataStructure.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void deleteHashTable(IntPtr ptr);

        [DllImport("StackDataStructure.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void insertItem(IntPtr ptr, int key, string item);

        [DllImport("StackDataStructure.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void deleteItem(IntPtr ptr, int key);

        [DllImport("StackDataStructure.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int searchItem(IntPtr ptr, int key);
        //std::string searchItem()

        [DllImport("StackDataStructure.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern string returnItem(IntPtr ptr, int key);


    }
}
