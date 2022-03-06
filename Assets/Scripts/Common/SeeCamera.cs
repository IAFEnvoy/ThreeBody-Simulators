using UnityEngine;

public class SeeCamera : MonoBehaviour
{
    private void Update()
    {
        transform.rotation = GameObject.Find("Main Camera").GetComponent<Camera>().transform.rotation;
    }
}
