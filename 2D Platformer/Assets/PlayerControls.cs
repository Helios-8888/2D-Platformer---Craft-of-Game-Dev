using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Rigidbody2D rb;
    public float MoveSpeed, JumpForce, AirSpeed, AirMax;
    public bool Grounded = false;   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Grounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && Grounded)
        {
            rb.AddForce(JumpForce * Vector2.up, ForceMode2D.Impulse);
        }
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
