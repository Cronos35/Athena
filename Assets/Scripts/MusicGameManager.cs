using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicGameManager : MonoBehaviour
{
    [SerializeField] private List<AudioClip> notePattern;
    [SerializeField] private List<AudioClip> keyClips;
    [SerializeField] private List<GameObject> noteIndicator;
    [SerializeField] private List<GameObject> musicKeys;

    private float interval;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioplayer;
    private TouchControls touchControls;
    private bool alreadyPlayed = false;
    private int totalKeyTaps = 0;
    private int score = 30;

    public static string noteName;
    // Start is called before the first frame update

    void Start()
    {
        KeyTapListener.currentListener.onKeyTap += CheckKeyTaps;
        
        interval = 1f;
        audioplayer = GetComponent<AudioSource>();
        //StartCoroutine(PlayNotePattern());
    }
        
    private void CheckKeyTaps(string noteName)
    {
        if (totalKeyTaps != 6)
        {
            if (noteName == notePattern[totalKeyTaps].name)
            {
                noteIndicator[totalKeyTaps].GetComponent<ColorChanger>().ChangeColor(false, true);
                totalKeyTaps++;
                return;
            }
        }
        else
        {

        }

        noteIndicator[totalKeyTaps].GetComponent<ColorChanger>().ChangeColor(false, false);
        score--;
    }

    private IEnumerator PlayNotePattern()
    {
        enableTouchControls(false);
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < notePattern.Count; i++)
        {
            audioplayer.PlayOneShot(notePattern[i], 1f);
            noteIndicator[i].GetComponent<ColorChanger>().ChangeColor(false, true);
            yield return new WaitForSeconds(interval);
        }

        for (int i = 0; i < noteIndicator.Count; i++)
        {
            noteIndicator[i].GetComponent<ColorChanger>().ChangeColor(true, true);
        }

        for (int i = 0; i < keyClips.Count; i++)
        {
            musicKeys[i].GetComponent<AudioPlayback>().PlayNoteOnStart();
            yield return new WaitForSeconds(1f);
        }

        enableTouchControls(true);
    }

    private void enableTouchControls(bool enable)
    {
        for (int i = 0; i < musicKeys.Count; i++)
        {
            musicKeys[i].GetComponent<TouchControls>().enabled = enable;
        }
    }
}
