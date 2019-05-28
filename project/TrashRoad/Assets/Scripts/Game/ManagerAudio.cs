using UnityEngine;
using System.Collections.Generic;
[RequireComponent(typeof(AudioListener))]
[RequireComponent(typeof(AudioSource))]

public class ManagerAudio : MonoBehaviour
{

    public static ManagerAudio Instance;
    private AudioSource m_Souce;
    private Dictionary<string, AudioClip> m_AudioClipMap = new Dictionary<string, AudioClip>();

    void Awake()
    {
        Instance = this;
        m_Souce = GetComponent<AudioSource>();
    }
    private AudioClip GetClip(string fileName)
    {
        var path = "Sounds/" + fileName;
        AudioClip clip;
        if (!m_AudioClipMap.TryGetValue(path, out clip))
        {
            clip = Resources.Load<AudioClip>(path);
            m_AudioClipMap.Add(path, clip);
        }
        return clip;
    }
    public void PlaySound(string _SoundName)
    {
        if (Profile.Instance.IsMute)
            return;

        AudioSource.PlayClipAtPoint(GetClip(_SoundName), transform.position, 1);
    }

    public void PlayBGM(string _BackgroundName)
    {
        if (Profile.Instance.IsMute)
            return;
        m_Souce.clip = GetClip(_BackgroundName);
        m_Souce.loop = true;
        m_Souce.Play();
    }

    public void StopBMG()
    {
        m_Souce.Stop();
    }

    public void StartBGM()
    {
        m_Souce.Play();
    }
}
