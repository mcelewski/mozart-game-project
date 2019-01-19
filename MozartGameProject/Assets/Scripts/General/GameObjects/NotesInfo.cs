using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class NotesInfo : ItemInfo
{
    public int noteNumber;
    public bool isWhite;
    public KeyCode keyCode;

    public void StartPlaying(ulong delay)
    {
        var noteAudio = item.GetComponent<AudioSource>();

        if (!IsPlaying())
        {
            noteAudio.Play(delay);
        }
    }

    public void StopPlaying()
    {
        var noteAudio = item.GetComponent<AudioSource>();

        if (IsPlaying())
        {
            noteAudio.Stop();
        }
    }

    bool IsPlaying()
    {
        var noteAudio = item.GetComponent<AudioSource>();
        return noteAudio.isPlaying;
    }
}
