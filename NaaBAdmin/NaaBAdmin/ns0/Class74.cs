namespace ns0
{
    using System;
    using System.IO;
    using System.Reflection;

    internal sealed class Class74 : IDisposable
    {
        internal readonly object object_0;
        internal readonly Type type_0 = Assembly.Load("mscorlib").GetType("System.Security.Cryptography.DESCryptoServiceProvider");

        public Class74()
        {
            this.object_0 = Activator.CreateInstance(this.type_0);
        }

        void IDisposable.Dispose()
        {
            Class67.smethod_30(this);
        }
    }
}
