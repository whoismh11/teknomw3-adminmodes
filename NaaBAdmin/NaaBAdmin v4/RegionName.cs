using ns1;
using System;
using System.Collections;

public static class RegionName
{
    internal static Hashtable hashtable_0;

    public static string getRegionName(string ccode, string region)
    {
        if (hashtable_0 == null)
        {
            Class75.smethod_223();
        }
        if ((region == null) || (region == "00"))
        {
            return null;
        }
        if (!hashtable_0.ContainsKey(ccode))
        {
            return null;
        }
        return (string) ((Hashtable) hashtable_0[ccode])[region];
    }
}

