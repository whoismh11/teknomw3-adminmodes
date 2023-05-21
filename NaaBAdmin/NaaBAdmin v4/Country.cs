using System;

public class Country
{
    private string string_0;
    private string string_1;

    public Country(string code, string name)
    {
        this.string_0 = code;
        this.string_1 = name;
    }

    public string getCode()
    {
       return this.string_0;
    }

    public string getName()
    {
        return this.string_1;
    }
}

