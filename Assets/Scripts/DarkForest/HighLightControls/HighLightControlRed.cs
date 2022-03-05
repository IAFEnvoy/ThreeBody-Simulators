using UnityEngine;
using System.Collections;

public class HighLightControlRed : MonoBehaviour
{
    private HighlightableObject m_ho;

    void Awake()
    {
        m_ho = GetComponent<HighlightableObject>();
        m_ho.FlashingOn(Color.red, Color.red, 1f);
    }
}