using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamesManager : MonoBehaviour
{
    public static GamesManager Instance;
    public static int health;
    public static int score;
    [SerializeField] Text scoreText;
    //public GameObject ball1, ball2, ball3;
    public GameObject gameover,wingame;
    public GameObject[] balls;
    //[SerializeField] Transform spawnPoint;

    public GameState State;

    void Awake()
    {
        Instance = this;

        //ButtonArrow btn;
        //btn.eventMouseDown.AddListener()
    }

    private void Start()
    {
        UpdateGameState(GameState.GameMenu);
        health = 3;
        score = 0;
        balls[0].gameObject.SetActive(true);
        for (int i = 0; i < health; i++)
            balls[i].gameObject.SetActive(true);
        //ball2.gameObject.SetActive(true);
        //ball3.gameObject.SetActive(true);
        gameover.gameObject.SetActive(false);
        wingame.gameObject.SetActive(false);
    }

    private void Update()
    {
        scoreText.text = "Score: " + score.ToString();
        if (health > 3) 
            health = 3;
        switch (health)
        {
            case 3:
                //ball1.gameObject.SetActive(true);
                //ball2.gameObject.SetActive(true);
                //ball3.gameObject.SetActive(true);
                break;
            case 2:
                //ball1.gameObject.SetActive(true);
                //ball2.gameObject.SetActive(true);
                //ball3.gameObject.SetActive(false);
                Destroy(balls[health].gameObject);
                break;
            case 1:
                //ball1.gameObject.SetActive(true);
                //ball2.gameObject.SetActive(false);
                //ball3.gameObject.SetActive(false);
                Destroy(balls[health].gameObject);
                break;
            case 0:
                //ball1.gameObject.SetActive(false);
                //ball2.gameObject.SetActive(false);
                //ball3.gameObject.SetActive(false);
                Destroy(balls[health].gameObject);
                gameover.gameObject.SetActive(true);
                UpdateGameState(GameState.Lose);
                break;
        }

    }
    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.GameMenu:
                break;
            case GameState.GameStart:
                break;
            case GameState.GamePause:
                break;
            case GameState.Victory:
                break;
            case GameState.Lose:
                break;
            default:
                break;
        }
    }

    public enum GameState
{
    GameMenu,
    GameStart,
    GamePause,
    Victory,
    Lose
}
}