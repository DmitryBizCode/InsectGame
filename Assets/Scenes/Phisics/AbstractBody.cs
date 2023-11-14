using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractBody
{
    public string Name { get; set; }
    public AbstractBody(string name) => Name = name;
    
}
