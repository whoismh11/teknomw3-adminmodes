using ns0;
using System.Collections;
using System.Collections.Generic;
public static class RegionName
{
    internal static Hashtable hashtable_0;

    public static string getRegionName(string ccode, string region)
    {
        if (hashtable_0 == null)
        {
            Class67.smethod_64();
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
