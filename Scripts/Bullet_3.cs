using UnityEngine;

public class Bullet_3 : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    private void Start()
    {
        transform.Rotate(0f,0f,-48f);
    }
    void Update()
    {
        rb.velocity = (Vector2.up + Vector2.left) * speed;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
