using UnityEngine;

public class Missile : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public Animator anm;
    public Soldier_Controller s;
    public Turret_Controller t;
    void Update()
    {
        rb.velocity = (Vector2.right * speed) + 3 * Vector2.down;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            if (GameObject.FindGameObjectWithTag("Soldier").transform.position.x - gameObject.transform.position.x <=
                2f)
            {
                s.soldier++;
                anm.Play("Explosion");
                Destroy(gameObject, 0.43f);
                Destroy(GameObject.FindGameObjectWithTag("Soldier"));
            }
            else if (GameObject.FindGameObjectWithTag("Turret").transform.position.x - gameObject.transform.position.x <= 2f)
            {
                t.Turret++;
                anm.Play("Explosion");
                Destroy(gameObject, 0.43f);
                Destroy(GameObject.FindGameObjectWithTag("Turret"),0.25f);
            }
            anm.Play("Explosion");
            Destroy(gameObject, 0.43f);
        }
        else if (col.gameObject.tag == "Turret")
        {
            t.Turret++;
            anm.Play("Explosion");
            Destroy(gameObject, 0.43f);
            Destroy(GameObject.FindGameObjectWithTag("Turret"));
        }
        else if (col.gameObject.tag == "Soldier")
        {
            s.soldier++;
            anm.Play("Explosion");
            Destroy(gameObject, 0.43f);
            Destroy(GameObject.FindGameObjectWithTag("Soldier"));
        }
    }
}
