using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject target;
    public float minimum_range = 5f;
    public float maximum_range = 10f;

    enum State {Idle, Chase};
    State current_state = State.Idle;

    // Update is called once per frame
    private void Update()
    {
        float dist = (target.transform.position - transform.position).magnitude;
        Debug.Log(dist);
        Debug.Log(current_state);
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

    void FixedUpdate()
    {
        if ( current_state == State.Chase)
        {
            Vector3 target_pos = new Vector2(target.transform.position.x, 0);
            Vector3 new_self_pos = new Vector2(transform.position.x, 0);
            Vector3 move = (target_pos - new_self_pos).normalized;
            transform.position += move * Time.deltaTime;
        }
    }
}
