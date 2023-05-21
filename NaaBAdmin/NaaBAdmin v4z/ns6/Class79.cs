namespace ns6
{
    using ns1;
    using System;
    using System.Collections;
    using System.IO;
    using System.Reflection;
    using System.Text;

    internal sealed class Class79
    {
        private static readonly bool bool_0 = false;
        private static readonly byte[] byte_0 = null;
        private static readonly Hashtable hashtable_0 = null;
        private static readonly int int_0 = 0;
        private static readonly string string_0 = "1";
        private static readonly string string_1 = "226";

        static Class79()
        {
            if (string_0 == "1")
            {
                bool_0 = true;
                hashtable_0 = new Hashtable();
            }
            int_0 = Convert.ToInt32(string_1);
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("{f577b2d3-4bda-4179-b4d0-4e0b33ea7039}"))
            {
                int count = Convert.ToInt32(stream.Length);
                byte[] buffer = new byte[count];
                stream.Read(buffer, 0, count);
                byte_0 = Class75.smethod_138(buffer);
                buffer = null;
                stream.Close();
            }
        }

        public static string smethod_0(int int_1)
        {
            int_1 -= int_0;
            if (bool_0)
            {
                string str = (string) hashtable_0[int_1];
                if (str != null)
                {
                    return str;
                }
            }
            int count = 0;
            int index = int_1;
            int num3 = byte_0[index++];
            if ((num3 & 0x80) == 0)
            {
                count = num3;
                if (count == 0)
                {
                    return string.Empty;
                }
            }
            else if ((num3 & 0x40) == 0)
            {
                count = ((num3 & 0x3f) << 8) + byte_0[index++];
            }
            else
            {
                count = ((((num3 & 0x1f) << 0x18) + (byte_0[index++] << 0x10)) + (byte_0[index++] << 8)) + byte_0[index++];
            }
            try
            {
                byte[] bytes = Convert.FromBase64String(Encoding.UTF8.GetString(byte_0, index, count));
                string str2 = string.Intern(Encoding.UTF8.GetString(bytes, 0, bytes.Length));
                if (bool_0)
                {
                    try
                    {
                        hashtable_0.Add(int_1, str2);
                    }
                    catch
                    {
                    }
                }
                return str2;
            }
            catch
            {
                return null;
            }
        }
    }
}

