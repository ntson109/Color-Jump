using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EventDispatcher;

public class Node : MonoBehaviour
{
    public float speed;
    public int value;
    public ColorNode color;
    public RectTransform rect;
    public Text txtValue;
    void Start()
    {
        rect = GetComponent<RectTransform>();
        SetInfo();
        this.speed = 2f;
        this.RegisterListener(EventID.NEXT, (param) => ON_NEXT());
    }

    void FixedUpdate()
    {
        //if (GameManager.Instance.state == StateGame.PLAYING)
        //{

        //    Move();
        //    if (this.rect.transform.localPosition.x <= -440)
        //    {
        //        this.rect.transform.localPosition = GameManager.Instance.nodeLast.rect.transform.localPosition + new Vector3(152f, 0f, 0f);
        //        GameManager.Instance.nodeLast = this;
        //        //Time.timeScale = 0;
        //        //this.transform.SetAsLastSibling();
        //        //this.rect.transform.localPosition = GameManager.Instance.posSpawn;
        //        SetInfo();
        //    }
        //}

        if (this.name == "Node 1")
        {
            //Debug.Log(this.rect.transform.position);
        }
    }

    void ON_NEXT()
    {
        
        if (this.rect.transform.position.x <= -3.5f)
        {
            //Debug.Log(GameManager.Instance.nodeLast.rect.transform.position);
            this.rect.transform.position = GameManager.Instance.nodeLast.rect.transform.position + new Vector3(1.2f, 0f, 0f);
            GameManager.Instance.nodeLast = this;
            //Time.timeScale = 0;
            //this.transform.SetAsLastSibling();
            //this.rect.transform.localPosition = GameManager.Instance.posSpawn;
            SetInfo();
        }
    }

    void SetInfo()
    {
        //this.value = Random.Range(1, 5);
        txtValue.text = this.value.ToString();
        RandomColor();
        
    }

    void RandomColor()
    {
        int temp = Random.Range(1, 6);
        this.value = temp;
        txtValue.text = this.value.ToString();
        switch (temp)
        {
            case 1:
                this.color = ColorNode.WHITE;
                this.GetComponent<Image>().color = Color.white;
                break;
            case 2:
                this.color = ColorNode.RED;
                this.GetComponent<Image>().color = Color.red;
                break;
            case 3:
                this.color = ColorNode.YELLOW;
                this.GetComponent<Image>().color = Color.yellow;
                break;
            case 4:
                this.color = ColorNode.GREEN;
                this.GetComponent<Image>().color = Color.green;
                break;
            case 5:
                this.color = ColorNode.CYAN;
                this.GetComponent<Image>().color = Color.cyan;
                break;
            //case 6:
            //    this.color = ColorNode.PINK;
            //    this.GetComponent<Image>().color = Color.magenta;
            //    break;
            //case 7:
            //    this.color = ColorNode.BLACK;
            //    this.GetComponent<Image>().color = Color.black;
            //    break;
        }
    }

    void Move()
    {
        this.rect.transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    //void OnBecameInvisible()
    //{
    //    this.GetComponent<RectTransform>().transform.position = GameManager.Instance.posSpawn;
    //}
}

public enum ColorNode
{
    WHITE,
    BLACK,
    RED,
    YELLOW,
    GREEN,
    CYAN,
    PINK
}
