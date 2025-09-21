using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    bool isJumping = true;
    public float jumpPower = 10.0f;

    public GameObject gameOverText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isJumping = true;
        Debug.Log("Player : isJumping = true");
        gameOverText.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            Debug.Log("Player : Floor ¥Í¿Ω");
            isJumping = false;
            Debug.Log("Player : isJumping = false");
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player : ¿˚ø°∞‘ ¥Í¿Ω");
            gameOverText.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && !isJumping)
        {
            Debug.Log("Player : ¡°«¡!!(Space Bar Pressed)");
            rb.linearVelocity = new Vector2(0.0f, jumpPower);
            isJumping=true;
            Debug.Log("Player : isJumping = true");
        }
    }
}