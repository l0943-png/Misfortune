using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Example : MonoBehaviour
{
    //Make sure to attach these Buttons in the Inspector
    public Button GRAJ_button,CREDTIS_button;
    public GameObject creditsysyy;

    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        GRAJ_button.onClick.AddListener(TaskOnClick);
        CREDTIS_button.onClick.AddListener(TaskcreditsOnClick);
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("SampleScene");
    }
    void TaskcreditsOnClick()
    {
    }
}