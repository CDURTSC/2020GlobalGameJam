using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterManager : MonoBehaviour
{
    private float timeForLevel;
    private LevelData newLevelData;

    public delegate void AnimationTime();
    public static event AnimationTime AnimationTimeChange;

    public delegate void Timer();
    public static event Timer StartLevelTimer;

    //Button Action to start the game
    public void ActionButton_Start()
    {
        StartCoroutine(TimeChangedScene());
    }

    //Button Action to quit the game
    public void ActionButton_Quit()
    {
        Application.Quit();
    }

    //Button Action to return to main menu
    public void ActionButton_MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    //Timer to delay scene change based on animation length
    IEnumerator TimeChangedScene()
    {
        //Play some kind of animation here
        yield return new WaitForSeconds(1.5f);

        // call the event
        AnimationTimeChange();
    }

    //Overall level timer before next level is loaded
    IEnumerator LevelTimer()
    {
        while (timeForLevel > 0)
        {
            yield return new WaitForSeconds(1f);
            timeForLevel -= 1f;
            Debug.Log("Time left: " + (int)timeForLevel);
        }
        AnimationTimeChange();
    }

    void StartTimer()
    {
        StartCoroutine(LevelTimer());
    }

    void ChangeScene()
    {
        SceneManager.LoadSceneAsync(Random.Range(1,SceneManager.sceneCount));
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        newLevelData = GameObject.Find("LevelData").GetComponent<LevelData>();
        if (newLevelData!= null)
            timeForLevel = newLevelData.levelTime;
        if (SceneManager.GetActiveScene().name != "MainMenu")
            StartLevelTimer();
    }

    void OnEnable()
    {
        DontDestroyOnLoad(gameObject);
        MasterManager.AnimationTimeChange += ChangeScene;
        SceneManager.sceneLoaded += OnSceneLoaded;
        MasterManager.StartLevelTimer += StartTimer;
    }

    void OnDisable()
    {
        MasterManager.AnimationTimeChange -= ChangeScene;
        SceneManager.sceneLoaded -= OnSceneLoaded;
        MasterManager.StartLevelTimer -= StartTimer;
    }
}
