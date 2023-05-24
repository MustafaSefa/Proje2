using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    private TextMeshProUGUI text;
    public static int coin;
    private void Awake()
    {
        text = GameObject.FindGameObjectWithTag("text").GetComponent<TextMeshProUGUI>();
        coin = PlayerPrefs.GetInt("coin");
    }
    void Start()
    {
        text.text = coin.ToString();
    }
    private void Update()
    {
        Destroy(gameObject,8.2f);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            coin++;
            PlayerPrefs.SetInt("coin",coin);
            text.text = PlayerPrefs.GetInt("coin").ToString();
            Destroy(gameObject);
            Sound_Controller.PlaySound("coin");
        }
    }
}
