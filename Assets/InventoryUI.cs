using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public List<Image> inventory_images = new List<Image>();
    public static InventoryUI instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        foreach (Transform child in GetComponentsInChildren<Transform>())
        {
            inventory_images.Add(child.gameObject.GetComponent<Image>());
        }

        inventory_images.Remove(inventory_images[0]);
    }

    public void SetImage(Sprite _sprite)
    {
        for (int i = 0; i < inventory_images.Count; i++)
        {
            if (inventory_images[i].sprite == null)
            {
                inventory_images[i].sprite = _sprite;
                break;
            }
        }
        
    }
}
