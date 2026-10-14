using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float gravity = -5f;
    public float speed = 5f;
    public float jumpPower = 10f;

    Rigidbody2D rigidbody;
    bool isGrounded;
    public Transform groundCheck;
    public Vector2 groundCheckSize;

    float verticalVelocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapBox(groundCheck.position, groundCheckSize, 45f, 7);

        float gravity = -1f;

        Debug.Log(isGrounded);
        if (isGrounded == false)
        {
            gravity = -5f;
        }

        if (Keyboard.current.spaceKey.isPressed)
        {
            gravity = 100f;
        }

        rigidbody.linearVelocityY = gravity;
    }

    void FixedUpdate()
    {

        Vector2 movement = Vector2.zero;
        if (Keyboard.current.dKey.isPressed) movement.x++;
        if (Keyboard.current.aKey.isPressed) movement.x--;
        rigidbody.linearVelocityX = movement.x;
    }
}
