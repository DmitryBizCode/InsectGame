using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectBody : AbstractBody
{
    public int Health { get; set; }
    public string Live { get; set; }
    public (int, int) XY { get; set; }
    public InsectBody(int helth, string live, int x, int y) : base(live)
    {
        Health = helth;
        Live = live;
        XY = (x,y);
    }
}
