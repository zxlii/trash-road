using UnityEngine;

public class ManagerAudio : MonoBehaviour
{

    private static AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public static void PlaySound(string _SoundName)
    {
        if (Profile.Instance.IsMute) return;
        AudioSource.PlayClipAtPoint(Resources.Load<AudioClip>("Sounds/" + _SoundName), Game.Instance.Ui.soundCameraPos, 1);
    }

    public static void PlayBGM(string _BackgroundName)
    {
        source.clip = Resources.Load<AudioClip>("Sounds/" + _BackgroundName);
        source.loop = true;
        // if (settings.OptionSound)
        source.Play();
    }

    public static void StopBMG()
    {
        source.Stop();
    }

    public static void StartBGM()
    {
        source.Play();
    }
}
