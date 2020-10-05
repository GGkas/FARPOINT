using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Range(0.0f, 8.0f)][SerializeField] private float _speed = 3.0f;
    private Dictionary<Item, int> playerInventory;

    public int maxHealth { get; set; }
    public int maxStamina { get; set; }
    public Rigidbody2D rb2D { get; set; }
    public Animator animator { get; set; }
    public Vector2 PlayerDirection { get; set; }
    public Dictionary<Item, int> PlayerInventory => playerInventory;
    [SerializeField] private int curHealth;
    [SerializeField] private int curStamina;
    private bool noMove = false;

    // All these probably need to be put inside a SO (apart from the Dictionary)
    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        playerInventory = new Dictionary<Item, int>();
        maxHealth = 100;
        maxStamina = 100;
        curHealth = maxHealth;
        curStamina = maxStamina;
        animator = GetComponent<Animator>();
    }

    public void Move()
    {
        if (noMove)
        {
            curStamina += 2;
            if (curStamina >= 100) { noMove = false; }
            UIStaminaBar.instance.setValue(Mathf.Clamp(curStamina, 0.0f, 100.0f) / (float)maxStamina);
            return;
        }
        Vector2 currentPos = rb2D.position;

        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        Vector2 inputVector = new Vector2(moveH, moveV);
        // Gives normalized vector -> direction basically
        PlayerDirection = Vector2.ClampMagnitude(inputVector, 1);
        animator.SetFloat("Look X", PlayerDirection.x);
        animator.SetFloat("Look Y", PlayerDirection.y);
        // Velocity vector with speed multiplier
        Vector2 movement = PlayerDirection * _speed;
        animator.SetFloat("Speed", movement.magnitude);
        animator.SetFloat("Move X", movement.x);
        animator.SetFloat("Move Y", movement.y);
        rb2D.MovePosition(currentPos + movement * Time.fixedDeltaTime);  // Since we will only move in FixedUpdate
        curStamina -= Mathf.FloorToInt(movement.magnitude * 0.4f);
        if (curStamina == 0.0f)
        {
            noMove = true;
        }

        UIStaminaBar.instance.setValue(curStamina / (float)maxStamina);
    }

    public void AddToInventory(Item newItem)
    {
        if (playerInventory.Count > 0)
        {
            if (playerInventory.ContainsKey(newItem) && playerInventory[newItem] < newItem.maxCountInInventory)
            {
                playerInventory[newItem] += 1;
                return;
            }
            playerInventory.Add(newItem, 1);    // Still need to add new item if there are already
            InventoryUI.instance.SetImage(newItem.itemIcon);
            return;
        }
        playerInventory.Add(newItem, 1);
        InventoryUI.instance.SetImage(newItem.itemIcon);
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
            curHealth += amount;
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
