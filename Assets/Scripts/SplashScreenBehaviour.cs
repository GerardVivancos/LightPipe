using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("LoadNextScene", 2.5f);
    }

    // Update is called once per frame
    void Update() {
        RotateCameraAround();
    }

    private void RotateCameraAround() {
        transform.Rotate(Vector3.up, 5 * Time.deltaTime);
        transform.Rotate(Vector3.right, 1 * Time.deltaTime);
    }

    private void LoadNextScene() {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
