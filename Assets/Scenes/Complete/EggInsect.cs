using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggInsect : MonoBehaviour
{
    [SerializeField] private int Timer;

    public EggLive egg ;
    private float timer = 0f; //timer
    readonly float delay = 1f; //limit timer
    // Start is called before the first frame update
    void Start()
    {
        egg = new EggLive(Timer);
        (int,int) house = CoordinateHouse.GetRandomCoordinate();
        transform.position = new Vector3(house.Item1, house.Item2,0);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // додаємо час, що пройшов з останнього кадру        
        if (timer >= delay)
        {
            egg.Time++;
            if (egg.Time > 5)
                egg.GrowUp();            
            timer = 0f; // скидаємо таймер для нової затримки
            if(egg.Live != "yes")
                transform.position = new Vector3(100, 100, 0);
        }
    }
}
