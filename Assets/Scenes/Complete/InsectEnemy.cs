using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy_Insect;
    [SerializeField] private GameObject Egg;
    [SerializeField] private GameObject Mobs;

    [SerializeField] private int start_spawn_count;
    [SerializeField] private int maximum_spawn_ins;


    readonly List<GameObject> lis = new ();
    private float timer = 0f;
    readonly float delay = 1f;
    private int TTL = 0;
    private int n = 0;
    private int egg_count = 0;
    private int qwerty = 0;
    private int mobs_count = 0;
    private int l = 0;
    // Start is called before the first frame update
    void Start()
    {
        n = start_spawn_count;
        SpawnFirst();
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // ������ ���, �� ������� � ���������� �����

        if (timer >= delay)
        {
            SpawnMobs();
            GrowUpInsect();
            SpawnEgg();
            TTL++;
            timer = 0f; // ������� ������ ��� ���� ��������
        }
    }
    private void SpawnFirst()
    {
        for (int i = 0; i < 22; i++)
        {
            GameObject newEnemy  = Instantiate(enemy_Insect, transform.position, Quaternion.identity);
            newEnemy.name = "Enemy_" + n.ToString(); // ���������� ��������� ��'� ������� ��'����
            lis.Add(newEnemy);
            n++;
        }       
    }
    private void SpawnEgg() {
        if ((n + qwerty) <= maximum_spawn_ins - mobs_count && TTL > 2 && qwerty < (int)((n / 2) + 1))
        {
            MaterialDel del = new();
            if (del.GetWaterValue() > (lis.Count * 15 + 5) && del.GetFoodValue() > (lis.Count * 15 + 4))
            {
                GameObject newEnemy = Instantiate(Egg, transform.position, Quaternion.identity);
                newEnemy.name = "Egg" + egg_count.ToString(); // ���������� ��������� ��'� ������� ����
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
                    // ������ ���� � ������ ��'�����
                    var pos = enemy.transform.position;
                    if (pos == new Vector3(0f, 100f, 0f))
                    {
                        if (enemy.name.StartsWith("Mobs"))
                            mobs_count--;
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
                            GameObject newEnemy = Instantiate(enemy_Insect, transform.position, Quaternion.identity);
                            newEnemy.name = "Enemy_" + n.ToString(); // ���������� ��������� ��'� ������� ��'����
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
            newEnemy.name = "Mobs" + l.ToString(); // ���������� ��������� ��'� ������� ����
            lis.Add(newEnemy);
            mobs_count++;
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
    /*private void LookingFight()
    {
        if (lis.Count > 0)
            for (int i = 0; i < 1; i++)
                foreach (GameObject mobsik in lis)
                {
                    if(mobsik.name.StartsWith("Mobs"))
                        foreach (GameObject enemy in lis)
                        {
                            if (mobsik.name.StartsWith("Enemy_"))
                            {

                            }
                            // ������ ���� � ������ ��'�����
                            var pos = enemy.transform.position;
                            if (pos == new Vector3(0f, 100f, 0f))
                            {

                                i = 0;
                                break;
                            }
                        }
                    // ������ ���� � ������ ��'�����
                    var pos = enemy.transform.position;
                    if (pos == new Vector3(0f, 100f, 0f))
                    {
                        
                        i = 0;
                        break;
                    }                   
                }
    }*/
}
