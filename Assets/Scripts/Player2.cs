using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float regeneracjaenegii_co_sek=5f;
    public float ruch_strataenegi_na_sek = 2f;
    public float strataenergiiskok_i_double = 3f;
    public float minpredkoscwspolczynnik=0.75f;
    public float minenergiadoskoku=15f;
    public float minenergiadodoubleskoku=40f;
    public float czas_na_double = 0.8f;
    public float czas_miedzy_skokami_ = 0.2f;
    public float speed_base = 5f;
    public float maxjumpvalue = 10.0f;
    public float minjumpvalue = 5.0f;
    private GraczStaty staty;
    private float pozostaly_czas_na_double_jumpa = 0.0f;

    Rigidbody2D rigidbody;
    public Vector2 groundCheckSize;
    public LayerMask groundLayer;
    public Transform groundCheckPoint;
    bool isGrounded;
    void Start()
    {
        staty = GetComponent<GraczStaty>();
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        isGrounded = Physics2D.OverlapBox(groundCheckPoint.position, groundCheckSize, 0f, groundLayer) != null;
    }
    void FixedUpdate()
    {
        staty.Energia += regeneracjaenegii_co_sek * Time.fixedDeltaTime;
        if (isGrounded)
        {
            pozostaly_czas_na_double_jumpa =czas_na_double;
        }
        else if (pozostaly_czas_na_double_jumpa-0.02f > 0)
        {
            
            pozostaly_czas_na_double_jumpa -=0.02f;
        }
        if (Keyboard.current.spaceKey.isPressed && ((isGrounded && staty.Energia >= minenergiadoskoku)|| (pozostaly_czas_na_double_jumpa > 0 && !isGrounded && staty.Energia >= minenergiadodoubleskoku)))
        {
            
            if (!isGrounded && pozostaly_czas_na_double_jumpa < czas_na_double-czas_miedzy_skokami_)
            {
                Debug.Log("dobel");
                pozostaly_czas_na_double_jumpa = 0.0f;
            }
            
            rigidbody.linearVelocity = new Vector2(rigidbody.linearVelocity.x, staty.Energia * (maxjumpvalue - minjumpvalue) / 100 + minjumpvalue);
            if (!isGrounded && pozostaly_czas_na_double_jumpa > 0)
            {
                staty.Energia -= strataenergiiskok_i_double;
            }
        }
        if (Keyboard.current.aKey.isPressed)
        {
            rigidbody.linearVelocity = new Vector2(-speed_base * (staty.Energia * 0.25f / 100 + minpredkoscwspolczynnik), rigidbody.linearVelocity.y);
            staty.Energia -= ruch_strataenegi_na_sek * Time.fixedDeltaTime;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            rigidbody.linearVelocity = new Vector2(speed_base * (staty.Energia * 0.25f / 100 + minpredkoscwspolczynnik), rigidbody.linearVelocity.y);
            staty.Energia -= ruch_strataenegi_na_sek * Time.fixedDeltaTime;
        }
        else
        {
            rigidbody.linearVelocity = new Vector2(0, rigidbody.linearVelocity.y);
        }
    }
}
