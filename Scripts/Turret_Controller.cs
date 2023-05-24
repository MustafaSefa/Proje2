using UnityEngine;
public class Turret_Controller : MonoBehaviour
{
    public Animator anm;
    private Transform Player;
    private float distance;
    public Transform BP;
    public GameObject BulletPrefab;
    public float FireRate;
    private float nextTimeToFire = 0;
    public int Health;
    public float s = 25.0f;
    public int Turret;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet1")
        {
            Health -= 25;
            if (Health <= 0)
            {
                Turret++;
                anm.Play("Explosion");
                Destroy(gameObject,0.45f);
            }
        }
    }
    void Update()
    {
        if (s <= 25.0f && s > 11.0f)
        {
            anm.speed = 0.5f;
        }
        else if (s <= 11 && s > 8)
        {
            anm.speed = 0.7f;
        }
        else if (s <= 8 && s > 6)
        {
            anm.speed = 0.8f;
        }
        else if (s == 6)
        {
            anm.speed = 0.9f;
        }
        else if (s == 5)
        {
            anm.speed = 1.1f;
        }
        else if (s == 4)
        {
            anm.speed = 1.5f;
        }
        else if (s == 3)
        {
            anm.speed = 2f;
        }
        else if (s == 2)
        {
            anm.speed = 2.4f;
        }
        if (Player.transform.position.y <= 1.30f)
        {
            distance = Player.transform.position.x + 9f;
        }
        else
        {
            distance = Player.transform.position.x + 13f;
        }
        if(!(transform.position.x <= Player.transform.position.x))
        {
            if (distance >= transform.position.x)
            {
                if (Time.time >= nextTimeToFire)
                {
                    nextTimeToFire = Time.time + s / FireRate;
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
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Turret++;
            anm.Play("Explosion");
            Destroy(gameObject,0.45f);
        }
        else if (col.gameObject.tag == "Missile")
        {
            Turret++;
            anm.Play("Explosion");
            Destroy(gameObject,0.45f);
        }
    }
    void Shoot()
    {
        Instantiate(BulletPrefab, BP.position, Quaternion.identity);
        anm.SetBool("Shoot", true);
        Sound_Controller.PlaySound("turret");
       
    }
    void timer()
    {
        s -= 0.001f;
    }
}
