using UnityEngine;

//Player movement script
public class PlayerMovement : MonoBehaviour
{
    private Vector2 _mousePos2D;
    private Vector2 _relativePosition;
    private Vector2 movement;
    [SerializeField] private Camera cam;
    // Might need to change Vector2, will see how it moves
    [Range(0.0f, 5.0f)][SerializeField] private float speed = 3.0f;

    public Rigidbody2D rb2D { get; set; }
    public Vector2 mousePos2D
    {
        get { return _mousePos2D; }
        set
        {
            _mousePos2D.x = value.x;
            _mousePos2D.y = value.y;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))    // If right-click press
        {
            mousePos2D = cam.ScreenToWorldPoint(Input.mousePosition);   // This gets only x,y components of click
        }
        // TODO: if we add other objects, we need to use raycasting to detect them and avoid them (or something)
        _relativePosition = new Vector2(mousePos2D.x - transform.position.x, mousePos2D.y - transform.position.y);

        // Another approach: since we have end position, and start position, we can use Lerp to change position
    }
    private void FixedUpdate()
    {
        // Gives same movement as APPROACH_MOV, but set built-in velocity of Rigidbody to a value
        #region CLUNK_MOV
        //movement.x = (speed * Time.deltaTime >= Mathf.Abs(_relativePosition.x)) ? _relativePosition.x : speed * Mathf.Sign(_relativePosition.x);
        //movement.y = (speed * Time.deltaTime >= Mathf.Abs(_relativePosition.y)) ? _relativePosition.y : speed * Mathf.Sign(_relativePosition.y);
        //rb2D.velocity = movement;
        #endregion

        // Gives really sharp movement
        #region SHARP_MOV
        //movement.x = speed * _relativePosition.x;
        //movement.y = speed * _relativePosition.y;

        //rb2D.velocity = movement;
        #endregion

        // Gives equal movement across, but uses MovePosition to update
        #region APPROACH_MOV
        movement.x = Approach(mousePos2D.x, transform.position.x, Time.fixedDeltaTime * speed);
        movement.y = Approach(mousePos2D.y, transform.position.y, Time.fixedDeltaTime * speed);
        rb2D.MovePosition(movement);
        #endregion
    }

    private float Approach(float endPoint_coord, float startPoint_coord, float dt)
    {
        float difference = endPoint_coord - startPoint_coord;
        if (difference > dt)
        {
            return startPoint_coord + dt;
        }
        if (difference < -dt)
        {
            return startPoint_coord - dt;
        }
        return endPoint_coord;
    }
}
