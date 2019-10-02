using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 150.0f;
    public float fanForce = 10.0f;
    public float speed = 3f;

    private Animator _anim;
    private Rigidbody2D _rb;
    private bool _isOnGround = false;
    private bool _facingRight = true;
    //private Vector3 _startingPosition;

    // Use this for initialization
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>(); // Get the rigidbody component added to the script and store it in _rb
        _anim = GetComponent<Animator>();
        //_startingPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float input = Input.GetAxis("Horizontal"); 
        var movement = input * speed;

        _rb.velocity = new Vector3(movement, _rb.velocity.y, 0);

        if (input > 0 && !_facingRight)
            Flip();
        else if (input < 0 && _facingRight)
            Flip();

        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround)
        {
            _rb.AddForce(new Vector3(0, jumpForce, 0));
            _isOnGround = false;
        }
    }

    void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == Constants.Tags.FloorTag || coll.gameObject.tag == Constants.Tags.StartTag || coll.gameObject.tag == Constants.Tags.EndTag)
        {
            _isOnGround = true;           
        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == Constants.Tags.FanTag)
        {
            _rb.AddForce(new Vector3(0, fanForce, 0));
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == Constants.Tags.HeatTag)
        {
            _anim.SetBool(Constants.AnimationParameters.Melt, true);
        }
    }
}