namespace ServerControll
{
    using ns0;
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
            return Class67.smethod_131(Address, this, Length);
        }

        public int ReadInteger(int Address, int Length = 4)
        {
            return BitConverter.ToInt32(Class67.smethod_131(Address, this, Length), 0);
        }

        public string ReadString(int Address, int Length = 4)
        {
            return new ASCIIEncoding().GetString(Class67.smethod_131(Address, this, Length));
        }

        public void WriteBytes(int Address, byte[] Bytes)
        {
            IntPtr zero = IntPtr.Zero;
            Class67.WriteProcessMemory(this.intptr_0, (IntPtr) Address, Bytes, (uint) Bytes.Length, out zero);
        }

        public void WriteInteger(int Address, int Value)
        {
            Class67.smethod_128(Value, Address, this);
        }

        public void WriteNOP(int Address)
        {
            byte[] buffer = new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90 };
            IntPtr zero = IntPtr.Zero;
            Class67.WriteProcessMemory(this.intptr_0, (IntPtr) Address, buffer, (uint) buffer.Length, out zero);
        }

        public void WriteString(int Address, string Text)
        {
            byte[] bytes = new ASCIIEncoding().GetBytes(Text);
            IntPtr zero = IntPtr.Zero;
            Class67.WriteProcessMemory(this.intptr_0, (IntPtr) Address, bytes, (uint) bytes.Length, out zero);
        }
    }
}
