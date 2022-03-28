using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _body;
    public float speed = 5f;
    public float jumpVelocity = 5f;
    private bool isjumping = false;
    private bool ispressing = false;

    private void Update()
    {

        if ((Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))&& !isjumping)
        {
            this._body.AddForce(Vector2.up*jumpVelocity, ForceMode2D.Impulse);
            Debug.Log("<color=blue>Input Space Hello </color>");
            //_body.velocity = Vector2.up * jumpVelocity;
            isjumping = true;
        }

        //Chiều ngang A, D, <, > Di chuyển qua lại
        //Debug.Log("<color=blue>Input horizontal: </color>" + Input.GetAxisRaw("Horizontal"));
        //this._body.AddForce(Input.GetAxisRaw("Horizontal") * Vector2.right * speed);

        //Debug.Log("<color=green>Input Vertical: </color>" + Input.GetAxisRaw("Vertical"));
        //this._body.AddForce(Input.GetAxisRaw("Vertical") * Vector2.up);

        //Input.GetAxisRaw("Vertical"); //Chiều dọc W, S, ^, v

        ////Check left, right arrow 
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && !ispressing)
        {
            Debug.Log("Left");
            this._body.velocity += Vector2.left * speed;
            ispressing = true;
        }
        else
        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && !ispressing)
        {
            Debug.Log("Right");
            this._body.velocity -= Vector2.left * speed;
            ispressing = true;
            //this._body.velocity += Vector2.left * Time.deltaTime * speed;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            ispressing = false;
        }
        else
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            ispressing = false;
            //this._body.velocity += Vector2.left * Time.deltaTime * speed;
        }


        ////add force

        ////giảm dần Vel theo hướng
        //this._body.velocity -= Vector2.left * Time.deltaTime * speed; //demo

        //Time.deltaTime; //khoảng thời gian giữa 2 frame
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Lúc va chạm
        //Debug.Log("<color=yellow>Collision enter</color>");

        if (collision.gameObject.tag == "Ground")
        {
            //Debug.Log("Wall");
            isjumping = false;
            //this._body.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //Vẫn còn va chạm (dính nhau)
        //Debug.Log("<color=green>Collision stay</color>");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //rời khỏi va chạm
        //Debug.Log("<color=red>Collision exit</color>");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("<color=yellow>Trigger enter</color>");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("<color=green>Trigger stay</color>");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("<color=red>Trigger exit</color>");
    }
}