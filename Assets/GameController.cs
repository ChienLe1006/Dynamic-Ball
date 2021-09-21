using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : Singleton<GameController>
{
    public float speed;
    private float time = 0;
    private float timeLimit = 10;
    private int point = 0;
    private bool isEndGame = false;
    [SerializeField] private Text gamePoint;
    [SerializeField] private GameObject endPanel;
    [SerializeField] private Text endPoint;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEndGame)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                StartGame();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                Time.timeScale = 1;
            }
        }
        
        time += Time.deltaTime;
        if (time >= timeLimit)
        {
            speed += 0.5f;
            time = 0;
        }
    }

    public void GetPoint()
    {
        point++;
        gamePoint.text = point.ToString();
    }

    public void EndGame()
    {
        isEndGame = true;
        Time.timeScale = 0;
        endPanel.SetActive(true);
        endPoint.text = "Your Point \n" + point.ToString();
    }
    public void Restart()
    {
        StartGame();
    }
    void StartGame()
    {
        SceneManager.LoadScene(0);        
    }
}
