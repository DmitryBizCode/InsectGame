using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class FoodTexture : MonoBehaviour
{
    [SerializeField] private GameObject[] texture;
    [SerializeField] private int FoodCount;

    readonly List<GameObject> lis = new();
    // Start is called before the first frame update
    private void Awake()
    {
        for (int i = 0; i < FoodCount; i++)        
            StarterSpawn();        
    }

    // Update is called once per frame
    void Update()
    {
        DetectedDel();
        if (lis.Count != FoodCount) 
            for (int i = lis.Count; i <= FoodCount; i++)
                StarterSpawn();        
    }
    private void DetectedDel()
    {        
        for (int i = 0; i < 1; i++)
            foreach (GameObject enemy in lis)
            {
                // Робимо щось з кожним об'єктом
                var pos = enemy.transform.position;
                int posx = (int)pos.x;
                int posy = (int)pos.y;
                bool flag = false;
                for (int j = 0; j < CoordinateFoodMaterial.StaticFoodCoordinate.Count; j++)
                    if ((posx, posy) == CoordinateFoodMaterial.StaticFoodCoordinate[j]) 
                        flag = true;                                    
                if (flag == false)
                {
                    Destroy(enemy);
                    lis.Remove(enemy);
                    i = 0;
                    break;
                }
            }
    }
    private void StarterSpawn()
    {        
        System.Random rand = new ();
        int randomIndex = rand.Next(0, 15);
        var newEnemy = Instantiate(texture[randomIndex], transform.position, Quaternion.identity);
        int randomNumberX = rand.Next(-20, 30);
        int randomNumberY = rand.Next(-17, 17);
        newEnemy.transform.position = new Vector3(randomNumberX, randomNumberY, 0);
        lis.Add(newEnemy);
        CoordinateFoodMaterial.StaticFoodCoordinate.Add((randomNumberX, randomNumberY));
    }

}
