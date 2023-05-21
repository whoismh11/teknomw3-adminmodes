namespace ns1
{
    using System;
    using System.IO;
    using System.Reflection;

    internal sealed class Class80 : IDisposable
    {
        internal readonly object object_0;
        internal readonly Type type_0;

        public Class80()
        {
            try
            {
                this.type_0 = Assembly.Load("System.Core, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e").GetType("System.Security.Cryptography.AesManaged");
            }
            catch (FileNotFoundException)
            {
                this.type_0 = Assembly.Load("mscorlib").GetType("System.Security.Cryptography.RijndaelManaged");
            }
            this.object_0 = Activator.CreateInstance(this.type_0);
        }

        void IDisposable.Dispose()
        {
            Class75.smethod_194(this);
        }
    }
}

