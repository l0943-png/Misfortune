using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed_base = 5f;
    public float jumpPower = 10f;

    Rigidbody2D rigidbody;
    public Vector2 groundCheckSize;
    public LayerMask groundLayer;
    public Transform groundCheckPoint;
    float verticalVelocity;
    bool isGrounded;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        isGrounded = Physics2D.OverlapBox(groundCheckPoint.position, groundCheckSize, 0f, groundLayer) != null;
    }
    void FixedUpdate()
    {
        
        if (Keyboard.current.spaceKey.isPressed && isGrounded)
        {
            Debug.Log("Jump");
            rigidbody.linearVelocity = new Vector2(rigidbody.linearVelocity.x, jumpPower);
        }
        if (Keyboard.current.aKey.isPressed)
        {
            rigidbody.linearVelocity = new Vector2(-speed_base, rigidbody.linearVelocity.y);
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            rigidbody.linearVelocity = new Vector2(speed_base, rigidbody.linearVelocity.y);
        }
        else
        {
            rigidbody.linearVelocity = new Vector2(0, rigidbody.linearVelocity.y);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (groundCheckPoint != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(groundCheckPoint.position, groundCheckSize);
        }
    }
}
