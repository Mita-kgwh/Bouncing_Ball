using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D _rgbody;
    [SerializeField] Transform spawnPoint;
    //[SerializeField] LayerMask platformsLayerMask;
    CircleCollider2D circleCollider2d;
    public float movementSpeed;
    public float jumpForce;
    bool isJumping = false;
    //bool isPressed = false;
    //ButtonArrow ButLeft;
    //ButtonArrow ButRight;
    //ButtonArrow ButUp;
    //private bool ispressing = false;

    private void Awake()
    {
        circleCollider2d = gameObject.GetComponent<CircleCollider2D>();
        _rgbody = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        //ButLeft.eventMouseDown.AddListener(MoveLeft);
        //ButRight.eventMouseDown.AddListener(MoveRight);
        //ButUp.eventMouseDown.AddListener(Jump);

        //Button Right = GetComponent<Button>();
        //Right.onClick.AddListener(MoveRight);

        //Button Left = GetComponent<Button>();
        //Left.onClick.AddListener(MoveLeft);

        //_body = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {

        if ((Input.GetKey(KeyCode.Space) || Input.GetAxisRaw("Vertical") == 1) && !isJumping)
        {
            _rgbody.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
            //Debug.Log("<color=blue>Input Space Hello </color>");
            //_body.velocity = Vector2.up * jumpVelocity;
            isJumping = true;
        }

        //Chiều ngang A, D, <, > Di chuyển qua lại
        //Debug.Log("<color=blue>Input horizontal: </color>" + Input.GetAxisRaw("Horizontal"));
        //this._body.AddForce(Input.GetAxisRaw("Horizontal") * Vector2.right * speed);
        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1)
        {
            var movement = Input.GetAxis("Horizontal");
            //Debug.Log(Input.GetAxis("Horizontal"));
            //transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0) * Time.deltaTime * movementSpeed;
            _rgbody.velocity = new Vector2(movementSpeed*Input.GetAxis("Horizontal"), _rgbody.velocity.y);
            //isPressed = true;
        }

        //HandleMovement();
        //Debug.Log(_rgbody.velocity);
        { 
        //Debug.Log("<color=green>Input Vertical: </color>" + Input.GetAxisRaw("Vertical"));
        //this._body.AddForce(Input.GetAxisRaw("Vertical") * Vector2.up);

        //Input.GetAxisRaw("Vertical"); //Chiều dọc W, S, ^, 

        //if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        //{
        //    ispressing = false;
        //    //this._body.velocity += Vector2.left * Time.deltaTime * speed;
        //}


        ////add force

        ////giảm dần Vel theo hướng
        //this._body.velocity -= Vector2.left * Time.deltaTime * speed; //demo

        //Time.deltaTime; //khoảng thời gian giữa 2 frame
        }
    }

    private void HandleMovement()
    {
        //float control = 1.5f;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _rgbody.velocity = new Vector2(-movementSpeed, _rgbody.velocity.y);
        }
        //if (Input.GetKeyUp(KeyCode.LeftArrow))
        //{
        //    _rgbody.velocity += new Vector2(-movementSpeed * Time.deltaTime * control, _rgbody.velocity.y);
        //    _rgbody.velocity = new Vector2(Mathf.Clamp(_rgbody.velocity.x,-movementSpeed,+movementSpeed), _rgbody.velocity.y);
        //}
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _rgbody.velocity = new Vector2(+movementSpeed, _rgbody.velocity.y);
            
        }
        //if (Input.GetKeyUp(KeyCode.RightArrow))
        //{
        //    _rgbody.velocity += new Vector2(+movementSpeed * Time.deltaTime * control, _rgbody.velocity.y);
        //    _rgbody.velocity = new Vector2(Mathf.Clamp(_rgbody.velocity.x, -movementSpeed, +movementSpeed), _rgbody.velocity.y);
        //    //{
        //    //    // No keys pressed
        //    //    _rgbody.velocity = new Vector2(0, _rgbody.velocity.y);
        //    //}
        //}
    }
    public void MoveLeft()
    {
        //_rgbody.AddForce(new Vector2(-200f, 0));
        _rgbody.velocity = new Vector2(-movementSpeed, _rgbody.velocity.y);
    }
    public void MoveRight()
    {
        //_rgbody.AddForce(new Vector2(200f, 0));
        _rgbody.velocity = new Vector2(+movementSpeed, _rgbody.velocity.y);
    }
    public void Jump()
    {
        if (!isJumping)
        {
            _rgbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            Debug.Log("<color=blue>Input Space Hello </color>");
            //_body.velocity = Vector2.up * jumpVelocity;
            isJumping = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Lúc va chạm
        //Debug.Log("<color=yellow>Collision enter</color>");
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Thorn")
        {
            GamesManager.health -= 1;
            //_body.velocity = Vector2.zero;
            //transform.position = spawnPoint.position;
            //Debug.Log("<color=yellow>Collision enter</color>");
        }
        

    }

    //private bool IsGrounded()
    //{
    //    RaycastHit2D raycastHit2d = Physics2D.CircleCast(circleCollider2d.bounds.center, circleCollider2d.radius, 0f, Vector2.down, 1f, platformsLayerMask)
    //        Physics2D.BoxCast(circleCollider2d.bounds.center, circleCollider2d.bounds.size, 0f, Vector2.down, 1f, platformsLayerMask);
    //    Debug.Log(raycastHit2d.collider);
    //    return raycastHit2d.collider != null;
    //}
    private void OnCollisionStay2D(Collision2D collision)
    {
        //Vẫn còn va chạm (dính nhau)
        //Debug.Log("<color=green>Collision stay</color>");
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Ring")
        {
            //Debug.Log("Gronud");
            isJumping = false;
            //this._body.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //rời khỏi va chạm
        //Debug.Log("<color=red>Collision exit</color>");
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Ring")
        {
            //Debug.Log("Gronud");
            isJumping = true;
            //this._body.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("<color=yellow>Trigger enter</color>");
        //Debug.Log("<color=red>Trigger enter</color>");
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("<color=green>Trigger stay</color>");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}