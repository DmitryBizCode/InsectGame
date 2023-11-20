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
    private ArrayInsect arrayInsect = new ArrayInsect();
    private float timer = 0f;
    private float delay = 1f;
    void Start()
    {
        arrayInsect.AddBody(new InsectBody(Health, "yes", 0, 0));
        transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // додаємо час, що пройшов з останнього кадру

        if (timer >= delay)
        {
            transform.position = new Vector3(10, 18, 0);
            timer = 0f; // скидаємо таймер для нової затримки
        }
    }
}
