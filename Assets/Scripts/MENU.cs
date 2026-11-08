using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Example : MonoBehaviour
{
    //Make sure to attach these Buttons in the Inspector
    public Button GRAJ_button,USTAWIENIA_Button,WYJDZ_Button;

    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        GRAJ_button.onClick.AddListener(TaskOnClick);
        USTAWIENIA_Button.onClick.AddListener(TaskustwOnClick);
        WYJDZ_Button.onClick.AddListener(Taskaltf4OnClick);
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("Poziom1");
    }
    void TaskustwOnClick()
    {
        SceneManager.LoadScene("Ustawienia");
    }
    void Taskaltf4OnClick()
    {
        Debug.Log("ALTf4");
        EditorApplication.ExitPlaymode();
        Application.Quit();
    }
}