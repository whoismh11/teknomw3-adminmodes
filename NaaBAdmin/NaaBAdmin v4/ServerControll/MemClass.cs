namespace ServerControll
{
    using ns1;
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Text;

    public class MemClass
    {
        internal IntPtr intptr_0;

        public void MyProcess_Handle()
        {
            this.intptr_0 = (IntPtr) (-1);
        }

        public bool Process_Handle(string ProcessName)
        {
            try
            {
                Process[] processesByName = Process.GetProcessesByName(ProcessName);
                if (processesByName.Length == 0)
                {
                    return false;
                }
                this.intptr_0 = processesByName[0].Handle;
                return true;
            }
            catch (Exception exception)
            {
                Console.Beep();
                Console.WriteLine("Process_Handle - " + exception.Message);
                return false;
            }
        }

        public byte[] ReadBytes(int Address, int Length)
        {
           return Class75.smethod_102(Address, Length, this);
        }

        public int ReadInteger(int Address, int Length = 4)
        {
           return BitConverter.ToInt32(Class75.smethod_102(Address, Length, this), 0);
        }

        public string ReadString(int Address, int Length = 4)
        {
            return new ASCIIEncoding().GetString(Class75.smethod_102(Address, Length, this));
        }

        public void WriteBytes(int Address, byte[] Bytes)
        {
            IntPtr zero = IntPtr.Zero;
            Class75.WriteProcessMemory_1(this.intptr_0, (IntPtr) Address, Bytes, (uint) Bytes.Length, out zero);
        }

        public void WriteInteger(int Address, int Value)
        {
            Class75.smethod_101(Address, Value, this);
        }

        public void WriteNOP(int Address)
        {
            byte[] buffer = new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90 };
            IntPtr zero = IntPtr.Zero;
            Class75.WriteProcessMemory_1(this.intptr_0, (IntPtr) Address, buffer, (uint) buffer.Length, out zero);
        }

        public void WriteString(int Address, string Text)
        {
            byte[] bytes = new ASCIIEncoding().GetBytes(Text);
            IntPtr zero = IntPtr.Zero;
            Class75.WriteProcessMemory_1(this.intptr_0, (IntPtr) Address, bytes, (uint) bytes.Length, out zero);
        }
    }
}

