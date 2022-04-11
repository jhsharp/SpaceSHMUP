/**** 
 * Created by: Jacob Sharp
 * Date Created: April 11, 2022
 * 
 * Last Edited by: Jacob Sharp
 * Last Edited: April 11, 2022
 * 
 * Description: Returns object to pool on disable
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolReturn : MonoBehaviour
{
    private ObjectPool pool;

    private void Start()
    {
        pool = ObjectPool.POOL;
    }

    private void OnDisable()
    {
        if (pool != null)
        {
            pool.ReturnObject(gameObject); // return object to pool
        }
    }
}
