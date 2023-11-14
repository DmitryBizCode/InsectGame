using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectBody : AbstractBody
{
    public int Health { get; set; }
    public string Live { get; set; }
    public string Name { get; set; }
    public (int, int) XY { get; set; }
    public InsectBody(int helth, string live, string name, int x, int y) : base(name)
    {
        Health = helth;
        Live = live;
        Name = name;
        XY = (x,y);
    }
}
