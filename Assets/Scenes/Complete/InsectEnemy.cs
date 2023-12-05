using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy_Insect;
    [SerializeField] private GameObject clevermobs;
    [SerializeField] private GameObject Egg;
    [SerializeField] private GameObject Mobs;

    [SerializeField] private int start_spawn_count;
    [SerializeField] private int maximum_spawn_ins;

    readonly float radius = 1.5f; // Радіус для перевірки мобів і інсектів

    readonly List<GameObject> lis = new ();
    private float timer = 0f;
    readonly float delay = 1f;
    private int TTL = 0;
    private int n = 0;
    private int egg_count = 0;
    private int qwerty = 0;
    private int mobs_count = 0;
    private int clever_count = 20;
    private int ttlegg = 0;

    private int l = 0;
    // Start is called before the first frame update
    void Start() => SpawnFirst();
    
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // додаємо час, що пройшов з останнього кадру

        if (timer >= delay)
        {
            LookingFight();
            SpawnMobs();
            GrowUpInsect();
            if (ttlegg % 3 == 0)
            {
                SpawnEgg();
            }            
            TTL++;
            ttlegg++;
            timer = 0f; // скидаємо таймер для нової затримки
        }
    }
    private void SpawnFirst()
    {
        for (int i = 0; i < start_spawn_count; i++)
        {
            GameObject newEnemy  = Instantiate(clevermobs, transform.position, Quaternion.identity);
            newEnemy.name = "Enemy_CLEVER_" + n.ToString(); // Присвоюємо унікальне ім'я кожному об'єкту
            lis.Add(newEnemy);
            n++;
        }       
    }
    private void SpawnEgg() {
        if ((n + qwerty) <= maximum_spawn_ins - mobs_count && TTL > 2 && qwerty < (int)((n / 2) + 1))
        {
            MaterialDel del = new();
            if (del.GetWaterValue() > (lis.Count * 20 + 5) && del.GetFoodValue() > (lis.Count * 20 + 4))
            {
                GameObject newEnemy = Instantiate(Egg, transform.position, Quaternion.identity);
                newEnemy.name = "Egg" + egg_count.ToString(); // Присвоюємо унікальне ім'я кожному яйцю
                lis.Add(newEnemy);
                egg_count++;
                qwerty++;
            }
        }
    }
    private void GrowUpInsect()
    {
        if (lis.Count > 0)
            for (int i = 0; i < 1; i++)
                foreach (GameObject enemy in lis)
                {
                    // Робимо щось з кожним об'єктом
                    var pos = enemy.transform.position;
                    if (pos == new Vector3(0f, 100f, 0f))
                    {
                        if (enemy.name.StartsWith("Mobs"))
                            mobs_count--;
                        if (enemy.name.StartsWith("Enemy_CLEVER_"))
                            clever_count--;
                        Destroy(enemy);
                        lis.Remove(enemy);
                        i = 0;
                        break;
                    }
                    if (enemy.name.StartsWith("Egg"))
                        if (pos == new Vector3(100f, 100f, 0f))
                        {
                            Destroy(enemy);
                            lis.Remove(enemy);
                            GameObject newEnemy;
                            MaterialDel info = new();
                            if ((info.GetFoodValue() + info.GetWaterValue()) < (lis.Count * 100 / (clever_count-19)))
                            {
                                newEnemy = Instantiate(clevermobs, transform.position, Quaternion.identity);
                                newEnemy.name = "Enemy_CLEVER_" + n.ToString(); // Присвоюємо унікальне ім'я кожному об'єкту
                                clever_count++;
                            }
                            else
                            {
                                newEnemy = Instantiate(enemy_Insect, transform.position, Quaternion.identity);
                                newEnemy.name = "Enemy_" + n.ToString(); // Присвоюємо унікальне ім'я кожному об'єкту
                            }
                            n++;
                            qwerty--;
                            lis.Add(newEnemy);
                            i = 0;
                            break;
                        }
                }
    }
    public void SpawnMobs()
    {
        float res = (float)((lis.Count - (mobs_count * 5)) / 25f);
        if (FW() + res > 1f)
        {
            GameObject newEnemy = Instantiate(Mobs, transform.position, Quaternion.identity);
            newEnemy.name = "Mobs" + l.ToString(); // Присвоюємо унікальне ім'я кожному мобу
            lis.Add(newEnemy);
            mobs_count++;
            l++;
        }
    }
    public float FW()
    {
        MaterialDel del = new();
        System.Random rand = new();
        int randomIndex = rand.Next(0, 16);
        int randomIndex2 = rand.Next(0, 16);
        float cef = 0;
        if (del.GetWaterValue() > 1500)
            if (randomIndex > 5)
                cef = 1;
        else if (del.GetWaterValue() < 1500)
            if (randomIndex < 5)
                cef = 1;
        if (del.GetFoodValue() > 1500)
            if (randomIndex2 > 5)
                cef *= 1;
        else if (del.GetFoodValue() < 1500)
            if (randomIndex2 < 5)
                cef *= 1;
        else 
             cef = 0;
        cef *= 0.3f;
        return cef;
    }
    private void LookingFight()
    {
        if (lis.Count > 0)
            foreach (GameObject mobsik in lis)                
                if(mobsik.name.StartsWith("Mobs"))
                    foreach (GameObject enemy in lis)                        
                        if (enemy.name.StartsWith("Ene"))
                        {
                            // Перевірка, чи відстань менша за заданий радіус
                            float distance = Vector3.Distance(mobsik.transform.position, enemy.transform.position);
                            if ((distance <= radius))
                            {
                                enemy.transform.position = new Vector3(enemy.transform.position.x + 1, enemy.transform.position.y, 0f);
                                mobsik.transform.position = new Vector3(mobsik.transform.position.x + 1, mobsik.transform.position.y, 0f);
                                if (mobsik.transform.position == enemy.transform.position)                                    
                                    mobsik.transform.position = new Vector3(0f,100f, 0f);                                    
                            }
                        }                                             
                
    }
}