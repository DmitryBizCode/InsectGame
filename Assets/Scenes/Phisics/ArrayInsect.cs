using Microsoft.Win32.SafeHandles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class ArrayInsect : IInsect_Helth
{
    private readonly List<AbstractBody> body;

    public List<AbstractBody> ListInsectGet() => body;
    
    public int SizeArray() => body.Count;
    
    public ArrayInsect() => body = new List<AbstractBody>();
    
    public void AddBody(AbstractBody shape) => body!.Add(shape);

    public void MinusHealth2Leg()
    {
        foreach (AbstractBody bodyPart in body)        
            if (bodyPart is InsectBody insec && insec.Live == "yes")
            {
                insec.Health -= 2;
                if (insec.Health <= 0)
                    body.Remove(insec);
            }        
    }


    /*public void PlusHaelth2Leg()
    {
        foreach (AbstractBody bodies in body)
            if (bodies is InsectBody)
            {
                InsectBody insec = (InsectBody)bodies;
                if (insec.Live == "yes" && insec.Health < 6)
                {
                    insec.Health += 2;
                    if (insec.Health > 6)
                        insec.Health = 6;
                }
            }
    }*/
}
