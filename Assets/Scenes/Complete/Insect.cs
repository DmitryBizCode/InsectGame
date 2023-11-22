using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class Insect : MonoBehaviour
{

    [SerializeField] private int Health;
    [SerializeField] private GameObject InsectGraphics;



    private ArrayInsect arrayInsect;
    private Resurses resurs;
    private ChangePosition posit;
    public InsectBody ins;
    private float timer = 0f;
    private float delay = 1f;
    void Start()
    {
        resurs = new Resurses();
        arrayInsect = new ArrayInsect();
        posit = new ChangePosition(resurs, arrayInsect);
        ins = new InsectBody(Health, "yes", 0, 0);
        arrayInsect.AddBody(ins);
        transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // додаємо час, що пройшов з останнього кадру

        if (timer >= delay)
        {
            posit.ChangePos();            
            
            transform.position = new Vector3(ins.XY.Item1, ins.XY.Item2, 0);
            timer = 0f; // скидаємо таймер для нової затримки
        }
    }
}
