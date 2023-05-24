using UnityEngine;
public class Soldier_Controller : MonoBehaviour
{
    public Animator anm;
    private  Transform Player;
    private float distance;
    public Transform BP;
    public GameObject BulletPrefab;
    public float FireRate;
    private float nextTimeToFire = 0;
    public int Health;
    public int soldier;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        distance = Player.transform.position.x + 9f;
        if(!(transform.position.x <= Player.transform.position.x))
        {
            if (distance >= transform.position.x)
            {
                if (Time.time >= nextTimeToFire)
                {
                    nextTimeToFire = Time.time + 20 / FireRate;
                    Shoot();
                }
            }
        }
        else if (Player.transform.position.x - transform.position.x >= 7f)
        {
            Destroy(gameObject);
        }
        else
        {
            anm.SetBool("Shoot", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet1")
        {
            Health -= 25;
            if (Health <= 0)
            {
                soldier++;
                transform.Rotate(0f,0f,-90f);
                Destroy(gameObject,0.67f);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            soldier++;
            transform.Rotate(0f,0f,-90f);
            Destroy(gameObject,0.67f);
        }
        else if (col.gameObject.tag == "Missile")
        {
            soldier++;
            transform.Rotate(0f,0f,-90f);
            Destroy(gameObject, 0.67f);
        }
    }
    void Shoot()
    {
        Instantiate(BulletPrefab, BP.position, Quaternion.identity);
        anm.SetBool("Shoot", true);
        Sound_Controller.PlaySound("soldier");
    }
}
