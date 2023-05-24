using UnityEngine;
using TMPro;
public class User_Information : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI bombText;
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI missileText;
    void Start()
    {
        coinText.text = PlayerPrefs.GetInt("coin").ToString();
        bombText.text = PlayerPrefs.GetInt("bomb").ToString();
        highscoreText.text = Player_Controller._score.ToString();
        missileText.text = PlayerPrefs.GetInt("missile").ToString();
    }
}
