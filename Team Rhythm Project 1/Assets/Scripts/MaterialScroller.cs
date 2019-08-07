using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialScroller : MonoBehaviour
{
    Renderer myRenderer; //used to control material options

    [SerializeField, Tooltip("This is for controlling Material Scroll Speed Illusion")]
    private float offsetY = -0.1f;


    private void Awake()
    {
        myRenderer = GetComponent<Renderer>();
        offsetY = -0.1f;
    }

    private void Update()
    {
        float speed = offsetY + (offsetY * Time.time);
        //myRenderer.material.mainTextureOffset = new Vector2(0f, offsetY);
        myRenderer.material.SetTextureOffset("_MainTex", new Vector2(0f, speed));
    }

    public void SpeedUp()
    {
        offsetY += -0.6f;
    }
}
