using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public float FollowSpeed;
    public Transform target;

    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x + 7f, target.position.y, -10f);
        if (newPos.y > 0.20f)
        {
            newPos.y = 0.13f;
            transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed  * Time.deltaTime);
        }
        else if(newPos.y < 0)
        {
            newPos.y = 0.03f;
            transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed  * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed  * Time.deltaTime);
        }
        
    }
}
