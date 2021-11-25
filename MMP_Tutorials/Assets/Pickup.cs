using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Inventory _inventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _inventory.CanvasOn();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _inventory.CanvasOff();
    }
}
