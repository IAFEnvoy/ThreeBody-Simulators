using UnityEngine;

public class BoomControl : MonoBehaviour
{
  public Camera mainCamera;

  // 碰撞开始
  private void OnCollisionEnter(Collision collision)
  {
    if (!GameObject.Find("BoomParticle").GetComponent<ParticleSystem>().isPlaying)
    {
      GameObject.Find("BoomParticle").GetComponent<Transform>().position = this.transform.position;
      GameObject.Find("BoomParticle").GetComponent<ParticleSystem>().Play();
      GameObject.Find("BoomParticle").GetComponent<AudioSource>().Play();
    }
    Debug.LogWarning("星球" + this.name + "发生碰撞");
    if (mainCamera.transform.parent == transform)
      mainCamera.transform.parent = null;
    Destroy(this.gameObject);
    TBCalculate.run = false;
  }
}
