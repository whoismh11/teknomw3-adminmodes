namespace ns2
{
    using ns3;
    using ns4;
    using ns5;
    using System;
    using System.Reflection;
    using System.Reflection.Emit;

    [Attribute2, Attribute1]
    internal static class Class70
    {
        [Attribute0, Attribute1, Attribute2]
        public static void smethod_0(Type type_0)
        {
            FieldInfo[] fields = type_0.GetFields(BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Static);
            int index = 0;
        Label_0010:
            if (index < fields.Length)
            {
                FieldInfo info = fields[index];
                try
                {
                    if (info.FieldType != typeof(Delegate0))
                    {
                        index++;
                        goto Label_0010;
                    }
                    DynamicMethod method = new DynamicMethod(string.Empty, typeof(string), new Type[] { typeof(int) }, type_0.Module, true);
                    ILGenerator iLGenerator = method.GetILGenerator();
                    iLGenerator.Emit(OpCodes.Ldarg_0);
                    foreach (MethodInfo info2 in typeof(Class72).GetMethods(BindingFlags.Public | BindingFlags.Static))
                    {
                        if (info2.ReturnType == typeof(string))
                        {
                            goto Label_00BE;
                        }
                    }
                    goto Label_00EC;
                Label_00BE:
                    iLGenerator.Emit(OpCodes.Ldc_I4, (int) (info.MetadataToken & 0xffffff));
                    iLGenerator.Emit(OpCodes.Sub);
                    iLGenerator.Emit(OpCodes.Call, info);
                Label_00EC:
                    iLGenerator.Emit(OpCodes.Ret);
                    info.SetValue(null, method.CreateDelegate(typeof(Delegate0)));
                }
                catch
                {
                }
            }
        }
    }
}
