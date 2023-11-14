using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePosition
{
    private readonly Resurses resurs;
    private readonly ArrayInsect a;

    public ChangePosition(ref Resurses resurs, ArrayInsect a)
    {
        this.resurs = resurs;
        this.a = a;
    }

    public void ChangePos()
    {
        var rand = new System.Random();
        var water = new Water();
        foreach (AbstractBody bodyPart in a.ListInsectGet())
        {
            if (bodyPart is InsectBody insec && insec.Live == "yes")
            {
                int randomNumber = rand.Next(1, 5);
                if (randomNumber == 1)
                    insec.XY = (insec.XY.Item1, insec.XY.Item2 + 1);
                else if (randomNumber == 2)
                    insec.XY = (insec.XY.Item1 + 1, insec.XY.Item2);
                else if (randomNumber == 3)
                    insec.XY = (insec.XY.Item1, insec.XY.Item2 - 1);
                else if (randomNumber == 4)
                    insec.XY = (insec.XY.Item1 - 1, insec.XY.Item2);

                foreach ((int x, int y) in water.waterList)
                {
                    if (insec.XY == (x, y))
                    {
                        resurs.WaterAdd();
                        insec.XY = (0, 0);
                    }
                }
                //addfood
            }
        }
    }
}
