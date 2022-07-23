using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{

    public GameObject cyberEnemy;
    public GameObject player;
    float timeCounter = 0;
    float enemyCounter = 0;
    float spawnX = 0;
    float spawnZ = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;

        if(timeCounter > 10 && enemyCounter < 6)
        {
            GameObject newEnemy = Instantiate(cyberEnemy, new Vector3(player.transform.position.x + (20+spawnX), 0, player.transform.position.z + (20+spawnZ)), Quaternion.identity);
            enemyCounter++;
            spawnX += 5;
            spawnZ -= 5;

        }
    }
}
