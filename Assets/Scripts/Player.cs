using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
public class Player : MonoBehaviour
{
    public float speed_base = 5f;
    public float maxjumpvalue = 10.0f;
    public float minjumpvalue = 5.0f;
    public float regeneracjaenegii_co_sek=5f;
    public float ruch_strataenegi_na_sek = 2f;
    public float strataenergiiskok_i_double = 3f;
    public float minpredkoscwspolczynnik=0.75f;
    public float minenergiadoskoku=15f;
    public float minenergiadodoubleskoku=40f;
    public float czas_na_double = 0.8f;
    private float pozostaly_czas_na_double_jumpa = 0.0f;

    Rigidbody2D rigidbody;
    public Vector2 groundCheckSize;
    public LayerMask groundLayer;
    public Transform groundCheckPoint;
    bool isGrounded;

    public LayerMask enemyLayer;
    public Transform meeleAttackPoint;
    public float attackRadius = 2f;
    public float attackCooldownTime = 1f;
    float timeOdAttack = 0f;
    private GraczStaty staty;

    void Start()
    {
        staty = GetComponent<GraczStaty>();
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.freezeRotation = true;
    }
    void Update()
    {
        isGrounded = Physics2D.OverlapBox(groundCheckPoint.position, groundCheckSize, 0f, groundLayer) != null;

        if (Mouse.current.leftButton.isPressed && timeOdAttack > attackCooldownTime)
        {
            timeOdAttack = 0;
            Collider2D meeleCheck = Physics2D.OverlapCircle(meeleAttackPoint.position, attackRadius, enemyLayer);
            if (meeleCheck != null)
            {
                //Debug.Log("trafiony!");
                // dodac funkcjonalnosc ze przeciwnikowi health pada
            }
        }


































        staty.Energia = Mathf.Min(staty.Energia + regeneracjaenegii_co_sek * Time.deltaTime, 100);










        if (isGrounded)
        {
            pozostaly_czas_na_double_jumpa = czas_na_double;
        }
        else if (pozostaly_czas_na_double_jumpa - 0.02f > 0)
        {

            pozostaly_czas_na_double_jumpa -= 0.02f;
        }







        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Próba skoku" + isGrounded + pozostaly_czas_na_double_jumpa);
            if ((isGrounded && staty.Energia >= minenergiadoskoku) || (pozostaly_czas_na_double_jumpa > 0 && !isGrounded && staty.Energia >= minenergiadodoubleskoku))
            {
                if (!isGrounded)
                {
                    Debug.Log("dobel");
                    pozostaly_czas_na_double_jumpa = 0.0f;
                    staty.Energia -= strataenergiiskok_i_double;
                }

                rigidbody.linearVelocity = new Vector2(rigidbody.linearVelocity.x, staty.Energia * (maxjumpvalue - minjumpvalue) / 100 + minjumpvalue);
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
    void FixedUpdate()
    {
        timeOdAttack += Time.deltaTime;


        



        




        


        






        if (rigidbody.linearVelocity.x > 0)
        {
            meeleAttackPoint.localPosition = new Vector2(Mathf.Abs(meeleAttackPoint.localPosition.x), meeleAttackPoint.localPosition.y);
        }
        if (rigidbody.linearVelocity.x < 0)
        {
            meeleAttackPoint.localPosition = new Vector2(-Mathf.Abs(meeleAttackPoint.localPosition.x), meeleAttackPoint.localPosition.y);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (groundCheckPoint != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(meeleAttackPoint.position, groundCheckSize);
        }
    }
}
