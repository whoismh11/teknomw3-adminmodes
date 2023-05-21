using ns0;
using System;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
public class LookupService
{
    internal byte byte_0;
    internal byte[] byte_1;
    private static Country country_0 = new Country("--", "N/A");
    private DatabaseInfo databaseInfo_0;
    internal FileStream fileStream_0;
    public static int GEOIP_CABLEDSL_SPEED = 2;
    public static int GEOIP_CORPORATE_SPEED = 3;
    public static int GEOIP_DIALUP_SPEED = 1;
    public static int GEOIP_MEMORY_CACHE = 1;
    public static int GEOIP_STANDARD = 0;
    public static int GEOIP_UNKNOWN_SPEED = 0;
    private static int int_0 = 0x2a5;
    internal static int int_1 = 0xffff00;
    internal int int_10;
    internal static int int_11 = 3;
    internal static int int_12 = 3;
    internal static int int_13 = 0xfed260;
    internal static int int_14 = 0xf42400;
    internal static int int_15 = 20;
    private static int int_16 = 1;
    private static int int_17 = 0x549;
    private static int int_2 = 100;
    internal int[] int_3;
    internal int int_4;
    private static int int_5 = 360;
    private static int int_6 = 100;
    private static int int_7 = 0x3e8;
    internal static int int_8 = 4;
    internal static int int_9 = 4;
    private static string[] string_0 = new string[] { 
        "--", "AP", "EU", "AD", "AE", "AF", "AG", "AI", "AL", "AM", "CW", "AO", "AQ", "AR", "AS", "AT", 
        "AU", "AW", "AZ", "BA", "BB", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BM", "BN", "BO", "BR", 
        "BS", "BT", "BV", "BW", "BY", "BZ", "CA", "CC", "CD", "CF", "CG", "CH", "CI", "CK", "CL", "CM", 
        "CN", "CO", "CR", "CU", "CV", "CX", "CY", "CZ", "DE", "DJ", "DK", "DM", "DO", "DZ", "EC", "EE", 
        "EG", "EH", "ER", "ES", "ET", "FI", "FJ", "FK", "FM", "FO", "FR", "SX", "GA", "GB", "GD", "GE", 
        "GF", "GH", "GI", "GL", "GM", "GN", "GP", "GQ", "GR", "GS", "GT", "GU", "GW", "GY", "HK", "HM", 
        "HN", "HR", "HT", "HU", "ID", "IE", "IL", "IN", "IO", "IQ", "IR", "IS", "IT", "JM", "JO", "JP", 
        "KE", "KG", "KH", "KI", "KM", "KN", "KP", "KR", "KW", "KY", "KZ", "LA", "LB", "LC", "LI", "LK", 
        "LR", "LS", "LT", "LU", "LV", "LY", "MA", "MC", "MD", "MG", "MH", "MK", "ML", "MM", "MN", "MO", 
        "MP", "MQ", "MR", "MS", "MT", "MU", "MV", "MW", "MX", "MY", "MZ", "NA", "NC", "NE", "NF", "NG", 
        "NI", "NL", "NO", "NP", "NR", "NU", "NZ", "OM", "PA", "PE", "PF", "PG", "PH", "PK", "PL", "PM", 
        "PN", "PR", "PS", "PT", "PW", "PY", "QA", "RE", "RO", "RU", "RW", "SA", "SB", "SC", "SD", "SE", 
        "SG", "SH", "SI", "SJ", "SK", "SL", "SM", "SN", "SO", "SR", "ST", "SV", "SY", "SZ", "TC", "TD", 
        "TF", "TG", "TH", "TJ", "TK", "TM", "TN", "TO", "TL", "TR", "TT", "TV", "TW", "TZ", "UA", "UG", 
        "UM", "US", "UY", "UZ", "VA", "VC", "VE", "VG", "VI", "VN", "VU", "WF", "WS", "YE", "YT", "RS", 
        "ZA", "ZM", "ME", "ZW", "A1", "A2", "O1", "AX", "GG", "IM", "JE", "BL", "MF", "BQ"
     };
    private static string[] string_1 = new string[] { 
        "N/A", "Asia/Pacific Region", "Europe", "Andorra", "United Arab Emirates", "Afghanistan", "Antigua and Barbuda", "Anguilla", "Albania", "Armenia", "Curacao", "Angola", "Antarctica", "Argentina", "American Samoa", "Austria", 
        "Australia", "Aruba", "Azerbaijan", "Bosnia and Herzegovina", "Barbados", "Bangladesh", "Belgium", "Burkina Faso", "Bulgaria", "Bahrain", "Burundi", "Benin", "Bermuda", "Brunei Darussalam", "Bolivia", "Brazil", 
        "Bahamas", "Bhutan", "Bouvet Island", "Botswana", "Belarus", "Belize", "Canada", "Cocos (Keeling) Islands", "Congo, The Democratic Republic of the", "Central African Republic", "Congo", "Switzerland", "Cote D'Ivoire", "Cook Islands", "Chile", "Cameroon", 
        "China", "Colombia", "Costa Rica", "Cuba", "Cape Verde", "Christmas Island", "Cyprus", "Czech Republic", "Germany", "Djibouti", "Denmark", "Dominica", "Dominican Republic", "Algeria", "Ecuador", "Estonia", 
        "Egypt", "Western Sahara", "Eritrea", "Spain", "Ethiopia", "Finland", "Fiji", "Falkland Islands (Malvinas)", "Micronesia, Federated States of", "Faroe Islands", "France", "Sint Maarten (Dutch part)", "Gabon", "United Kingdom", "Grenada", "Georgia", 
        "French Guiana", "Ghana", "Gibraltar", "Greenland", "Gambia", "Guinea", "Guadeloupe", "Equatorial Guinea", "Greece", "South Georgia and the South Sandwich Islands", "Guatemala", "Guam", "Guinea-Bissau", "Guyana", "Hong Kong", "Heard Island and McDonald Islands", 
        "Honduras", "Croatia", "Haiti", "Hungary", "Indonesia", "Ireland", "Israel", "India", "British Indian Ocean Territory", "Iraq", "Iran, Islamic Republic of", "Iceland", "Italy", "Jamaica", "Jordan", "Japan", 
        "Kenya", "Kyrgyzstan", "Cambodia", "Kiribati", "Comoros", "Saint Kitts and Nevis", "Korea, Democratic People's Republic of", "Korea, Republic of", "Kuwait", "Cayman Islands", "Kazakhstan", "Lao People's Democratic Republic", "Lebanon", "Saint Lucia", "Liechtenstein", "Sri Lanka", 
        "Liberia", "Lesotho", "Lithuania", "Luxembourg", "Latvia", "Libya", "Morocco", "Monaco", "Moldova, Republic of", "Madagascar", "Marshall Islands", "Macedonia", "Mali", "Myanmar", "Mongolia", "Macau", 
        "Northern Mariana Islands", "Martinique", "Mauritania", "Montserrat", "Malta", "Mauritius", "Maldives", "Malawi", "Mexico", "Malaysia", "Mozambique", "Namibia", "New Caledonia", "Niger", "Norfolk Island", "Nigeria", 
        "Nicaragua", "Netherlands", "Norway", "Nepal", "Nauru", "Niue", "New Zealand", "Oman", "Panama", "Peru", "French Polynesia", "Papua New Guinea", "Philippines", "Pakistan", "Poland", "Saint Pierre and Miquelon", 
        "Pitcairn Islands", "Puerto Rico", "Palestinian Territory", "Portugal", "Palau", "Paraguay", "Qatar", "Reunion", "Romania", "Russian Federation", "Rwanda", "Saudi Arabia", "Solomon Islands", "Seychelles", "Sudan", "Sweden", 
        "Singapore", "Saint Helena", "Slovenia", "Svalbard and Jan Mayen", "Slovakia", "Sierra Leone", "San Marino", "Senegal", "Somalia", "Suriname", "Sao Tome and Principe", "El Salvador", "Syrian Arab Republic", "Swaziland", "Turks and Caicos Islands", "Chad", 
        "French Southern Territories", "Togo", "Thailand", "Tajikistan", "Tokelau", "Turkmenistan", "Tunisia", "Tonga", "Timor-Leste", "Turkey", "Trinidad and Tobago", "Tuvalu", "Taiwan", "Tanzania, United Republic of", "Ukraine", "Uganda", 
        "United States Minor Outlying Islands", "United States", "Uruguay", "Uzbekistan", "Holy See (Vatican City State)", "Saint Vincent and the Grenadines", "Venezuela", "Virgin Islands, British", "Virgin Islands, U.S.", "Vietnam", "Vanuatu", "Wallis and Futuna", "Samoa", "Yemen", "Mayotte", "Serbia", 
        "South Africa", "Zambia", "Montenegro", "Zimbabwe", "Anonymous Proxy", "Satellite Provider", "Other", "Aland Islands", "Guernsey", "Isle of Man", "Jersey", "Saint Barthelemy", "Saint Martin", "Bonaire, Saint Eustatius and Saba"
     };

    public LookupService(string databaseFile) : this(databaseFile, GEOIP_STANDARD)
    {
    }

    public LookupService(string databaseFile, int options)
    {
        this.byte_0 = Convert.ToByte(DatabaseInfo.COUNTRY_EDITION);
        try
        {
            this.fileStream_0 = new FileStream(databaseFile, FileMode.Open, FileAccess.Read);
            this.int_4 = options;
            Class67.smethod_127(this);
        }
        catch (SystemException)
        {
            Console.Write("cannot open file " + databaseFile + "\n");
        }
    }

    public void close()
    {
        try
        {
            this.fileStream_0.Close();
            this.fileStream_0 = null;
        }
        catch (Exception)
        {
        }
    }

    public Country getCountry(long ipAddress)
    {
        if (this.fileStream_0 == null)
        {
            throw new Exception("Database has been closed.");
        }
        if ((this.byte_0 == DatabaseInfo.CITY_EDITION_REV1) | (this.byte_0 == DatabaseInfo.CITY_EDITION_REV0))
        {
            Location location = this.getLocation(ipAddress);
            if (location == null)
            {
                return country_0;
            }
            return new Country(location.countryCode, location.countryName);
        }
        int index = Class67.smethod_95(this, ipAddress) - int_1;
        if (index == 0)
        {
            return country_0;
        }
        return new Country(string_0[index], string_1[index]);
    }

    public Country getCountry(IPAddress ipAddress)
    {
        return this.getCountry(Class67.smethod_40(ipAddress.GetAddressBytes()));
    }

    public Country getCountry(string ipAddress)
    {
        Country country;
        try
        {
            IPAddress address = IPAddress.Parse(ipAddress);
            return this.getCountry(Class67.smethod_40(address.GetAddressBytes()));
        }
        catch (Exception exception)
        {
            Console.Write(exception.Message);
            country = country_0;
        }
        return country;
    }

    public Country getCountryV6(IPAddress ipAddress)
    {
        if (this.fileStream_0 == null)
        {
            throw new Exception("Database has been closed.");
        }
        if ((this.byte_0 == DatabaseInfo.CITY_EDITION_REV1) | (this.byte_0 == DatabaseInfo.CITY_EDITION_REV0))
        {
            Location location = this.getLocation(ipAddress);
            if (location == null)
            {
                return country_0;
            }
            return new Country(location.countryCode, location.countryName);
        }
        int index = Class67.smethod_5(this, ipAddress) - int_1;
        if (index == 0)
        {
            return country_0;
        }
        return new Country(string_0[index], string_1[index]);
    }

    public Country getCountryV6(string ipAddress)
    {
        Country country;
        try
        {
            IPAddress address = IPAddress.Parse(ipAddress);
            return this.getCountryV6(address);
        }
        catch (Exception exception)
        {
            Console.Write(exception.Message);
            country = country_0;
        }
        return country;
    }

    public DatabaseInfo getDatabaseInfo()
    {
        if (this.databaseInfo_0 != null)
        {
            return this.databaseInfo_0;
        }
        try
        {
            lock (this)
            {
                byte[] buffer2;
                bool flag = false;
                byte[] buffer = new byte[3];
                this.fileStream_0.Seek(-3L, SeekOrigin.End);
                for (int i = 0; i < int_15; i++)
                {
                    this.fileStream_0.Read(buffer, 0, 3);
                    if (((buffer[0] == 0xff) && (buffer[1] == 0xff)) && (buffer[2] == 0xff))
                    {
                        goto Label_007D;
                    }
                }
                goto Label_007F;
            Label_007D:
                flag = true;
            Label_007F:
                if (flag)
                {
                    this.fileStream_0.Seek(-3L, SeekOrigin.Current);
                }
                else
                {
                    this.fileStream_0.Seek(-3L, SeekOrigin.End);
                }
                int count = 0;
                while (count < int_2)
                {
                    this.fileStream_0.Read(buffer, 0, 3);
                    if (((buffer[0] == 0) && (buffer[1] == 0)) && (buffer[2] == 0))
                    {
                        goto Label_00F6;
                    }
                    this.fileStream_0.Seek(-4L, SeekOrigin.Current);
                    count++;
                }
                goto Label_016F;
            Label_00F6:
                buffer2 = new byte[count];
                char[] chArray = new char[count];
                this.fileStream_0.Read(buffer2, 0, count);
                for (int j = 0; j < count; j++)
                {
                    chArray[j] = Convert.ToChar(buffer2[j]);
                }
                this.databaseInfo_0 = new DatabaseInfo(new string(chArray));
                return this.databaseInfo_0;
            }
        }
        catch (Exception exception)
        {
            Console.Write(exception.Message);
        }
    Label_016F:
        return new DatabaseInfo("");
    }

    public int getID(long ipAddress)
    {
        if (this.fileStream_0 == null)
        {
            throw new Exception("Database has been closed.");
        }
        return (Class67.smethod_95(this, ipAddress) - this.int_3[0]);
    }

    public int getID(IPAddress ipAddress)
    {
        return this.getID(Class67.smethod_40(ipAddress.GetAddressBytes()));
    }

    public int getID(string ipAddress)
    {
        int num;
        try
        {
            IPAddress address = IPAddress.Parse(ipAddress);
            return this.getID(Class67.smethod_40(address.GetAddressBytes()));
        }
        catch (Exception exception)
        {
            Console.Write(exception.Message);
            num = 0;
        }
        return num;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public Location getLocation(long ipnum)
    {
        byte[] destinationArray = new byte[int_6];
        char[] chArray = new char[int_6];
        int startIndex = 0;
        Location location = new Location();
        int length = 0;
        double num3 = 0.0;
        double num4 = 0.0;
        try
        {
            int num8;
            int num5 = Class67.smethod_95(this, ipnum);
            if (num5 == this.int_3[0])
            {
                return null;
            }
            int sourceIndex = num5 + (((2 * this.int_10) - 1) * this.int_3[0]);
            if ((this.int_4 & GEOIP_MEMORY_CACHE) == 1)
            {
                Array.Copy(this.byte_1, sourceIndex, destinationArray, 0, Math.Min(this.byte_1.Length - sourceIndex, int_6));
            }
            else
            {
                this.fileStream_0.Seek((long) sourceIndex, SeekOrigin.Begin);
                this.fileStream_0.Read(destinationArray, 0, int_6);
            }
            for (int i = 0; i < int_6; i++)
            {
                chArray[i] = Convert.ToChar(destinationArray[i]);
            }
            location.countryCode = string_0[destinationArray[0] & 0xff];
            location.countryName = string_1[destinationArray[0] & 0xff];
            startIndex++;
            while (destinationArray[startIndex + length] != 0)
            {
                length++;
            }
            if (length > 0)
            {
                location.region = new string(chArray, startIndex, length);
            }
            startIndex += length + 1;
            length = 0;
            location.regionName = RegionName.getRegionName(location.countryCode, location.region);
            while (destinationArray[startIndex + length] != 0)
            {
                length++;
            }
            if (length > 0)
            {
                location.city = new string(chArray, startIndex, length);
            }
            startIndex += length + 1;
            length = 0;
            while (destinationArray[startIndex + length] != 0)
            {
                length++;
            }
            if (length > 0)
            {
                location.postalCode = new string(chArray, startIndex, length);
            }
            startIndex += length + 1;
            for (num8 = 0; num8 < 3; num8++)
            {
                num3 += (destinationArray[startIndex + num8] & 0xff) << (num8 * 8);
            }
            location.latitude = (((float) num3) / 10000f) - 180f;
            startIndex += 3;
            for (num8 = 0; num8 < 3; num8++)
            {
                num4 += (destinationArray[startIndex + num8] & 0xff) << (num8 * 8);
            }
            location.longitude = (((float) num4) / 10000f) - 180f;
            location.dma_code = 0;
            location.metro_code = 0;
            location.area_code = 0;
            if (this.byte_0 != DatabaseInfo.CITY_EDITION_REV1)
            {
                return location;
            }
            int num9 = 0;
            if (!(location.countryCode == "US"))
            {
                return location;
            }
            startIndex += 3;
            for (num8 = 0; num8 < 3; num8++)
            {
                num9 += (destinationArray[startIndex + num8] & 0xff) << (num8 * 8);
            }
            location.metro_code = location.dma_code = num9 / 0x3e8;
            location.area_code = num9 % 0x3e8;
        }
        catch (IOException)
        {
            Console.Write("IO Exception while seting up segments");
        }
        return location;
    }

    public Location getLocation(IPAddress addr)
    {
        return this.getLocation(Class67.smethod_40(addr.GetAddressBytes()));
    }

    public Location getLocation(string str)
    {
        Location location;
        try
        {
            IPAddress address = IPAddress.Parse(str);
            return this.getLocation(Class67.smethod_40(address.GetAddressBytes()));
        }
        catch (Exception exception)
        {
            Console.Write(exception.Message);
            location = null;
        }
        return location;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public Location getLocationV6(IPAddress addr)
    {
        byte[] destinationArray = new byte[int_6];
        char[] chArray = new char[int_6];
        int startIndex = 0;
        Location location = new Location();
        int length = 0;
        double num3 = 0.0;
        double num4 = 0.0;
        try
        {
            int num8;
            int num5 = Class67.smethod_5(this, addr);
            if (num5 == this.int_3[0])
            {
                return null;
            }
            int sourceIndex = num5 + (((2 * this.int_10) - 1) * this.int_3[0]);
            if ((this.int_4 & GEOIP_MEMORY_CACHE) == 1)
            {
                Array.Copy(this.byte_1, sourceIndex, destinationArray, 0, Math.Min(this.byte_1.Length - sourceIndex, int_6));
            }
            else
            {
                this.fileStream_0.Seek((long) sourceIndex, SeekOrigin.Begin);
                this.fileStream_0.Read(destinationArray, 0, int_6);
            }
            for (int i = 0; i < int_6; i++)
            {
                chArray[i] = Convert.ToChar(destinationArray[i]);
            }
            location.countryCode = string_0[destinationArray[0] & 0xff];
            location.countryName = string_1[destinationArray[0] & 0xff];
            startIndex++;
            while (destinationArray[startIndex + length] != 0)
            {
                length++;
            }
            if (length > 0)
            {
                location.region = new string(chArray, startIndex, length);
            }
            startIndex += length + 1;
            length = 0;
            location.regionName = RegionName.getRegionName(location.countryCode, location.region);
            while (destinationArray[startIndex + length] != 0)
            {
                length++;
            }
            if (length > 0)
            {
                location.city = new string(chArray, startIndex, length);
            }
            startIndex += length + 1;
            length = 0;
            while (destinationArray[startIndex + length] != 0)
            {
                length++;
            }
            if (length > 0)
            {
                location.postalCode = new string(chArray, startIndex, length);
            }
            startIndex += length + 1;
            for (num8 = 0; num8 < 3; num8++)
            {
                num3 += (destinationArray[startIndex + num8] & 0xff) << (num8 * 8);
            }
            location.latitude = (((float) num3) / 10000f) - 180f;
            startIndex += 3;
            for (num8 = 0; num8 < 3; num8++)
            {
                num4 += (destinationArray[startIndex + num8] & 0xff) << (num8 * 8);
            }
            location.longitude = (((float) num4) / 10000f) - 180f;
            location.dma_code = 0;
            location.metro_code = 0;
            location.area_code = 0;
            if ((this.byte_0 != DatabaseInfo.CITY_EDITION_REV1) && (this.byte_0 != DatabaseInfo.CITY_EDITION_REV1_V6))
            {
                return location;
            }
            int num9 = 0;
            if (!(location.countryCode == "US"))
            {
                return location;
            }
            startIndex += 3;
            for (num8 = 0; num8 < 3; num8++)
            {
                num9 += (destinationArray[startIndex + num8] & 0xff) << (num8 * 8);
            }
            location.metro_code = location.dma_code = num9 / 0x3e8;
            location.area_code = num9 % 0x3e8;
        }
        catch (IOException)
        {
            Console.Write("IO Exception while seting up segments");
        }
        return location;
    }

    public Location getLocationV6(string str)
    {
        Location location;
        try
        {
            IPAddress addr = IPAddress.Parse(str);
            return this.getLocationV6(addr);
        }
        catch (Exception exception)
        {
            Console.Write(exception.Message);
            location = null;
        }
        return location;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public string getOrg(long ipnum)
    {
        int index = 0;
        byte[] destinationArray = new byte[int_7];
        char[] chArray = new char[int_7];
        try
        {
            int num2 = Class67.smethod_95(this, ipnum);
            if (num2 == this.int_3[0])
            {
                return null;
            }
            int sourceIndex = num2 + (((2 * this.int_10) - 1) * this.int_3[0]);
            if ((this.int_4 & GEOIP_MEMORY_CACHE) == 1)
            {
                Array.Copy(this.byte_1, sourceIndex, destinationArray, 0, Math.Min(this.byte_1.Length - sourceIndex, int_7));
            }
            else
            {
                this.fileStream_0.Seek((long) sourceIndex, SeekOrigin.Begin);
                this.fileStream_0.Read(destinationArray, 0, int_7);
            }
            while (destinationArray[index] != 0)
            {
                chArray[index] = Convert.ToChar(destinationArray[index]);
                index++;
            }
            chArray[index] = '\0';
            return new string(chArray, 0, index);
        }
        catch (IOException)
        {
            Console.Write("IO Exception");
            return null;
        }
    }

    public string getOrg(IPAddress addr)
    {
        return this.getOrg(Class67.smethod_40(addr.GetAddressBytes()));
    }

    public string getOrg(string str)
    {
        string str2;
        try
        {
            IPAddress address = IPAddress.Parse(str);
            return this.getOrg(Class67.smethod_40(address.GetAddressBytes()));
        }
        catch (Exception exception)
        {
            Console.Write(exception.Message);
            str2 = null;
        }
        return str2;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public string getOrgV6(IPAddress addr)
    {
        int index = 0;
        byte[] destinationArray = new byte[int_7];
        char[] chArray = new char[int_7];
        try
        {
            int num2 = Class67.smethod_5(this, addr);
            if (num2 == this.int_3[0])
            {
                return null;
            }
            int sourceIndex = num2 + (((2 * this.int_10) - 1) * this.int_3[0]);
            if ((this.int_4 & GEOIP_MEMORY_CACHE) == 1)
            {
                Array.Copy(this.byte_1, sourceIndex, destinationArray, 0, Math.Min(this.byte_1.Length - sourceIndex, int_7));
            }
            else
            {
                this.fileStream_0.Seek((long) sourceIndex, SeekOrigin.Begin);
                this.fileStream_0.Read(destinationArray, 0, int_7);
            }
            while (destinationArray[index] != 0)
            {
                chArray[index] = Convert.ToChar(destinationArray[index]);
                index++;
            }
            chArray[index] = '\0';
            return new string(chArray, 0, index);
        }
        catch (IOException)
        {
            Console.Write("IO Exception");
            return null;
        }
    }

    public string getOrgV6(string str)
    {
        string str2;
        try
        {
            IPAddress addr = IPAddress.Parse(str);
            return this.getOrgV6(addr);
        }
        catch (Exception exception)
        {
            Console.Write(exception.Message);
            str2 = null;
        }
        return str2;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public Region getRegion(long ipnum)
    {
        Region region = new Region();
        int index = 0;
        if (this.byte_0 == DatabaseInfo.REGION_EDITION_REV0)
        {
            index = Class67.smethod_95(this, ipnum) - int_13;
            char[] chArray = new char[2];
            if (index >= 0x3e8)
            {
                region.countryCode = "US";
                region.countryName = "United States";
                chArray[0] = (char) (((index - 0x3e8) / 0x1a) + 0x41);
                chArray[1] = (char) (((index - 0x3e8) % 0x1a) + 0x41);
                region.region = new string(chArray);
                return region;
            }
            region.countryCode = string_0[index];
            region.countryName = string_1[index];
            region.region = "";
            return region;
        }
        if (this.byte_0 == DatabaseInfo.REGION_EDITION_REV1)
        {
            index = Class67.smethod_95(this, ipnum) - int_14;
            char[] chArray2 = new char[2];
            if (index < int_16)
            {
                region.countryCode = "";
                region.countryName = "";
                region.region = "";
                return region;
            }
            if (index < int_0)
            {
                region.countryCode = "US";
                region.countryName = "United States";
                chArray2[0] = (char) (((index - int_16) / 0x1a) + 0x41);
                chArray2[1] = (char) (((index - int_16) % 0x1a) + 0x41);
                region.region = new string(chArray2);
                return region;
            }
            if (index < int_17)
            {
                region.countryCode = "CA";
                region.countryName = "Canada";
                chArray2[0] = (char) (((index - int_0) / 0x1a) + 0x41);
                chArray2[1] = (char) (((index - int_0) % 0x1a) + 0x41);
                region.region = new string(chArray2);
                return region;
            }
            region.countryCode = string_0[(index - int_17) / int_5];
            region.countryName = string_1[(index - int_17) / int_5];
            region.region = "";
        }
        return region;
    }

    public Region getRegion(IPAddress ipAddress)
    {
        return this.getRegion(Class67.smethod_40(ipAddress.GetAddressBytes()));
    }

    public Region getRegion(string str)
    {
        Region region;
        try
        {
            IPAddress address = IPAddress.Parse(str);
            return this.getRegion(Class67.smethod_40(address.GetAddressBytes()));
        }
        catch (Exception exception)
        {
            Console.Write(exception.Message);
            region = null;
        }
        return region;
    }
}
