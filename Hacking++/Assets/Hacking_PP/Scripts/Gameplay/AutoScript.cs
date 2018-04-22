using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class AutoScript
{
    public string name { get; private set; }
    public string code { get; set; }

    public AutoScript(string name)
    {
        this.name = name;
    }
}
