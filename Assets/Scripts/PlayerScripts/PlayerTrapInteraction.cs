using UnityEngine;

public class PlayerTrapInteraction : MonoBehaviour
{
    public PlayerController controller;
    private bool canInteractWithTrap = false;

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, controller.PlayerDirection, 100f, LayerMask.GetMask("Damageable"));

        if (hit.collider != null)
        {
            Debug.Log("Can see trap! What will you do?");
            canInteractWithTrap = true;
            if (Input.GetKeyDown(KeyCode.C))
            {
                // For now just simply check if Inventory is not empty and 
                // then remove an item and disable TrapController script basically.
                controller.TrapInteract(hit.collider.gameObject.GetComponent<TrapController>());
            }
        }
        else
        {
            canInteractWithTrap = false;
        }
    }
}
