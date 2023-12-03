using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MobsFight : MonoBehaviour
{
    private ChangePosition posit;
    public InsectBody ins;

    private float timer = 0f; //timer
    readonly float delay = 1f; //limit timer


    void Start()
    {
        var rand = new System.Random();
        int randomNumberX = rand.Next(-20, 30);
        int randomNumberY = rand.Next(-17, 17);
        ins = new InsectBody(2, "yes", randomNumberX, randomNumberY);
        posit = new ChangePosition(ins);
        transform.position = new Vector3(randomNumberX, randomNumberY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Death();
        timer += Time.deltaTime; // додаємо час, що пройшов з останнього кадру        
        if (timer >= delay)
        {
            posit.ChangePositions();
            transform.position = new Vector3(ins.XY.Item1, ins.XY.Item2, 0);
            
            timer = 0f; // скидаємо таймер для нової затримки
        }
    }
    private void Death()
    {
        if (transform.position == new Vector3(0f, 100f, 0f))
        {
            ins.MinusHealth2Leg();
            if (ins.Live != "yes")
                ins.XY = (0, 100);
        }      
    }
}
