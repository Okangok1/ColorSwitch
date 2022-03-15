using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnaMenu : MonoBehaviour
{
    [SerializeField] private Text highestScoreText;

    // Start is called before the first frame update
    void Start()
    {
       // PlayerPrefs.SetInt("HighestScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        highestScoreText.text = "EN YÜKSEK SKOR :" + PlayerPrefs.GetInt("HighestScore");
    }
    public void LevelStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ContiuneLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("RegisteredLevel"));
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void MainScene()
    {
        SceneManager.LoadScene(0);
    }
}
