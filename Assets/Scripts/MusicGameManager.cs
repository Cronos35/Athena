using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicGameManager : MonoBehaviour
{
    [SerializeField] private readonly List<AudioClip> notePattern;
    [SerializeField] private readonly List<GameObject> noteIndicator;
    [SerializeField] private readonly List<GameObject> musicKeys;
    [SerializeField] private readonly float BPM;
    [SerializeField] private readonly List<float> noteValues;
    [SerializeField] private readonly GameObject playButton;

    private float interval;
    private readonly SpriteRenderer spriteRenderer;
    private AudioSource audioplayer;
    private readonly TouchControls touchControls;
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
        EnableTouchControls(false);

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
            EnableTouchControls(true);
            yield break;
        }

        for (int i = 0; i < musicKeys.Count; i++)
        {
            musicKeys[i].GetComponent<AudioPlayback>().PlayNoteOnStart();
            yield return new WaitForSeconds(1f);
        }

        EnableTouchControls(true);
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

    private void EnableTouchControls(bool enable)
    {
        playButton.GetComponent<TouchControls>().enabled = enable;

        for (int i = 0; i < musicKeys.Count; i++)
        {
            musicKeys[i].GetComponent<TouchControls>().enabled = enable;
        }

        playButton.transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y + 0.08f, 0f), transform.rotation);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(" ");
    }
}
