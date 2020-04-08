using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayback : MonoBehaviour
{
    [SerializeField] private AudioClip audioToPlay;
    [SerializeField] private float volume;
    private AudioSource audio;
    private TouchControls touchControls;
    private float yPosition;
    private MusicGameManager musicGameManager;

    public bool alreadyPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        touchControls = gameObject.GetComponent<TouchControls>();
        yPosition = transform.position.y;
        TouchEvents.touchListener.onTouch += PressKey;
    }

    private void Update()
    {
        if (touchControls.isTouched())
        {
            PressKey();
            return;
        }

        alreadyPlayed = false;
        transform.SetPositionAndRotation(new Vector3(transform.position.x, yPosition, 0f), transform.rotation);
    }

    public float GetyPosition()
    {
        return yPosition;
    }

    public void PlayNoteOnStart()
    {
        transform.SetPositionAndRotation(new Vector3(transform.position.x, yPosition - 0.08f, 0f), transform.rotation);

        if (!alreadyPlayed)
        {
            audio.PlayOneShot(audioToPlay, volume);
            alreadyPlayed = true;
        }
    }

    public void PressKey()
    {
        if (!alreadyPlayed)
        {
            alreadyPlayed = true;
            transform.SetPositionAndRotation(new Vector3(transform.position.x, yPosition - 0.08f, 0f), transform.rotation);
            audio.PlayOneShot(audioToPlay, volume);

            KeyTapListener.currentListener.sendKeyTap(audioToPlay.name);
            return;
        }

        alreadyPlayed = false;
    }
}
