using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggLive
{
    public string Live {  get; private set; }
    public int Time { get; set; }
    public EggLive(int time)
    {
        Live = "yes";
        Time = time;
    }
    public void GrowUp() => Live = "no";
    
}
