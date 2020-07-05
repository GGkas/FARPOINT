using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private PlayerController controller;
    private bool canPickUpItem;
    private bool addedToInv;
    private GameObject itemObjRef;
    void Start()
    {
        controller = GetComponent<PlayerController>();
        canPickUpItem = false;  // At start you can't pick up anything, duh
        addedToInv = false;
        InvokeRepeating("ShowInventory", 2.0f, 1.0f);
    }
    private void Update()
    {
        if (canPickUpItem)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                controller.AddToInventory(itemObjRef.GetComponent<ItemCollectible>().itemRef);
                addedToInv = true;
            }
        }   
    }

    public void ShowInventory()
    {
        foreach (var pair in controller.PlayerInventory)
        {
            Debug.Log("##### Item Name: " + pair.Key.itemName + ", Description: " + pair.Key.description + "#####");
            Debug.Log("Item Count: " + pair.Value);
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null)
        {
            itemObjRef = collision.gameObject;
            canPickUpItem = true;
            if (addedToInv)
            {
                Destroy(itemObjRef);
                canPickUpItem = false;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.GetComponent<ItemCollectible>() != null)
            { // means there was an item there
                canPickUpItem = false;
                addedToInv = false;
            }
        }
    }
}
