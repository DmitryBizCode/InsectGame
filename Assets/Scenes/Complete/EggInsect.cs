using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggInsect : MonoBehaviour
{
    private readonly int Timer;

    public EggLive egg ;
    private float timer = 0f; //timer
    readonly float delay = 3f; //limit timer
    // Start is called before the first frame update
    void Start()
    {
        egg = new EggLive(Timer);
        (int,int) house = CoordinateHouse.GetRandomCoordinate();
        if (house.Item1 == 0 && house.Item2 == 0)
            house = (1, -1);        
        transform.position = new Vector3(house.Item1, house.Item2 + 1,0);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // додаємо час, що пройшов з останнього кадру        
        if (timer >= delay)
        {            
            egg.Time++;
            if (egg.Time > 5)
            {
                WaterBase b = new ();
                FoodBase a = new ();
                egg.GrowUp();
                b.WaterDelChild();
                a.FoodDelChild();
            }          
            timer = 0f; // скидаємо таймер для нової затримки
            if(egg.Live != "yes")
                transform.position = new Vector3(100, 100, 0);
        }
    }
}
