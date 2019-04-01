using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventDispatcher;

public class MoveController : MonoBehaviour
{
    public RectTransform rect;
    public float speed;
    Vector3 currentPos;
    // Use this for initialization
    void Start()
    {
        rect = GetComponent<RectTransform>();
        this.speed = 1f;
        currentPos = this.rect.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.Instance.state == StateGame.PLAYING)
        {
            
            //Debug.Log(Vector3.Distance(this.rect.transform.position, currentPos));
            if (Vector3.Distance(this.rect.transform.position, currentPos) >= 1.65f)
            {
                this.PostEvent(EventID.NEXT);
                currentPos = this.rect.transform.position;
            }
            Move();
        }
    }

    void Move()
    {
        this.rect.transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
