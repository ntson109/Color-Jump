using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject panelStart;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Btn_Play()
    {
        panelStart.SetActive(false);
        GameManager.Instance.state = StateGame.PLAYING;
        GameManager.Instance.ball.rb.gravityScale = 0.5f;
    }

    public void Btn_Replay()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
        Time.timeScale = 1;
    }
}
