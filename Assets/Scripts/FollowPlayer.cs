using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject target;
    public float stop_range = 2f;
    public float minimum_range = 8f;
    public float maximum_range = 10f;
    public float speed = 5f;
    public float attackCooldownTime = 1f;
    public float attack_damage = 5f;
    public float floor_range = 1f;
    float timeOdAttack = 0f;

    enum State {Idle, Chase, Attack};
    State current_state = State.Idle;

    GraczStaty graczStaty;
    public GameObject player;

    private void Start()
    {
        graczStaty = player.GetComponent<GraczStaty>();
    }

    // Update is called once per frame
    private void Update()
    {
        float dist = Mathf.Abs(target.transform.position.x - transform.position.x);
        if (dist < stop_range)
        {
            current_state = State.Attack;
        }
        else
        {
            if (dist < minimum_range)
            {
                current_state = State.Chase;
            }
            else
            {
                if (dist > maximum_range)
                {
                    current_state = State.Idle;
                }
            }
        }

        RaycastHit2D down_raycast = Physics2D.Raycast(transform.position, Vector2.down, 5f, 3);
        float floor_distance = down_raycast.distance;
        // dodac by przeciwnik byl na stalym poziomie
    }

    void FixedUpdate()
    {
        timeOdAttack += Time.deltaTime;
        if ( current_state == State.Chase)
        {
            Vector3 target_pos = new Vector2(target.transform.position.x, 0);
            Vector3 new_self_pos = new Vector2(transform.position.x, 0);
            Vector3 move = (target_pos - new_self_pos).normalized;
            transform.position += move * Time.deltaTime * speed;
        }
        if (current_state == State.Attack && timeOdAttack > attackCooldownTime)
        {
            timeOdAttack = 0;
            graczStaty.Stres += attack_damage;

        }
    }
}
