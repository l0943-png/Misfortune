using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GraczStaty : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)]
    public float Energia;
    [SerializeField, Range(0f, 100f)]
    public float Stres;
    public TMP_Text energiatekst;
    public Image fill;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

// Update is called once per frame
void Update()
    {
        energiatekst.SetText(Mathf.Floor(Energia)+ "/100");
        fill.fillAmount = Energia / 100;
    }
}
