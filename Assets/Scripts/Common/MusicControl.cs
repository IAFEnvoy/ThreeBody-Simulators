using UnityEngine;

public class MusicControl : MonoBehaviour
{
  public AudioClip[] musics = new AudioClip[5];
  public int First_Play = -1;
  public AudioSource player;
  public bool Play_Random = false;
  private int playnow = -1;

  private bool checkload()
  {
    for (int i = 0; i < musics.Length; i++)
      if (musics[i].loadState != AudioDataLoadState.Loaded)
        return false;
    return true;
  }

  private void Start()
  {
    for (int i = 0; i < musics.Length; i++)
      if (!musics[i].loadInBackground)
        Debug.LogWarning("Music " + musics[i].name + "'s setting \"loadInBackground\" don't set to true, may be cause loading slowly after build.");

    player.Stop();
    player.loop = false;
    player.playOnAwake = false;
    if (0 <= First_Play && First_Play < musics.Length)
      playnow = First_Play;
    else if (Play_Random)
    {
      System.Random rd = new System.Random();
      playnow = rd.Next() % musics.Length;
    }
    else
      playnow = 0;
  }

  private void Update()
  {
    if (player.isPlaying)
      return;
    if (!checkload())
      return;
    if (Play_Random)
    {
      player.clip = musics[playnow];
      player.Play();
      System.Random rd = new System.Random();
      playnow = rd.Next() % musics.Length;
    }
    else
    {
      player.clip = musics[playnow];
      player.Play();
      playnow = (playnow + 1) % musics.Length;
    }
  }
}
