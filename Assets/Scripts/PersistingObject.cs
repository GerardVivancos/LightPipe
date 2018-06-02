using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistingObject : MonoBehaviour {

    [Tooltip("If checked, the object will destroy itself if there's another PersistingObject with the same singletonID")]
    [SerializeField] bool singleton = false;

    [Tooltip("String to check for singleton compliance")]
    [SerializeField] string singletonId = "";

	// Use this for initialization
	void Awake() {
        if (singleton && NumberOfObjectsLikeThisOne() > 1) {
            GameObject.Destroy(gameObject);
        } else {
            GameObject.DontDestroyOnLoad(gameObject);
        }
	}	

    private int NumberOfObjectsLikeThisOne() {
        PersistingObject[] persistingObjects =  FindObjectsOfType<PersistingObject>();
        int numberOfObjectsWithTheSameId = 0;
        foreach (PersistingObject po in persistingObjects) {
            if (po.singletonId == singletonId) {
                numberOfObjectsWithTheSameId++;
            }
        }

        return numberOfObjectsWithTheSameId;
    }
}
