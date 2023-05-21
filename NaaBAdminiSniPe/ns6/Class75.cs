namespace ns6
{
    using ns0;
    using System;
    using System.IO;

    internal sealed class Class75
    {
        internal sealed class Class76
        {
            internal bool bool_0;
            internal Class75.Class77 class77_0 = new Class75.Class77();
            internal Class75.Class78 class78_0 = new Class75.Class78();
            internal Class75.Class79 class79_0;
            internal Class75.Class79 class79_1;
            internal Class75.Class80 class80_0;
            internal static readonly int[] int_0 = new int[] { 
                3, 4, 5, 6, 7, 8, 9, 10, 11, 13, 15, 0x11, 0x13, 0x17, 0x1b, 0x1f, 
                0x23, 0x2b, 0x33, 0x3b, 0x43, 0x53, 0x63, 0x73, 0x83, 0xa3, 0xc3, 0xe3, 0x102
             };
            internal static readonly int[] int_1 = new int[] { 
                0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 
                3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 0
             };
            internal static readonly int[] int_2 = new int[] { 
                1, 2, 3, 4, 5, 7, 9, 13, 0x11, 0x19, 0x21, 0x31, 0x41, 0x61, 0x81, 0xc1, 
                0x101, 0x181, 0x201, 0x301, 0x401, 0x601, 0x801, 0xc01, 0x1001, 0x1801, 0x2001, 0x3001, 0x4001, 0x6001
             };
            internal static readonly int[] int_3 = new int[] { 
                0, 0, 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 
                7, 7, 8, 8, 9, 9, 10, 10, 11, 11, 12, 12, 13, 13
             };
            internal int int_4 = 2;
            internal int int_5;
            internal int int_6;
            internal int int_7;
            internal int int_8;

            public Class76(byte[] byte_0)
            {
                Class67.smethod_120(byte_0, byte_0.Length, this.class77_0, 0);
            }
        }

        internal sealed class Class77
        {
            internal byte[] byte_0;
            internal int int_0 = 0;
            internal int int_1 = 0;
            internal int int_2 = 0;
            internal uint uint_0 = 0;
        }

        internal sealed class Class78
        {
            internal byte[] byte_0 = new byte[0x8000];
            internal int int_0 = 0;
            internal int int_1 = 0;
        }

        internal sealed class Class79
        {
            public static readonly Class75.Class79 class79_0;
            public static readonly Class75.Class79 class79_1;
            internal short[] short_0;

            static Class79()
            {
                byte[] buffer = new byte[0x120];
                int num = 0;
                while (num < 0x90)
                {
                    buffer[num++] = 8;
                }
                while (num < 0x100)
                {
                    buffer[num++] = 9;
                }
                while (num < 280)
                {
                    buffer[num++] = 7;
                }
                while (num < 0x120)
                {
                    buffer[num++] = 8;
                }
                class79_0 = new Class75.Class79(buffer);
                buffer = new byte[0x20];
                num = 0;
                while (num < 0x20)
                {
                    buffer[num++] = 5;
                }
                class79_1 = new Class75.Class79(buffer);
            }

            public Class79(byte[] byte_0)
            {
                Class67.smethod_129(byte_0, this);
            }
        }

        internal sealed class Class80
        {
            internal byte[] byte_0;
            internal byte[] byte_1;
            internal byte byte_2;
            internal Class75.Class79 class79_0;
            internal static readonly int[] int_0 = new int[] { 3, 3, 11 };
            internal static readonly int[] int_1 = new int[] { 2, 3, 7 };
            internal int int_2;
            internal int int_3;
            internal int int_4;
            internal int int_5;
            internal int int_6;
            internal int int_7;
            internal int int_8;
            internal static readonly int[] int_9 = new int[] { 
                0x10, 0x11, 0x12, 0, 8, 7, 9, 6, 10, 5, 11, 4, 12, 3, 13, 2, 
                14, 1, 15
             };
        }

        internal sealed class Class81
        {
            internal static readonly byte[] byte_0 = new byte[] { 0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15 };
            private static readonly byte[] byte_1 = new byte[0x11e];
            private static readonly byte[] byte_2;
            private static readonly int[] int_0 = new int[] { 
                0x10, 0x11, 0x12, 0, 8, 7, 9, 6, 10, 5, 11, 4, 12, 3, 13, 2, 
                14, 1, 15
             };
            private static readonly short[] short_0 = new short[0x11e];
            private static readonly short[] short_1;

            static Class81()
            {
                int index = 0;
                while (index < 0x90)
                {
                    short_0[index] = Class67.smethod_158((0x30 + index) << 8);
                    byte_1[index++] = 8;
                }
                while (index < 0x100)
                {
                    short_0[index] = Class67.smethod_158((0x100 + index) << 7);
                    byte_1[index++] = 9;
                }
                while (index < 280)
                {
                    short_0[index] = Class67.smethod_158((-256 + index) << 9);
                    byte_1[index++] = 7;
                }
                while (index < 0x11e)
                {
                    short_0[index] = Class67.smethod_158((-88 + index) << 8);
                    byte_1[index++] = 8;
                }
                short_1 = new short[30];
                byte_2 = new byte[30];
                for (index = 0; index < 30; index++)
                {
                    short_1[index] = Class67.smethod_158(index << 11);
                    byte_2[index] = 5;
                }
            }
        }

        internal sealed class Stream0 : MemoryStream
        {
            public Stream0(byte[] byte_0) : base(byte_0, false)
            {
            }
        }
    }
}
