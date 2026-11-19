using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PrzeciwnikStaty : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)]
    public float Zycie;
    public Sprite fillstres;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //energiatekst.SetText(Mathf.Floor(Energia) + "/100");
        //fillenergia.fillAmount = Energia / 100;
        //fillstres.fillAmount = Stres / 100;
    }
}