using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class NotesInfo : ItemInfo
{
    public int noteNumber;
    public bool isWhite;
    public KeyCode keyCode;

    public KeyCode GetNoteKeyCode()
    {
        return keyCode;
    }

    public void StartPlaying(ulong delay)
    {
        var noteAudio = item.GetComponent<AudioSource>();
        if (!IsPlaying())
        {
            
            Debug.Log("clip playing: " + noteAudio.isPlaying);
            Debug.Log("source " + noteAudio.enabled + 
                      "clip " + noteAudio.clip.length);
            StopPlaying();
        }
    }

    public void StopPlaying()
    {
        var noteAudio = gameObject.GetComponent<AudioSource>();

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
