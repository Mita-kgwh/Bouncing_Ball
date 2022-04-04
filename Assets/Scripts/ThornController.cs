using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornController : MonoBehaviour
{
    // Start is called before the first frame update
    public int type;
    public float speed;
    int turn;
    [SerializeField] Rigidbody2D _rb;
    /*
     * type == 0, not moving
     * type == 1, moving vertical
     * type == 2, moving horizontal
     */
    void Start()
    {
        turn = 1;
    }
  
    // Update is called once per frame
    void Update()
    {
        switch (type)
        {
            case 0:
                _rb.constraints = RigidbodyConstraints2D.FreezeAll;
                break;
            case 1:
                _rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                _rb.velocity = Vector2.left * speed * turn;
                break;
            case 2:
                _rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                _rb.velocity = Vector2.up * speed * turn;
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            turn = -turn;
        }
    }
}
