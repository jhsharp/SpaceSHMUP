/**** 
 * Created by: Jacob Sharp
 * Date Created: March 30, 2022
 * 
 * Last Edited by: Jacob Sharp
 * Last Edited: March 30, 2022
 * 
 * Description: Basic GameManager Template
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private BoundsCheck bndCheck; // reference to the bounds check
    private void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
    }

    void Update()
    {
        // if off screen, destroy
        if (bndCheck.offUp)
        {
            Destroy(gameObject);
        }
    }
}
