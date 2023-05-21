namespace ns1
{
    using System;
    using System.Reflection;

    internal sealed class Class81 : IDisposable
    {
        internal readonly object object_0;
        internal readonly Type type_0 = Assembly.Load("mscorlib").GetType("System.Security.Cryptography.DESCryptoServiceProvider");

        public Class81()
        {
            this.object_0 = Activator.CreateInstance(this.type_0);
        }

        void IDisposable.Dispose()
        {
            Class75.smethod_37(this);
        }
    }
}

