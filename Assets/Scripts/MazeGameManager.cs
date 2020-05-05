﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeGameManager : MonoBehaviour
{
    [SerializeField] private readonly int score;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private AssessmentManager assessmentManager;

    private Intelligences gameIntelligence = Intelligences.VisualSpatial;
    private float countDown = 30;
    // Start is called before the first frame update
    void Start()
    {
        MazeEvents.mazeEventsListener.OnReachedMazeEnd += ShowGameEndScreen;
    }

    // Update is called once per frame

    private IEnumerator CountDowntimer()
    {
        countDown--;
        yield return new WaitForSeconds(1f);
    }

    private void ShowGameEndScreen()
    {
        nextButton.SetActive(true);
    }

    public void LoadNextLevel()
    {
        assessmentManager.IntelligencesScored[gameIntelligence] = score;
        assessmentManager.LoadGame();
    }
}
