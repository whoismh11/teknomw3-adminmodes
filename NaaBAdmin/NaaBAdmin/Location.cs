using System;
public class Location
{
    public int area_code;
    public string city;
    public string countryCode;
    public string countryName;
    public int dma_code;
    private static double double_0 = 12756.4;
    private static double double_1 = 3.14159265;
    private static double double_2 = (double_1 / 180.0);
    public double latitude;
    public double longitude;
    public int metro_code;
    public string postalCode;
    public string region;
    public string regionName;

    public double distance(Location loc)
    {
        double latitude = this.latitude;
        double longitude = this.longitude;
        double d = loc.latitude;
        double num4 = loc.longitude;
        latitude *= double_2;
        d *= double_2;
        double num5 = d - latitude;
        double num6 = (num4 - longitude) * double_2;
        double num7 = Math.Pow(Math.Sin(num5 / 2.0), 2.0) + ((Math.Cos(latitude) * Math.Cos(d)) * Math.Pow(Math.Sin(num6 / 2.0), 2.0));
        return (double_0 * Math.Atan2(Math.Sqrt(num7), Math.Sqrt(1.0 - num7)));
    }
}
