namespace ns2
{
    using ns3;
    using ns4;
    using System;
    using System.Reflection;
    using System.Reflection.Emit;

    [Attribute2, Attribute1]
    internal static class Class69
    {
        private static char[] char_0 = new char[] { 
            '\x0001', '\x0002', '\x0003', '\x0004', '\x0005', '\x0006', '\a', '\b', '\x000e', '\x000f', '\x0010', '\x0011', '\x0012', '\x0013', '\x0014', '\x0015', 
            '\x0016', '\x0017', '\x0018', '\x0019', '\x001a', '\x001b', '\x001c', '\x001d', '\x001e', '\x001f', '\x007f', '\x0080', '\x0081', '\x0082', '\x0083', '\x0084', 
            '\x0086', '\x0087', '\x0088', '\x0089', '\x008a', '\x008b', '\x008c', '\x008d', '\x008e', '\x008f', '\x0090', '\x0091', '\x0092', '\x0093', '\x0094', '\x0095', 
            '\x0096', '\x0097', '\x0098', '\x0099', '\x009a', '\x009b', '\x009c', '\x009d', '\x009e', '\x009f'
         };
        private static ModuleHandle moduleHandle_0;

        static Class69()
        {
            if (typeof(MulticastDelegate) != null)
            {
                moduleHandle_0 = Assembly.GetExecutingAssembly().GetModules()[0].ModuleHandle;
            }
        }

        [Attribute1, Attribute0, Attribute2]
        public static void smethod_0(int int_0)
        {
            Type typeFromHandle;
            MethodInfo methodFromHandle;
            Delegate delegate2;
            try
            {
                typeFromHandle = Type.GetTypeFromHandle(moduleHandle_0.ResolveTypeHandle(0x2000001 + int_0));
            }
            catch
            {
                return;
            }
            FieldInfo[] fields = typeFromHandle.GetFields(BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Static);
            int index = 0;
        Label_002F:
            if (index >= fields.Length)
            {
                return;
            }
            FieldInfo info = fields[index];
            string name = info.Name;
            bool flag = false;
            int num = 0;
            for (int i = name.Length - 1; i >= 0; i--)
            {
                char ch = name[i];
                if (ch == '~')
                {
                    flag = true;
                    break;
                }
                int num3 = 0;
                while (num3 < 0x3a)
                {
                    if (char_0[num3] == ch)
                    {
                        goto Label_008B;
                    }
                    num3++;
                }
                continue;
            Label_008B:
                num = (num * 0x3a) + num3;
            }
            try
            {
                methodFromHandle = (MethodInfo) MethodBase.GetMethodFromHandle(moduleHandle_0.ResolveMethodHandle(num + 0xa000001));
            }
            catch
            {
                goto Label_0207;
            }
            if (methodFromHandle.IsStatic)
            {
                try
                {
                    delegate2 = Delegate.CreateDelegate(info.FieldType, methodFromHandle);
                    goto Label_01F9;
                }
                catch (Exception)
                {
                    goto Label_0207;
                }
            }
            ParameterInfo[] parameters = methodFromHandle.GetParameters();
            int num4 = parameters.Length + 1;
            Type[] parameterTypes = new Type[num4];
            parameterTypes[0] = typeof(object);
            for (int j = 1; j < num4; j++)
            {
                parameterTypes[j] = parameters[j - 1].ParameterType;
            }
            DynamicMethod method = new DynamicMethod(string.Empty, methodFromHandle.ReturnType, parameterTypes, typeFromHandle, true);
            ILGenerator iLGenerator = method.GetILGenerator();
            iLGenerator.Emit(OpCodes.Ldarg_0);
            if (num4 > 1)
            {
                iLGenerator.Emit(OpCodes.Ldarg_1);
            }
            if (num4 > 2)
            {
                iLGenerator.Emit(OpCodes.Ldarg_2);
            }
            if (num4 > 3)
            {
                iLGenerator.Emit(OpCodes.Ldarg_3);
            }
            if (num4 > 4)
            {
                for (int k = 4; k < num4; k++)
                {
                    iLGenerator.Emit(OpCodes.Ldarg_S, k);
                }
            }
            iLGenerator.Emit(OpCodes.Tailcall);
            iLGenerator.Emit(flag ? OpCodes.Callvirt : OpCodes.Call, methodFromHandle);
            iLGenerator.Emit(OpCodes.Ret);
            try
            {
                delegate2 = method.CreateDelegate(typeFromHandle);
            }
            catch
            {
                goto Label_0207;
            }
        Label_01F9:
            try
            {
                info.SetValue(null, delegate2);
            }
            catch
            {
            }
        Label_0207:
            index++;
            goto Label_002F;
        }
    }
}
