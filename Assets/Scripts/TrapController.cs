using UnityEngine;

public class TrapController : MonoBehaviour
{
    public bool isDisabled { get; set; }

    private void Awake()
    {
        isDisabled = false; //Initially trap acts like a trap, damaging the player
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDisabled) { return; } // If trap is disabled, don't do anything
        if (collision != null)
        {
            PlayerController controller = collision.GetComponent<PlayerController>();
            if (controller != null)
            {
                controller.ChangeHealth(-1);
            }
        }
    }
}
