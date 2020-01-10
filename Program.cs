using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RemoveLzgRegistryKey
{
    class Program
    {
        static void Main(string[] args)
        {
            string keyLzg = @"Software\Lzg";
            if (Registry.CurrentUser.OpenSubKey(keyLzg) != null)
            {
                Registry.CurrentUser.DeleteSubKey(keyLzg);
            }
            
        }
    }
}
