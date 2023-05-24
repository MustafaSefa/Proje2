using System;
using SimpleInputNamespace;
using UnityEngine;
using TMPro;
using UnityStandardAssets.CrossPlatformInput;
using GoogleMobileAds.Api;
public class Player_Controller : MonoBehaviour
{
    private float MoveX = 1.4f;
    public Rigidbody2D rb;
    public Animator animation_1;
    [SerializeField]
    private float Speed;
    [SerializeField]
    private float Speed1;
    private Transform BulletPoint;
    public GameObject BulletPrefab;
    public Transform MissilePoint;
    public GameObject MissilePrefab;
    public int Health;
    private Transform BombPoint;
    public GameObject BombPrefab;
    public float FireRate;
    private float nextTimeToFire = 0;
    public Turret_Controller t;
    public TextMeshProUGUI BombText;
    public static int bomb = 5;
    public static int missile = 0;
    public GameObject GameOverPanel;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HighScoreText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI soldierText;
    public TextMeshProUGUI turretText;
    public TextMeshProUGUI missileText;
    public int score = 0;
    public static int _score = 0;
    public Soldier_Controller s;
    //public Joystick_Controller j;
   // public ButtonInputUI bUI;
    //public ButtonInputUI Buı;
    //public ButtonInputUI _buı;
    public AudioSource a;
    public AudioSource b;
    public AudioSource c;
    //private InterstitialAd interstitial;
    //private static int count = 0;
    void Start()
    {
        c.Play();
        t.s = 25.0f;
        BulletPoint = GameObject.FindGameObjectWithTag("BulletPoint").GetComponent<Transform>();
        BombPoint = GameObject.FindGameObjectWithTag("Bomb").GetComponent<Transform>();
        BombText.text = PlayerPrefs.GetInt("bomb").ToString();
        missileText.text = PlayerPrefs.GetInt("missile").ToString();
        s.soldier = 0;
        soldierText.text = s.soldier.ToString();
        t.Turret = 0;
        turretText.text = t.Turret.ToString();
        //RequestInterstitial();
        //count++;
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            InvokeRepeating("Shoot_Bullet",0.01f,10);
        }
        else
        {
            CancelInvoke("Shoot_Bullet");
            a.Stop();   
            animation_1.SetBool("Attack", false);
        }
        /*if (count == 4)
        {
            count = 0;
            Ads();
        }
        if (_buı.button.value == true)
        {
            a.mute = false;
            InvokeRepeating("Shoot_Bullet",0.01f,10);
            _buı.button.value = false;
            Invoke("Plane",0.01f);
            Invoke("m", 0.5f);
        }
        else
        {
            CancelInvoke("Shoot_Bullet");
            animation_1.SetBool("Attack", false);
        }*/
        BombText.text = PlayerPrefs.GetInt("bomb").ToString();
        missileText.text = PlayerPrefs.GetInt("missile").ToString();
        Invoke("Score",0.5f);
        Invoke("Movement",0.5f);
        
        if (Input.GetMouseButtonDown(1))
        {
            InvokeRepeating("Shoot_Bomb",0.01f,10);
        }
        else if (Input.GetButton("Jump"))
        {
            InvokeRepeating("Shoot_Missile",0.01f,10);
        }
        else
        {
            CancelInvoke("Shoot_Bomb");
            CancelInvoke("Shoot_Missile");
        }
        /*if (bUI.button.value == true)
        {
            InvokeRepeating("Shoot_Bomb",0.01f,10);
            bUI.button.value = false;
        }
        else
        {
            CancelInvoke("Shoot_Bomb");
        }
        if (Buı.button.value == true)
        {
            InvokeRepeating("Shoot_Missile",0.01f,10);
            Buı.button.value = false;
        }
        else
        {
            CancelInvoke("Shoot_Missile");
        }*/
    }
/*
    private void m()
    {
        a.mute = true;
    }
    private void Plane()
    {
        a.PlayOneShot(a.clip);
    }
    private void RequestInterstitial()
    {
        #if UNITY_ANDROID
        string adUnitId = "ca-app-pub-5715784809870825/4868837583";
        #else
            string adUnitId = "unexpected_platform";
        #endif
        this.interstitial = new InterstitialAd(adUnitId);
        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);
    }*/
    void Score()
    {
        score += Convert.ToInt32(0.6f);
        ScoreText.text = score.ToString();
        scoreText.text = score.ToString();
        if (_score < score)
        {
            _score = score;
            HighScoreText.text = _score.ToString();
        }
        else
        {
            HighScoreText.text = _score.ToString();
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Wall" || collision.gameObject.tag =="Turret")
        {
            Invoke("time",0.50f);
            GameOver();
            b.Play();
            Sound_Controller.audioSource.volume = 0f;
            c.Stop();
            soldierText.text = s.soldier.ToString();
            turretText.text = t.Turret.ToString();
            coinText.text = PlayerPrefs.GetInt("coin").ToString();
            animation_1.SetBool("Death3", true);
            Destroy(gameObject, 0.40f);
        }
    }
    void time()
    {
        Time.timeScale = 0;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bullet2")
        {
            Health--;
            if (Health <= 0)
            {
                Invoke("time",0.50f);
                GameOver();
                b.Play();
                Sound_Controller.audioSource.volume = 0f;
                c.Stop();
                soldierText.text = s.soldier.ToString();
                turretText.text = t.Turret.ToString();
                coinText.text = PlayerPrefs.GetInt("coin").ToString();
                animation_1.SetBool("Death3", true);
                Destroy(gameObject, 0.40f);
            }
        }
        else if(col.gameObject.tag == "Bullet3")
        {
            Health -= 10;
            if (Health <= 0)
            {
                Invoke("time",0.50f);
                GameOver();
                b.Play();
                Sound_Controller.audioSource.volume = 0f;
                c.Stop();
                soldierText.text = s.soldier.ToString();
                turretText.text = t.Turret.ToString();
                coinText.text = PlayerPrefs.GetInt("coin").ToString();
                scoreText.text = (score + 1).ToString();
                animation_1.SetBool("Death3", true);
                Destroy(gameObject, 0.40f);
            }
        }
    }
    private void Shoot_Bullet()
    {
        t.Invoke("timer",0.002f);
        if (t.s < 2)
        {
            t.CancelInvoke("timer");
        }
        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1 / FireRate;
            Instantiate(BulletPrefab, BulletPoint.position, BulletPoint.rotation);
        } 
        if (Health >= 50)
        {
            animation_1.SetBool("Attack", true);
        }
        else if (Health < 50)
        {
            animation_1.SetBool("DefaultDamage", false);
            animation_1.SetBool("AttackDamage", true);
        }
        else if (Health < 50 && Health > 1)
        {
            animation_1.SetBool("DefaultDamage", true); 
            animation_1.SetBool("Damage", true);
        }
        else if (Health <= 0)
        {
            Invoke("time",0.50f);
            GameOver();
            b.Play();
            Sound_Controller.audioSource.volume = 0f;
            c.Stop();
            soldierText.text = s.soldier.ToString();
            turretText.text = t.Turret.ToString();
            coinText.text = PlayerPrefs.GetInt("coin").ToString();
            scoreText.text = (score + 1).ToString();
            animation_1.SetBool("Death2", true);
            animation_1.SetBool("Death", true);
            Destroy(gameObject, 0.43f);
        }
        else
        {
            animation_1.SetBool("Attack", false);
            animation_1.SetBool("AttackDamage", false);
        }
    }
    private void Shoot_Bomb()
    {
        if (bomb > 0)
        {
            Instantiate(BombPrefab, BombPoint.position, BombPoint.rotation);
            bomb--;
            PlayerPrefs.SetInt("bomb",bomb);
            if (bomb != PlayerPrefs.GetInt("bomb"))
            {
                PlayerPrefs.SetInt("bomb", bomb);
            }
            Sound_Controller.PlaySound("bomb");
        }
    }
    private void  Shoot_Missile()
    {
        if (missile > 0)
        {
            Instantiate(MissilePrefab, MissilePoint.position, MissilePoint.rotation);
            missile--;
            PlayerPrefs.SetInt("missile",missile);
            if (missile != PlayerPrefs.GetInt("missile"))
            {
                PlayerPrefs.SetInt("missile", missile);
            }
            Sound_Controller.PlaySound("bomb");
        }
    }
    private void GameOver()
    {
        GameOverPanel.SetActive(true);
    }
    /*public void Ads()
    {
        if (this.interstitial.IsLoaded()) {
            this.interstitial.Show();
        }
    }*/
    public void Movement()
    {
        Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 pos = new Vector3(0,newPos.y , 0);
        float a = Vector3.SignedAngle(transform.right, pos, transform.forward);
        
     if (newPos.y >= 0.6f)
     {
         a = 45f;
         Quaternion p = Quaternion.Euler(0,0,a);
         transform.rotation = Quaternion.Lerp(transform.rotation, p, Time.deltaTime * Speed);
         transform.rotation = Quaternion.Lerp(transform.rotation, p, Time.deltaTime * Speed);
     }
     else if(newPos.y < 0)
     {
         a = -45f;
         Quaternion p = Quaternion.Euler(0,0,a);
         transform.rotation = Quaternion.Lerp(transform.rotation, p, Time.deltaTime * Speed);
         transform.rotation = Quaternion.Lerp(transform.rotation, p, Time.deltaTime * Speed);
     }
     else
     {
         Quaternion p = Quaternion.Euler(0,0,0);
         transform.Rotate(0,0,0);
         transform.rotation = Quaternion.Lerp(transform.rotation, p, Time.deltaTime * Speed);
     }
     rb.velocity = new Vector2(
         MoveX * Speed,
         newPos.y * Speed1);
        /*Vector3 mPosition = new Vector3(0, j.delta/45, 0);
        float cursorAngle = Vector3.SignedAngle(transform.right, mPosition, transform.forward);
        Quaternion pAngle = Quaternion.Euler(0, 0, cursorAngle);
        transform.rotation = Quaternion.Lerp(transform.rotation, pAngle, Time.deltaTime * Speed);
        rb.velocity = new Vector2(
            MoveX * Speed,
            mPosition.y * Speed1 * 6); */
    }
}
