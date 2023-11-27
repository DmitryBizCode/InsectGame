using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy_Insect;
    [SerializeField] private GameObject Egg;

    [SerializeField] private int start_spawn_count;
    [SerializeField] private int maximum_spawn_ins;


    readonly List<GameObject> lis = new ();
    private float timer = 0f;
    readonly float delay = 1f;
    private int TTL = 0;
    private int n = 0;
    private int egg_count = 0;
    private int qwerty = 0;
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
            GrowUpInsect();
            SpawnEgg();
            TTL++;
            timer = 0f; // ������� ������ ��� ���� ��������
        }
    }
    private void SpawnFirst()
    {
        for (int i = 0; i < 1; i++)
        {
            GameObject newEnemy  = Instantiate(enemy_Insect, transform.position, Quaternion.identity);
            newEnemy.name = "Enemy_" + n.ToString(); // ���������� �������� ��'� ������� ��'����
            lis.Add(newEnemy);
            n++;
        }       
    }
    private void SpawnEgg() {
        if ((n + qwerty) <= maximum_spawn_ins && TTL > 2 && qwerty < (int)((n / 2) + 1))
        {
            MaterialDel del = new();
            if (del.GetWaterValue() > (lis.Count * 15 + 5) && del.GetFoodValue() > (lis.Count * 15 + 4))
            {
                GameObject newEnemy = Instantiate(Egg, transform.position, Quaternion.identity);
                newEnemy.name = "Egg" + egg_count.ToString(); // ���������� �������� ��'� ������� ����
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
                            newEnemy.name = "Enemy_" + n.ToString(); // ���������� �������� ��'� ������� ��'����
                            n++;
                            qwerty--;
                            lis.Add(newEnemy);
                            i = 0;
                            break;
                        }
                }
    }
}
