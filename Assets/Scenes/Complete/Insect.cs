using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Insect : MonoBehaviour
{
    private ChangePosition posit;
    public InsectBody ins;

    private float timer = 0f; //timer
    readonly float delay = 1f; //limit timer


    void Start()
    {
        ins = new InsectBody(6, "yes", 0, 0);
        posit = new ChangePosition(ins);
        transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // додаємо час, що пройшов з останнього кадру        
        if (timer >= delay)
        {
            posit.DetectedFMW();
            posit.ChangePositions();
            Eating();
            transform.position = new Vector3(ins.XY.Item1, ins.XY.Item2, 0);
            timer = 0f; // скидаємо таймер для нової затримки
        }
    }
    private void Eating()
    {
        WaterBase b = new();
        FoodBase a = new();
        MaterialDel del = new();
        if (del.GetFoodValue() > 0 && del.GetWaterValue() > 0)
        {
            b.WaterDel();
            a.FoodDel();
        }
        else if (del.GetFoodValue() >= 6 && del.GetWaterValue() <= 0)
            a.FoodDelWithoutWater();
        else if (del.GetWaterValue() >= 3 && del.GetFoodValue() <= 0)
            b.WaterDelWithoutFood();
        else
        {
            ins.MinusHealth2Leg();
            if (ins.Live != "yes")            
                ins.XY = (0, 100);            
        }
    }
}
