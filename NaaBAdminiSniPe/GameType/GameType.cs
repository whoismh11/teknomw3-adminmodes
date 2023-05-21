using InfinityScript;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace NaaBAdmin_iSniPe
{
    public class MyShopUtils : BaseScript
    {
        public MyShopUtils()
        {
            changeGametype("^5iSniPe");
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr VirtualAlloc(IntPtr lpAddress, UIntPtr dwSize, uint flAllocationType, uint flProtect);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool VirtualFree(IntPtr lpAddress, UIntPtr dwSize, uint dwFreeType);
        public IntPtr alloc(int size)
        {
            return VirtualAlloc(IntPtr.Zero, (UIntPtr)size, 0x3000, 0x40);
        }
        public bool unalloc(IntPtr address, int size)
        {
            return VirtualFree(address, (UIntPtr)size, 0x8000);
        }

        bool _changed = false;
        IntPtr memory;
        private unsafe void changeGametype(string gametype)
        {
            byte[] gametypestring;
            if (_changed)
            {
                gametypestring = new System.Text.UTF8Encoding().GetBytes(gametype);
                if (gametypestring.Length >= 64) gametypestring[64] = 0x0; // null terminate if too large
                Marshal.Copy(gametypestring, 0, memory, gametype.Length > 64 ? 64 : gametype.Length);
                return;
            }
            memory = alloc(64);
            gametypestring = new System.Text.UTF8Encoding().GetBytes(gametype);
            if (gametypestring.Length >= 64) gametypestring[64] = 0x0; // null terminate if too large
            Marshal.Copy(gametypestring, 0, memory, gametype.Length > 64 ? 64 : gametype.Length);
            *(byte*)0x4EB983 = 0x68; // mov eax, 575D928h -> push stringloc
            *(int*)0x4EB984 = (int)memory;
            *(byte*)0x4EB988 = 0x90; // mov ecx, [eax+0Ch] -> nop
            *(byte*)0x4EB989 = 0x90;
            *(byte*)0x4EB98A = 0x90;
            *(byte*)0x4EB98B = 0x90; // push edx -> nop
            _changed = true;
        }
    }
}
