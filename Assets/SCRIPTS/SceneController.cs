using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    public GameObject TransitionContainer;
    private SceneTransition[] transitions;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        transitions = TransitionContainer.GetComponentsInChildren<SceneTransition>();
    }

    public void LoadScene(int sceneNumber, string transitionName)
    {
        StartCoroutine(LoadSceneAsync(sceneNumber, transitionName));
    }

    public void NextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int totalScenes = SceneManager.sceneCountInBuildSettings;
        int nextIndex = (currentIndex + 1) % totalScenes; // Tự động quay về 0 nếu đang ở cuối

        // Load bằng phương thức riêng vì bạn có hiệu ứng CrossFade
        LoadScene(nextIndex, "CrossFade");
    }

    private IEnumerator LoadSceneAsync(int sceneNumber, string transitionName)
    {
        SceneTransition transition = transitions.First(x => x.name == transitionName); //work as For Loop
        AsyncOperation scene = SceneManager.LoadSceneAsync(sceneNumber); //luu cung voi x o tren
        scene.allowSceneActivation = false;
        yield return transition.AnimateTransitionIn();
    
        scene.allowSceneActivation = true;
        yield return transition.AnimateTransitionOut();
    }
    
    
}
