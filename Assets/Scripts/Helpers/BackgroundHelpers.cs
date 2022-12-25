using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundHelpers : MonoBehaviour
{
    public Renderer backRenderer;

    void Update()
    {
        if(backRenderer != null){
            backRenderer.material.mainTextureOffset = new Vector2(0.0f, 0.2f * Time.time);
        }
    }
}
