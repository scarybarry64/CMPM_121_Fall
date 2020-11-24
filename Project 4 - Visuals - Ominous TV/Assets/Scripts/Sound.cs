// Barry Day, 11-23-20
// Code by: https://www.youtube.com/watch?v=6OT43pvUyfY
// Stores sound info

using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;
    public bool loop;
    [HideInInspector]
    public AudioSource source;
}
