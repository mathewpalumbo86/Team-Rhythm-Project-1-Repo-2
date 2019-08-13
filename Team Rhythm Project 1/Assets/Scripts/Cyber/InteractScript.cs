using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{

    public bool aCCtive = false;

    public float timeDone;

    public GameObject safe;

    public Material s_Material;

    Material m_Material;


    public Shader Shader;

    // Start is called before the first frame update
    void Start()
    {
        //s_Material.shader.ToString();
        //s_Material.shaderKeywords.ToString();
        s_Material = GetComponent<Renderer>().material;
        print("Materials" + Resources.FindObjectsOfTypeAll(typeof(Material)).Length);


        //Shader.
       //_Material.shaderKeywords

        
    }

    // Update is called once per frame
    void Update()
    {






        
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Safe")
        {


            //safe.activeSelf
        }
    }

}
