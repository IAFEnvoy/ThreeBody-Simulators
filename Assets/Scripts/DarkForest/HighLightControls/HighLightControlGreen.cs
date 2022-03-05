using UnityEngine;

public class HighLightControlGreen : MonoBehaviour
{
    private HighlightableObject m_ho;

    void Awake()
    {
        m_ho = GetComponent<HighlightableObject>();
        m_ho.FlashingOn(Color.green, Color.green, 1f);
    }
}