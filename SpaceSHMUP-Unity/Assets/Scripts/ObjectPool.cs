/**** 
 * Created by: Jacob Sharp
 * Date Created: April 6, 2022
 * 
 * Last Edited by: Jacob Sharp
 * Last Edited: April 11, 2022
 * 
 * Description: Create a pool of objects for reuse
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    static public ObjectPool POOL;
    #region POOL Singleton
    void CheckPoolIsInScene()
    {
        if (POOL == null) POOL = this;
        else Debug.LogError("POOL.Awake() - Attempted to assign a second ObjectPool.POOL");
    }
    #endregion

    private Queue<GameObject> projectiles = new Queue<GameObject>(); // holds the projectiles

    [Header("Pool Settings")]
    public GameObject projectilePrefab;
    public int poolStartSize = 5;

    void Awake()
    {
        CheckPoolIsInScene();
    }

    void Start()
    {
        for (int i = 0; i < poolStartSize; i++)
        {
            GameObject projectile = Instantiate(projectilePrefab); // create new projectile
            projectiles.Enqueue(projectile); // add to queue
            projectile.SetActive(false); // disable in scene
        }
    }

    public GameObject GetObject() // get first object in queue
    {
        if (projectiles.Count > 0)
        {
            GameObject obj = projectiles.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else
        {
            Debug.LogWarning("Out of objects, reloading...");
            return null;
        }
    }

    public void ReturnObject(GameObject obj) // return object to queue
    {
        projectiles.Enqueue(obj); // add to queue
        obj.SetActive(false); // disable
    }
}
