using UnityEngine;

public class SpikeAction : MonoBehaviour
{
    public float spikeSpeed = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        float moveVectorX = Time.deltaTime * spikeSpeed;
        transform.position = new Vector3(transform.position.x - moveVectorX, transform.position.y, transform.position.z);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SpikeDestroyer"))
        {
            Destroy(gameObject);
            Debug.Log("Spike : ¼Ò¸ê");
        }
    }
}