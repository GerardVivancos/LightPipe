using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    // Most of the methods on this class are possibly called via string reference, be careful if you have to rename this

    void ReloadCurrentScene () {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void ReloadCurrentSceneWithDelay (float delay) {
        Invoke("ReloadCurrentScene", delay);
    }
}
