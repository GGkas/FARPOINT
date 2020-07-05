using UnityEngine;

public class PlayerMovement_WASD : MonoBehaviour
{
    [SerializeField] private PlayerController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        controller.Move();
    }
}
