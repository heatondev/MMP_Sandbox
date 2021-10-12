using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPills : MonoBehaviour
{
    [SerializeField]
    GameObject pill;
    Material pillMat;

    public Transform startLocation;
    public float offsetValue;
    float offset;
    

    Color[] colors = { Color.green, Color.red, Color.white, Color.blue, Color.magenta };
    Color newColor;

    int randomColor;
    public int NumberOfPills;

    // Start is called before the first frame update
    void Start()
    {
        //spawnPill(NumberOfPills);
    }

    // Update is called once per frame
   void OnJump()
    {
        spawnPill(NumberOfPills);
    }

    void spawnPill(int numPills)
    {
        for(int i = 0; i < numPills; i++)
        {
            offset += offsetValue;
            randomColor = Random.Range(0, 4);
           
            
            Vector3 spawnLocation = new Vector3(startLocation.position.x+offset, 1, startLocation.position.z);
            Instantiate(pill, spawnLocation, Quaternion.identity);
               
            
                pillMat = pill.GetComponent<Renderer>().sharedMaterial;
                newColor = colors[randomColor];
                pillMat.color = newColor;
                Debug.Log(randomColor);
            
           
        }
    }
}
