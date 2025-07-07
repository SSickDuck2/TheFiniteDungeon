using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLevel : MonoBehaviour
{
    //level move zoned enter, if collider is a player and player pressed W => move to another level
    public void NextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int totalScenes = SceneManager.sceneCountInBuildSettings;
        int nextIndex = (currentIndex + 1) % totalScenes;
        SceneManager.LoadScene(nextIndex);
    }

}
