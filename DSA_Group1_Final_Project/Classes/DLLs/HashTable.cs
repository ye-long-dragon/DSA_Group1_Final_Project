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
        IntPtr Hash;

        //public HashTable(int size) { 
        //    Hash = new IntPtr(size);
        //    Hash = createHashtable(size);
        //}

        public void insertElement(int key, string value) {
            insertItem(Hash, key, value);
        }

        public void deleteElement(int key) {
            deleteItem(Hash,key);
        }

        public string returnElement(int key)
        {
            return returnItem(Hash, key);
        }



        [DllImport("DataStructures.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr createHashtable(int size);

        [DllImport("DataStructures.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr deleteHashTable(IntPtr ptr);

        [DllImport("DataStructures.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void insertItem(IntPtr ptr, int key, string item);

        [DllImport("DataStructures.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void deleteItem(IntPtr ptr, int key);

        [DllImport("DataStructures.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int searchItem(IntPtr ptr, int key);
        //std::string searchItem()

        [DllImport("DataStructures.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern string returnItem(IntPtr ptr, int key);


    }
}
