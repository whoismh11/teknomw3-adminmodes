using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using InfinityScript;

namespace ServerControll
{
    unsafe class NoKnife
    {

        public unsafe void DisableKnife()
        {
            *this.KnifeRange = (int)ZeroAddress;
        }

        public unsafe void EnableKnife()
        {
            *this.KnifeRange = (int)DefaultKnifeAddress;
        }

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll")]
        private static extern bool VirtualProtect(IntPtr lpAddress, IntPtr dwSize, uint flNewProtect, out uint lpflOldProtect);


        private int DefaultKnifeAddress;
        private int* KnifeRange;
        private int* ZeroAddress;

        private unsafe int FindMem(byte?[] search, int num = 1, int start = 0x1000000, int end = 0x3d00000)
        {
            byte* num2 = (byte*)0;
            try
            {
                int num3 = 0;
                for (int i = start; i < end; i++)
                {
                    num2 = (byte*)i;
                    bool flag = false;
                    for (int j = 0; j < search.Length; j++)
                    {
                        if (search[j].HasValue)
                        {
                            byte num7 = *num2;
                            if (num7 != search[j])
                            {
                                break;
                            }
                        }
                        if (j == (search.Length - 1))
                        {
                            if (num == 1)
                            {
                                flag = true;
                            }
                            else
                            {
                                num3++;
                                if (num3 == num)
                                {
                                    flag = true;
                                }
                            }
                        }
                        else
                        {
                            num2++;
                        }
                    }
                    if (flag)
                    {
                        return i;
                    }
                }
            }
            catch (Exception exception)
            {
                Log.Write(LogLevel.Error, "FindMem: " + exception.Message + "\nAddress: " + (int)num2);
            }
            return 0;
        }



        public unsafe NoKnife()
        {

            Log.Write(LogLevel.Info, "NoKnife Plugin loaded");

            try
            {

                byte?[] search = new byte?[] {
                0x8b, null, null, null, 0x83, null, 4, null, 0x83, null, 12, 0xd9, null, null, null, 0x8b,
                null, 0xd9, null, null, null, 0xd9, 5
             };
                this.KnifeRange = (int*)(this.FindMem(search, 1, 0x400000, 0x500000) + search.Length);

                Log.Write(LogLevel.Info, "KnifeRange ptr: " + string.Format("{0:X}", (int)KnifeRange));

                if ((int)this.KnifeRange == search.Length)
                {
                    byte?[] nullableArray2 = new byte?[] {
                    0x8b, null, null, null, 0x83, null, 0x18, null, 0x83, null, 12, 0xd9, null, null, null, 0x8d,
                    null, null, null, 0xd9, null, null, null, 0xd9, 5
                 };
                    this.KnifeRange = (int*)(this.FindMem(nullableArray2, 1, 0x400000, 0x500000) + nullableArray2.Length);

                    Log.Write(LogLevel.Info, "KnifeRange ptr: " + string.Format("{0:X}", (int)KnifeRange));

                    if ((int)this.KnifeRange == nullableArray2.Length)
                    {
                        this.KnifeRange = (int*)0;
                    }
                }
                this.DefaultKnifeAddress = *this.KnifeRange;
                byte?[] nullableArray3 = new byte?[] {
                0xd9, 0x5c, null, null, 0xd8, null, null, 0xd8, null, null, 0xd9, 0x5c, null, null, 0x83, null,
                1, 15, 0x86, null, 0, 0, 0, 0xd9
             };
                this.ZeroAddress = (int*)(this.FindMem(nullableArray3, 1, 0x400000, 0x500000) + nullableArray3.Length + 2);

                Log.Write(LogLevel.Info, "ZeroAddress ptr: " + string.Format("{0:X}", (int)ZeroAddress));

                if ((((int)this.KnifeRange == 0) || ((int)this.DefaultKnifeAddress == 0)) || ((int)this.ZeroAddress == 0))
                {
                    Log.Write(LogLevel.Error, "Error finding address: NoKnife Plugin will not work");

                }
                else
                {
                    uint num;
                    VirtualProtect((IntPtr)this.KnifeRange, (IntPtr)4, 0x40, out num);
                }
            }
            catch (Exception exception)
            {
                Log.Write(LogLevel.Error, "Error in NoKnife Plugin. Plugin will not work.");
                Log.Write(LogLevel.Error, exception.ToString());
            }
        }
    }
}


