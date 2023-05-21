using System;
public class DatabaseInfo
{
    public static int ASNUM_EDITION = 9;
    public static int ASNUM_EDITION_V6 = 0x15;
    public static int CITY_EDITION_REV0 = 6;
    public static int CITY_EDITION_REV0_V6 = 0x1f;
    public static int CITY_EDITION_REV1 = 2;
    public static int CITY_EDITION_REV1_V6 = 30;
    public static int COUNTRY_EDITION = 1;
    public static int COUNTRY_EDITION_V6 = 12;
    public static int DOMAIN_EDITION = 11;
    public static int DOMAIN_EDITION_V6 = 0x18;
    public static int ISP_EDITION = 4;
    public static int ISP_EDITION_V6 = 0x16;
    public static int NETSPEED_EDITION = 10;
    public static int NETSPEED_EDITION_REV1 = 0x20;
    public static int NETSPEED_EDITION_REV1_V6 = 0x21;
    public static int ORG_EDITION = 5;
    public static int ORG_EDITION_V6 = 0x17;
    public static int PROXY_EDITION = 8;
    public static int REGION_EDITION_REV0 = 7;
    public static int REGION_EDITION_REV1 = 3;
    private string string_0;

    public DatabaseInfo(string info)
    {
        this.string_0 = info;
    }

    public DateTime getDate()
    {
        for (int i = 0; i < (this.string_0.Length - 9); i++)
        {
            if (char.IsWhiteSpace(this.string_0[i]))
            {
                string s = this.string_0.Substring(i + 1, 8);
                try
                {
                    return DateTime.ParseExact(s, "yyyyMMdd", null);
                }
                catch (Exception exception)
                {
                    Console.Write(exception.Message);
                }
                break;
            }
        }
        return DateTime.Now;
    }

    public int getType()
    {
        if ((this.string_0 == null) | (this.string_0 == ""))
        {
            return COUNTRY_EDITION;
        }
        return (Convert.ToInt32(this.string_0.Substring(4, 3)) - 0x69);
    }

    public bool isPremium()
    {
        return (this.string_0.IndexOf("FREE") < 0);
    }

    public string toString()
    {
        return this.string_0;
    }
}
