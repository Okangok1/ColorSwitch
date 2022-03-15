using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 6f;
    public bool isJumping = false;
    [SerializeField] private string currentColor;
    [SerializeField] private Color red;
    [SerializeField] private Color blue;
    [SerializeField] private Color yellow;
    [SerializeField] private Color purple;

    private SpriteRenderer spriteRenderer;
    private GameController gameController;
    private float resetTimer = 2f;
    public bool isPlayerDead = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetRandomColor();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        gameController.GetObstacles();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isPlayerDead)
        {
            isJumping = true;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (isPlayerDead)
        {
            resetTimer -= Time.deltaTime;
            if (resetTimer <= 0)
            {
                gameController.GameOver();
            }
        }
    }
    private void FixedUpdate()
    {
        if (isJumping)
        {
            rb.velocity = Vector2.up * jumpForce;
            rb.gravityScale = 1;
            isJumping = false;
        }
    }
    private void SetRandomColor()
    {
        int randomColor = Random.Range(0, 4);
        switch (randomColor)
        {
            case 0:
                currentColor = "Blue";
                spriteRenderer.color = blue;
                break;
            case 1:
                currentColor = "Yellow";
                spriteRenderer.color = yellow;
                break;
            case 2:
                currentColor = "Purple";
                spriteRenderer.color = purple;
                break;
            case 3:
                currentColor = "Red";
                spriteRenderer.color = red;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FinishLine")
        {
            gameController.GameWon();
            return;
        }
        if (collision.gameObject.tag != currentColor && collision.gameObject.tag != "Circle" && collision.gameObject.tag != "Score" && collision.gameObject.tag != "ColorChanger" && collision.gameObject.tag!="ClickableArea")
        {
            isPlayerDead = true;
            return;
        }
        if (collision.gameObject.tag == "Score")
        {
            gameController.IncreaseScore();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "ColorChanger")
        {
            SetRandomColor();
            Destroy(collision.gameObject);
        }

    }
}
