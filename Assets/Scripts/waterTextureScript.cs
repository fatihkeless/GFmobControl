using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterTextureScript : MonoBehaviour
{

    [Range(0,1)] public float scrollX = 0.5f;
    [Range(0, 1)] public float scrollY = 0.5f;

    private void Update()
    {
        

        float offsetX = Time.time * scrollX;
        float offsetY = Time.time * scrollY;

        
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offsetX, offsetY);
    }



}
