using System;

public class Region
{
    public string countryCode;
    public string countryName;
    public string region;

    public Region()
    {
    }

    public Region(string countryCode, string countryName, string region)
    {
        this.countryCode = countryCode;
        this.countryName = countryName;
        this.region = region;
    }

    public string getcountryCode()
    {
        return this.countryCode;
    }

    public string getcountryName()
    {
        return this.countryName;
    }
    public string getregion()
    {
        return this.region;
    }
}

