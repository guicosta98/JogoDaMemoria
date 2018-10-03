using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {

    public GameObject canvas;
    public GameObject triesText;

    public void OnGameOver()
    {
        canvas.SetActive(true);
        triesText.SetActive(false);
    }

    public void OnBtnPlay()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnBtnQuit()
    {
        Application.Quit();
    }
}
