using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PrzeciwnikStaty : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)]
    public float Zycie;
    public GameObject fillZycie;
    public GameObject bgZycie;

    // Update is called once per frame
    void Update()
    {
        //energiatekst.SetText(Mathf.Floor(Energia) + "/100");
        //fillenergia.fillAmount = Energia / 100;
        //fillstres.fillAmount = Stres / 100;
        Debug.Log(Zycie / 100f);
        fillZycie.transform.localScale = new Vector3(Zycie / 100f * bgZycie.transform.localScale.x, fillZycie.transform.localScale.y, 0f);
    }

    public void Damage(float damage)
    {
        Zycie -= damage;
        if (Zycie < 0f)
        {
            Zycie = 0f;
            Destroy(gameObject);
        }
    }
}