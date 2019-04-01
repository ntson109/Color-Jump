using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public bool isJumping;
    public Transform posTop;
    public ColorNode color;
    public int value;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        speed = 5f;
        isJumping = false;
        this.rb.gravityScale = 0;
        this.value = 1;
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.state == StateGame.PLAYING)
        {
            if (isJumping)
            {
                if (this.transform.position.y < posTop.position.y)
                {
                    rb.velocity = Vector2.up * speed;
                }
                else
                {
                    this.rb.gravityScale = 0.65f;
                    isJumping = false;
                }
            }
        }
    }

    void Jump()
    {
        if (!isJumping)
        {
            isJumping = true;
            this.rb.gravityScale = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Node")
        {
            //Jump();
            //if (this.color == other.GetComponent<Node>().color)
            //{
            //    Jump();
            //}
            //else
            //{
            //    Debug.Log("Game Over !");
            //}
            if (this.value == other.GetComponent<Node>().value)
            {
                Jump();
            }
            else
            {
                Debug.Log("game over !");
                GameManager.Instance.GameOver();
            }
        }
    }

    public void OnChangeColor()
    {
        if (value == 1)
        {
            this.color = ColorNode.WHITE;
        }
        else if (value == 2)
        {
            this.color = ColorNode.RED;
        }
        else if (value == 3)
        {
            this.color = ColorNode.YELLOW;
        }
        else if (value == 4)
        {
            this.color = ColorNode.GREEN;
        }
        else if (value == 5)
        {
            this.color = ColorNode.CYAN;
        }
        //else if (value == 6)
        //{
        //    this.color = ColorNode.PINK;
        //}
        //else if (value == 7)
        //{
        //    this.color = ColorNode.BLACK;
        //}
    }
}
