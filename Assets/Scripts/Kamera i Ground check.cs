using UnityEngine;

public class KameraiGroundcheck : MonoBehaviour
{
    public Transform gracz;
    public float groundcheckoffset = 0.6f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.name == "Main Camera")
        {
            transform.position = new Vector3(gracz.position.x, gracz.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(gracz.position.x, gracz.position.y - groundcheckoffset, transform.position.z);
        }
    }
}
