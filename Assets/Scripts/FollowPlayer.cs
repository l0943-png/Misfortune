using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject target;
    public float stop_range = 2f;
    public float minimum_range = 8f;
    public float maximum_range = 10f;
    public float speed = 5f;
    public float attackCooldownTime = 1f;
    float timeOdAttack = 0f;

    enum State {Idle, Chase, Attack};
    State current_state = State.Idle;

    // Update is called once per frame
    private void Update()
    {
        float dist = Mathf.Abs(target.transform.position.x - transform.position.x);
        //Debug.Log(dist);
        //Debug.Log(current_state);
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
    }

    void FixedUpdate()
    {
        if ( current_state == State.Chase)
        {
            //Vector3 target_pos = new Vector2(target.transform.position.x, 0);
            //Vector3 new_self_pos = new Vector2(transform.position.x, 0);
            //Vector3 move = (target_pos - new_self_pos).normalized;
           // transform.position += move * Time.deltaTime * speed;
        }
        if (current_state == State.Attack)
        {
            //Debug.Log("atakuje!");

        }
    }
}
