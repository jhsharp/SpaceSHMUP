/**** 
 * Created by: Jacob Sharp
 * Date Created: April 6, 2022
 * 
 * Last Edited by: Jacob Sharp
 * Last Edited: April 6, 2022
 * 
 * Description: Behavior for projectiles
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private BoundsCheck bndCheck; // reference to bounds check component

    void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>(); // get bounds check reference
    }

    void Update()
    {
        // delete projectile if it goes offscreen
        if (bndCheck.offUp)
        {
            Destroy(gameObject);
        }
    }
}
