using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy_Insect;
    [SerializeField] private float start_spawn_count;
    [SerializeField] private float maximum_spawn_ins;


    private ArrayInsect arrayInsect;
    private List<GameObject> lis = new List<GameObject>();
    private float timer = 0f;
    private float delay = 1f;
    int n = 4;
    // Start is called before the first frame update
    void Start()
    {
        //SpawnFirst();
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // додаємо час, що пройшов з останнього кадру

        if (timer >= delay)
        {
            foreach (GameObject enemy in lis)
            {
                // Робимо щось з кожним об'єктом
                var pos = enemy.transform.position;
                if (pos == new Vector3(0f,10f,0f))
                {
                    Destroy(enemy);
                    lis.Remove(enemy);
                }
            }
            //posit.ChangePos();
            if (5 > n) 
                lis.Add(Instantiate(enemy_Insect,transform.position,Quaternion.identity));
            //foreach (GameObject enemy in lis)
            //{
                        // Робимо щось з кожним об'єктом
                //enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y+1, 0);                
            //}

            timer = 0f; // скидаємо таймер для нової затримки
            n++;


        }
    }
    private void SpawnFirst()
    {
        for (int i = 0; i < 20; i++)
        {
            lis.Add(Instantiate(enemy_Insect, transform.position, Quaternion.identity));
        }       
    }


}
