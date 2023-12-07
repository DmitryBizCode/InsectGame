using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectBody : IInsect_Helth
{
    public int Health { get; set; }
    public string Live { get; set; }
    public (int, int) XY { get; set; }
    public InsectBody(int helth, string live, int x, int y)
    {
        Health = helth;
        Live = live;
        XY = (x,y);
    }
    public void MinusHealth2Leg()
    {
        Health -= 2;
        Live = (Health > 0) ? Live : "no";        
    }
}
