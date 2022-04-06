/**** 
 * Created by: Jacob Sharp
 * Date Created: April 6, 2022
 * 
 * Last Edited by: Jacob Sharp
 * Last Edited: April 6, 2022
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
        
    }

    void Update()
    {
        
    }
}
