using UnityEngine;

public class HighLightControlYellow : MonoBehaviour
{
    private HighlightableObject m_ho;

    void Awake()
    {
        m_ho = GetComponent<HighlightableObject>();
        m_ho.FlashingOn(Color.yellow, Color.yellow, 1f);
    }
}