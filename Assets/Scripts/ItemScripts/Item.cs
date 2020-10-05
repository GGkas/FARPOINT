using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public string itemName;     // Item name, could also be an int ID
    public string description;  // Item description

    public bool isIndestructible;
    public bool isUnique;       // If there's only 1 in game
    public bool isStackable;    // If you can have > 1 of said item in inventory
    public bool isQuestItem;    // If it is a Quest item, specify it

    public int maxCountInInventory; // Maximum number of items like this you can hold in inventory

    public Sprite itemIcon;  // How the item looks in menu
}
