/**** 
 * Created by: Jacob Sharp
 * Date Created: March 28, 2022
 * 
 * Last Edited by: Jacob Sharp
 * Last Edited: March 28, 2022
 * 
 * Description: Spawns enemies into the scene
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("ENEMY SETTINGS")]
    public GameObject[] prefabEnemies; // prefabs for all enemies
    public float enemySpawnPerSecond; // number of enemies to spawn per second
    public float enemyDefaultPadding; // padding between enemy positions

    private BoundsCheck bndCheck;

    void Start()
    {
        bndCheck = GetComponent<BoundsCheck>(); // get reference to BoundsCheck component
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);
    }

    public void SpawnEnemy()
    {
        // instantiate a random enemy
        int i = Random.Range(0, prefabEnemies.Length);
        GameObject obj = Instantiate<GameObject>(prefabEnemies[i]);

        // set the enemy's padding
        float enemyPadding = enemyDefaultPadding;
        if (obj.GetComponent<BoundsCheck>() != null)
        {
            enemyPadding = Mathf.Abs(obj.GetComponent<BoundsCheck>().radius);
        }

        // randomly position the enemy above the screen
        Vector3 pos = Vector3.zero;
        float xMin = -bndCheck.camWidth + enemyPadding;
        float xMax = bndCheck.camWidth - enemyPadding;
        pos.x = Random.Range(xMin, xMax);
        pos.y = bndCheck.camHeight + enemyPadding;
        obj.transform.position = pos;

        // invoke spawn enemy again
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);
    }
}
