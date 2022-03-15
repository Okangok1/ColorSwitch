using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text scoreText;
    [SerializeField] private int score = 0;
    [SerializeField] private GameObject circleGam;
    [SerializeField] private GameObject colorGam;
    [SerializeField] private GameObject finishLineGam;
    [SerializeField] private Transform player;
    [SerializeField] private float circleDistance = 2f;
    [SerializeField] private float colorDistance = 1f;
    [SerializeField] private int maxObstacle = 5;
    [SerializeField] private int obstacleNumbers = 0;
    [SerializeField] private float minRandomSpeed = 50f;
    [SerializeField] private float maxRandomSpeed = 200f;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("HighestScore") == 0)
        {
            PlayerPrefs.SetInt("HighestScore", score);
        }
        if (PlayerPrefs.GetInt("RegisteredLevel") == 0)
        {
            PlayerPrefs.SetInt("RegisteredLevel", SceneManager.GetActiveScene().buildIndex);
        }
        score = PlayerPrefs.GetInt("Score");
        scoreText.text = score.ToString();
        Debug.Log("Kayıtlı score :" + PlayerPrefs.GetInt("Score"));


    }

    // Update is called once per frame
    void Update()
    {
    }
    public void GameWon()
    {

        if (SceneManager.GetActiveScene().buildIndex > PlayerPrefs.GetInt("RegisteredLevel"))
        {
            PlayerPrefs.SetInt("RegisteredLevel", SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Kod çalıstı");
        }
        Debug.Log("Kod çalıstı");
        PlayerPrefs.SetInt("Score", score);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void IncreaseScore(int _score = 1)
    {
        score += _score;
        scoreText.text = score.ToString();

    }
    public void GameOver()
    {

        if (score > PlayerPrefs.GetInt("HighestScore"))
        {
            PlayerPrefs.SetInt("HighestScore", score);
        }
        PlayerPrefs.SetInt("Score", 0);
        Debug.Log("En yüksek Skor :" + PlayerPrefs.GetInt("HighestScore"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void GetObstacles()
    {

        float circleYAxis = 0;
        float colorChangerYAxis = 0;
        for (int i = 0; i <= maxObstacle; i++)
        {
            int randomSpeed = Random.Range(50, 200);
            int randomMark = Random.Range(0, 2);
            int tradeMark = 0;
            switch (randomMark)
            {
                case 0:
                    tradeMark = -1;
                    break;
                case 1:
                    tradeMark = 1;
                    break;
                default:
                    break;
            }
            if (obstacleNumbers < maxObstacle)
            {
                GameObject circle = Instantiate(circleGam, new Vector3(transform.position.x, circleYAxis, transform.position.z), transform.rotation);
                CircleController circleController = circle.GetComponent<CircleController>();
                circleController.rotationSpeed = tradeMark * randomSpeed;
                circleYAxis += circleDistance;
                if (obstacleNumbers < maxObstacle - 1)
                {
                    colorChangerYAxis = circleYAxis - colorDistance;
                    Instantiate(colorGam, new Vector3(transform.position.z, colorChangerYAxis, transform.position.z), transform.rotation);
                }
            }

            if (obstacleNumbers == maxObstacle)
            {
                Instantiate(finishLineGam, new Vector3(transform.position.x, circleYAxis + 5f, transform.position.z), transform.rotation);
            }
            obstacleNumbers++;

        }
    }
}
