using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    const string MainMenu = "MainMenu";

    [SerializeField] private SceneFader _sceneFader;
    [SerializeField] private string _nextLevel;
    [SerializeField] private int _levelToUnlock;

    public void OnMenu()
    {
        _sceneFader.FadeTo(MainMenu);
    }

    public void OnContinue()
    {
        PlayerPrefs.SetInt("levelReached", _levelToUnlock);
        _sceneFader.FadeTo(_nextLevel);
    }

}
