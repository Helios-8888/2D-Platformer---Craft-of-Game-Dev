using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public float MoveSpeed, JumpForce, AirSpeed, AirMax;
    public bool Grounded = false;   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Grounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Animator Controller
        float xSpeed = Mathf.Abs(rb.linearVelocityX);
        animator.SetFloat("xSpeed", xSpeed);
        float ySpeed = rb.linearVelocityY;
        animator.SetFloat("ySpeed", ySpeed);

        //Get ButtonDown Has to be in update
        if (Input.GetButtonDown("Jump") && Grounded)
        {
            rb.AddForce(JumpForce * Vector2.up, ForceMode2D.Impulse);
        }

        //Flips the sprite when moving in the other direction
        if (rb.linearVelocity.x * transform.localScale.x < 0.0f) //Checks if the sprite is moving to the left
            transform.localScale = new Vector3(-transform.localScale.x,transform.localScale.y, transform.localScale.z); 
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        if (h != 0.0f)
        {
            if (Grounded)
                rb.linearVelocity = new Vector2(h * MoveSpeed, rb.linearVelocityY);
            else
            {
                float vx = rb.linearVelocityX * h;
                if (vx < AirMax)
                    rb.linearVelocity = new Vector2(h * AirSpeed, rb.linearVelocityY);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Grounded = true;    
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Grounded = false;
        }
    }
}
