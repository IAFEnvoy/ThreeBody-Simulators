using UnityEngine;

public class GravityControl : MonoBehaviour
{
    private void Update()
    {
        if (!TBCalculate.run)
            return;

        GameObject.Find("Gravity").GetComponent<Transform>().position
            = (GameObject.Find("Stars/starA").GetComponent<Transform>().position
            + GameObject.Find("Stars/starB").GetComponent<Transform>().position
            + GameObject.Find("Stars/starC").GetComponent<Transform>().position) / 3;
    }
}
