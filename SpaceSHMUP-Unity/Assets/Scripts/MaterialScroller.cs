/**** 
 * Created by: Jacob Sharp
 * Date Created: April 11, 2022
 * 
 * Last Edited by: Jacob Sharp
 * Last Edited: April 11, 2022
 * 
 * Description: Allows background material to scroll
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialScroller : MonoBehaviour
{
    public Vector2 scrollSpeed = new Vector2(0, 0.35f);

    private Renderer rend;
    private Material mat;

    private Vector2 offset;

    void Start()
    {
        rend = GetComponent<Renderer>();
        mat = rend.material;
    }

    void Update()
    {
        // offset texture each frame
        offset = scrollSpeed * Time.deltaTime;
        mat.mainTextureOffset += offset;
    }
}
