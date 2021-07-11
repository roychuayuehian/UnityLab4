using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    void Start()
    {
        GameManager.OnEnemyDeath += Respawn;
        // spawn two gombaEnemy
        for (int j = 0; j < 2; j++)
        {
            Debug.Log("for loop spawn");
            spawnFromPooler(ObjectType.gombaEnemy);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnFromPooler(ObjectType i)
    {
        // static method access
        GameObject item = ObjectPooler.SharedInstance.GetPooledObject(i);
        
        if (item != null)
        {
            //set position, and other necessary states
            Debug.Log("spawning");
            item.transform.position = new Vector3(Random.Range(-4.5f, 4.5f), item.transform.position.y, 0);
            item.SetActive(true);
            item.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else
        {
            Debug.Log("not enough items in the pool.");
        }
    }

    void Respawn()
    {
        spawnFromPooler(ObjectType.gombaEnemy);
    }
}
