using UnityEngine;

public class Sound_Controller : MonoBehaviour
{
    public static AudioClip  bomb, coin, Turret, Soldier;
    public static AudioSource audioSource;
    void Start()
    {
        bomb = Resources.Load<AudioClip>("Bomb_Sound");
        coin = Resources.Load<AudioClip>("Coin_Sound");
        Turret = Resources.Load<AudioClip>("Turret_Sound");
        Soldier = Resources.Load<AudioClip>("Soldier_Sound");
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "bomb":
                audioSource.PlayOneShot(bomb);
                break;
            case "coin":
                audioSource.PlayOneShot(coin);
                break;
            case "turret":
                audioSource.PlayOneShot(Turret);
                break;
            case "soldier":
                audioSource.PlayOneShot(Soldier);
                break;
        }
    }
}
