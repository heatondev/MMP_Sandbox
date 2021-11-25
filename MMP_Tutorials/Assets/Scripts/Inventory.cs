using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CanvasOn()
    {
        
            if (!menu.activeSelf)
            {
                menu.SetActive(true);
            }
    
    }

    public void CanvasOff()
    {
        if (menu.activeSelf)
        {
            menu.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.I))
        //{
        //    if (!menu.activeSelf)
        //    {
        //        menu.SetActive(true);
        //    }
        //    else menu.SetActive(false);
        //}
    }
}
