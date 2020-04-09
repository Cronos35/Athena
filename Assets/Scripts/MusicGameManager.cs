using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicGameManager : MonoBehaviour
{
    [SerializeField] private List<AudioClip> notePattern;
    [SerializeField] private List<GameObject> noteIndicator;
    [SerializeField] private List<GameObject> musicKeys;
    [SerializeField] private float BPM;
    [SerializeField] private List<float> noteValues;
    [SerializeField] private GameObject playButton;

    private float interval;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioplayer;
    private TouchControls touchControls;
    private bool alreadyPlayed = false;
    private bool executionFinished;
    private int totalCorrectTaps = 0;
    private int score = 30;

    public static string noteName;
    // Start is called before the first frame update
    private void Awake()
    {
        executionFinished = false;
        interval = 60f / BPM;
        audioplayer = GetComponent<AudioSource>();
    }

    void Start()
    {
        KeyTapListener.currentListener.onKeyTap += CheckKeyTaps;
        KeyTapListener.currentListener.onPlayButtonPress += PlayNotePatternOnPress;
        StartCoroutine(PlayNotesOnStart(false));
    }

    private void CheckKeyTaps(string noteName)
    {
        if (totalCorrectTaps != notePattern.Count)
        {
            if (noteName == notePattern[totalCorrectTaps].name)
            {
                noteIndicator[totalCorrectTaps].GetComponent<ColorChanger>().ChangeColor(false, true);
                totalCorrectTaps++;
                return;
            }

            noteIndicator[totalCorrectTaps].GetComponent<ColorChanger>().ChangeColor(false, false);
            score--;

            return;
        }
    }

    private IEnumerator PlayNotesOnStart(bool playButtonPressed)
    {
        enableTouchControls(false);

        yield return new WaitForSeconds(0.25f);

        for (int i = 0; i < notePattern.Count; i++)
        {
            audioplayer.PlayOneShot(notePattern[i], 1f);
            noteIndicator[i].GetComponent<ColorChanger>().ChangeColor(false, true);
            NoteValuetoMS(noteValues[i]);
            yield return new WaitForSeconds(interval);
        }
        
        for (int i = 0; i < noteIndicator.Count; i++)
        {
            noteIndicator[i].GetComponent<ColorChanger>().ChangeColor(true, true);
        }

        if (playButtonPressed)
        {
            enableTouchControls(true);
            yield break;
        }

        for (int i = 0; i < musicKeys.Count; i++)
        {
            musicKeys[i].GetComponent<AudioPlayback>().PlayNoteOnStart();
            yield return new WaitForSeconds(1f);
        }

        enableTouchControls(true);
    }

    private void PlayNotePatternOnPress()
    {
        StartCoroutine(PlayNotesOnStart(true));
    }

    private void NoteValuetoMS(float noteValue)
    {
        switch (noteValue)
        {
            case 2:
                interval = (60f / BPM) * 2;
                break;

            case 4:
                interval = 60f / BPM;
                break;

            case 8:
                interval = (60f / BPM) / 2;
                break;

            case 16:
                interval = ((60f / BPM) / 2) / 2;
                break;
        }
    }

    private void enableTouchControls(bool enable)
    {
        playButton.GetComponent<TouchControls>().enabled = enable;

        for (int i = 0; i < musicKeys.Count; i++)
        {
            musicKeys[i].GetComponent<TouchControls>().enabled = enable;
        }

        playButton.transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y + 0.08f, 0f), transform.rotation);
    }
}
