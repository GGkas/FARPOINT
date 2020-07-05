using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0.0f, 8.0f)][SerializeField] private float _speed = 3.0f;
    private Dictionary<Item, int> playerInventory;

    public int maxHealth { get; set; }
    public Rigidbody2D rb2D { get; set; }
    public Vector2 PlayerDirection { get; set; }
    public Dictionary<Item, int> PlayerInventory => playerInventory;
    [SerializeField] private int curHealth;

    // All these probably need to be put inside a SO (apart from the Dictionary)
    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        playerInventory = new Dictionary<Item, int>();
        maxHealth = 10;
        curHealth = maxHealth;
    }

    public void Move()
    {
        Vector2 currentPos = rb2D.position;

        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        Vector2 inputVector = new Vector2(moveH, moveV);
        // Gives normalized vector -> direction basically
        PlayerDirection = Vector2.ClampMagnitude(inputVector, 1);
        // Velocity vector with speed multiplier
        Vector2 movement = PlayerDirection * _speed;
        rb2D.MovePosition(currentPos + movement * Time.fixedDeltaTime);  // Since we will only move in FixedUpdate
    }

    // TODO: SOMETHING WRONG IN LOGIC. FIND IT AND FIX IT. VERY CLOSE TO FINISNI
    public void AddToInventory(Item newItem)
    {
        if (playerInventory.Count > 0)
        {
            if (playerInventory.ContainsKey(newItem) && playerInventory[newItem] < newItem.maxCountInInventory)
            {
                playerInventory[newItem] += 1;
                return;
            }
        }
        playerInventory.Add(newItem, 1);
    }
    public void RemoveFromInventory(Item removableItem)
    {
        if (playerInventory.Count > 0)  // While we have Items
        {
            if (playerInventory.ContainsKey(removableItem) && playerInventory[removableItem] > 1)
            {
                playerInventory[removableItem] -= 1;
                return;
            }
        }
        playerInventory.Remove(removableItem);
    }

    public void ChangeHealth(int amount)
    {
        if (curHealth > 0)
            curHealth -= 1;
    }

    public void TrapInteract(TrapController contr)
    {
        if (playerInventory.Count > 0)
        {
            // here it would be very helpful if I had made an enum out of the possible items,
            // and used that as a key instead of the Item itself.
            Debug.Log("Trap disabled!");
            contr.isDisabled = true;
        }
    }
}
