using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text PointText;
    void Start()
    {
        Debug.Log("Points = " + SettingClass.Points);
        PointText.text = SettingClass.Points.ToString();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
