using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialScroller : MonoBehaviour
{
    Renderer myRenderer; //used to control material options

    [SerializeField, Tooltip("This is for controlling Material Scroll Speed Illusion")]
    float offsetY = -0.1f;


    private void Awake()
    {
        myRenderer = GetComponent<Renderer>();
    }

    private void FixedUpdate()
    {
        offsetY *= Time.fixedDeltaTime;
        myRenderer.material.mainTextureOffset = new Vector2(0f, offsetY);
    }

    public void SpeedUp()
    {
        offsetY += -1f;
    }
}
