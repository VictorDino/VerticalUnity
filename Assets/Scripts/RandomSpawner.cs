using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
 
    public GameObject objectToSpawn;

    public float xPos;
    public float zPos;

    public int enemyCount;

  
   
    private void Start()
    {
        StartCoroutine(EnemyDrop());  
    }

    void Update()
    {

    }

    IEnumerator EnemyDrop()
    {
        while(enemyCount < 10)
        {
            xPos = Random.Range(-36, 36);
            xPos = Random.Range(-36, 36);

            Instantiate(objectToSpawn, new Vector3(xPos, 0, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount++;   
        }

    }
}
