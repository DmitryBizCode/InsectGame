using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractBody
{
    public string Live { get; set; }
    public AbstractBody(string live) => Live = live;
    
}
