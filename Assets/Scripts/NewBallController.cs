using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewBallController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rb;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixUpdate()
    {
        Vector3 movement = new Vector3(movementX, movementY, 0.0f);

        _rb.AddForce(movement);
    }

}
