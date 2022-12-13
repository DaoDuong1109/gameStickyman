using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumSpeed = 8f;
    private float direction = 0f;
    private float directionY = 0f;

    private Rigidbody2D player;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    private bool isFalling;
    private Vector3 newRotation;
    private Animator playerAnimation;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        newRotation = new Vector3(0, 180, 0);
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        direction = Input.GetAxis("Horizontal");
        directionY = Input.GetAxis("Vertical");
        //sang phai
        if (direction > 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            //GetComponent<SpriteRenderer>().flipX = false;
            player.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        //sang trai
        else if (direction < 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            // GetComponent<SpriteRenderer>().flipX = true;
            player.transform.eulerAngles = newRotation;
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }

        //nhay
        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            player.velocity = new Vector2(player.velocity.x, jumSpeed);
        }

        //roi va cham dat
        playerAnimation.SetFloat("Speed", Mathf.Abs(player.velocity.x));
        playerAnimation.SetBool("OnGround", isTouchingGround);
        //roi
        if (player.velocity.y < 0f)
        {
            isFalling = true;
        }
        else
        {
            isFalling = false;
        }
        if (isFalling)
        {
            playerAnimation.SetBool("IsFalling", isFalling);
        }
        //

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Dung khi cham cua
        if (collision.gameObject.tag == "Goal")
        {
            Time.timeScale = 0;
        }
        //reload scene khi cham bay
        if (collision.gameObject.tag == "Trap")
        {
            Scene thisScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(thisScene.name);
        }
    }
}
