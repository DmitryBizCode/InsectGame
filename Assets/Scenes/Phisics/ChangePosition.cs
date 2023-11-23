using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePosition
{
    private InsectBody insec;

    public ChangePosition(InsectBody a) => this.insec = a;
       
    public void ChangePositions()
    {
        var rand = new System.Random();
        var water = new Water();
        
            if (insec != null && insec.Live == "yes")
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

                //foreach ((int x, int y) in water.waterList)
                //{
                    //if (insec.XY == (x, y))
                    //{
                        //resurs.WaterAdd(insec);
                        //insec.XY = (0, 0);
                    //}
                //}
                //addfood
            }
        }
}

