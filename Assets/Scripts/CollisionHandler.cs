using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        string tag = other.gameObject.tag;
        switch (tag)
        {

            case "Friendly":
                Debug.Log("Friendly");
                break;

            case "Fuel":
                Debug.Log("Fuel");
                break;

            case "Finish":
                Debug.Log("Finish");
                break;
            default:
                Debug.Log("default");
                break;
        }
    }
}
