using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb2D;//Componente de fisicas de unity (salto, movimiento de personaje...)
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float move;
    public float jumpForce = 4;
    private bool isGrounded;
    public Transform groundCheck;
    public float groundRadius=0.1f;
    public LayerMask groundLayer;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>(); //acceder al componente de unit
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        rb2D.linearVelocity = new Vector2(move * speed, rb2D.linearVelocity.y);

        if (move !=0)
        {
            transform.localScale = new Vector3(Mathf.Sign(move), 1, 1); //Mathf.Sign devuelve el signo del valor (positivo o negativo)
        }
        if (Input.GetButtonDown("Jump")&& isGrounded)
        {
            rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, jumpForce);
        }
    }
    //Comprobara que esta colisionando con la layer de Floor
    public void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
    }
}
