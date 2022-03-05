using System;
using UnityEngine;

public class FontControl : MonoBehaviour
{
    private void Update()
    {
        Vector3 l = GameObject.Find("Main Camera").GetComponent<Camera>().transform.position - this.GetComponent<Transform>().position;
        double distance = Math.Sqrt(l.x * l.x + l.y * l.y + l.z * l.z);
        this.GetComponent<TextMesh>().fontSize = (int)(distance / 50 * 15);
    }
}
