using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeObject : MonoBehaviour
{
    //public GameObject object1;
    //public GameObject object2;

    [Range(0,1)]
    public float alphaFade;
    public int setAlpha;

    Renderer rend;

    public GameObject[] objects;

    // Start is called before the first frame update
    void Start()
    {


        Shader shader = Shader.Find("Fader");
        

        Debug.Log(shader);
       

    }

    // Update is called once per frame
    void Update()
    {
        rend = objects[setAlpha].GetComponent<Renderer>();
        rend.sharedMaterial.SetFloat("_MaterialAlpha", alphaFade);
    }

    
}
