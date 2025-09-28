using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public bool isFloor;
    public bool isUpperFloor;
    bool isShrunk;
    public float jumpPower = 10.0f;
    public float gravityScale = 1.0f;

    public GameObject gameOverText;

    public AudioSource bgm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isFloor = true;
        isUpperFloor = false;
        isShrunk = false;
        gameOverText.SetActive(false);
        Debug.Log("Player : ∞‘¿” Ω√¿€, πŸ¥⁄ø° ¿÷¿Ω");
    }

    // Update is called once per frame
    void Update()
    {
        if ((Keyboard.current.upArrowKey.wasPressedThisFrame || Keyboard.current.wKey.wasPressedThisFrame) && isFloor)
        {
            rb.gravityScale = -gravityScale;
            isFloor = false;
            Debug.Log("Player : «œ¥√");
        }

        if ((Keyboard.current.downArrowKey.wasPressedThisFrame || Keyboard.current.sKey.wasPressedThisFrame) && isUpperFloor)
        {
            rb.gravityScale = gravityScale;
            isUpperFloor = false;
            Debug.Log("Player : πŸ¥⁄");
        }

        if (Keyboard.current.shiftKey.wasPressedThisFrame && !isShrunk)
        {
            Vector3 scale = transform.localScale;
            scale.y *= 0.5f;
            Vector3 position = transform.localPosition;
            if (isFloor)
            {
                position.y -= 0.5f;
            }
            else if (isUpperFloor)
            {
                position.y += 0.5f;
            }
            transform.localScale = scale;
            transform.localPosition = position;
            isShrunk = true; 
            Debug.Log(transform.localScale);
            Debug.Log("Player : øı≈©∏Æ±‚");
        }

        if (Keyboard.current.shiftKey.wasReleasedThisFrame && isShrunk)
        {
            Vector3 scale = transform.localScale;
            scale.y *= 2f;
            Vector3 position = transform.localPosition;
            if (isFloor)
            {
                position.y += 0.5f;
            }
            else if (isUpperFloor)
            {
                position.y -= 0.5f;
            }
            transform.localScale = scale;
            transform.localPosition = position;

            isShrunk = false;
            Debug.Log("Player : øı≈©∏Æ±‚ «ÿ¡¶");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isFloor = true;
        }
        else if (collision.gameObject.CompareTag("UpperFloor"))
        {
            isUpperFloor = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Time.timeScale = 0;
            rb.simulated = false;

            gameOverText.SetActive(true);
            bgm.Stop();

            Destroy(gameObject, 3f);

        }
    }
}