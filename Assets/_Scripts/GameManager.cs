using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = new GameManager();
    void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        Instance = this;
    }

    public StateGame state;
    public Ball ball;
    public List<Node> lsNode = new List<Node>();
    public Node nodeLast;
    public Text txtValueBall;
    public GameObject panelGameOver;

    void Start()
    {
        nodeLast = lsNode[lsNode.Count - 1];
    }

    void Update()
    {
        if (state == StateGame.PLAYING)
        {
            txtValueBall.text = ball.value.ToString();
        }
    }

    public void OnClick()
    {
        if (ball.value < 5)
        {
            ball.value++;
        }
        else
        {
            ball.value = 1;
        }
        ball.OnChangeColor();
    }

    public void GameOver()
    {
        panelGameOver.SetActive(true);
        Time.timeScale = 0;
    }
}

public enum StateGame
{
    NONE,
    PLAYING
}
