using UnityEngine;

public class Bullet_1 : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    void Update()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Wall" || col.gameObject.tag == "Soldier" || col.gameObject.tag == "Turret")
        {
            Destroy(gameObject);
        }
    }
}
