using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    private AudioSource source;
    [SerializeField] private AudioClip[] clips;
    [SerializeField] private float delayBetweenClips;
    private bool canPlay;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        canPlay = true;
    }

    public void Play()
    {
        if (!canPlay)
            return;
        GameManager.Instance.Timer.Add(() => { canPlay = true; }, delayBetweenClips);
        var clip = clips[Random.Range(0, clips.Length)];
        source.PlayOneShot(clip);
    }
}