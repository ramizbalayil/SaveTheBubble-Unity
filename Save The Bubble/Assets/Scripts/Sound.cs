using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip file;
    [HideInInspector]
    public AudioSource source;
}
