/**** 
 * Created by: Akram Taghavi-Burris
 * Date Created: March 16, 2022
 * 
 * Last Edited by: Jacob Sharp
 * Last Edited: April 4, 2022
 * 
 * Description: Spawn enemies within the boundary
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("ENEMY SETTINGS")]
    public GameObject[] prefabEnemies; // array of enemy prefabs
    public float enemySpawnPerSecond; // spawn rate of enemies
    public float enemyDefaultPadding; // padding for enemy positions

    private BoundsCheck bndCheck; // reference to bounds check component

    void Start()
    {
        bndCheck = GetComponent<BoundsCheck>(); // get reference to bounds check
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond); // start spawning enemies after the time delay
    }

    void SpawnEnemy()
    {
        // instantiate a random enemy
        int n = Random.Range(0, prefabEnemies.Length);
        GameObject enemy = Instantiate<GameObject>(prefabEnemies[n]);

        // give the enemy a random x position
        float enemyPadding = enemyDefaultPadding;
        if (enemy.GetComponent<BoundsCheck>() != null)
        {
            enemyPadding = Mathf.Abs(enemy.GetComponent<BoundsCheck>().radius);
        }

        // set the initial position
        Vector3 pos = Vector3.zero;
        float xMin = -bndCheck.camWidth + enemyPadding;
        float xMax = bndCheck.camWidth - enemyPadding;

        pos.x = Random.Range(xMin, xMax);
        pos.y = bndCheck.camHeight + enemyPadding;

        enemy.transform.position = pos;

        // invoke again
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);
    }
}
