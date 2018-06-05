using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    private int score = 0;
    private Text scoreText;

	// Use this for initialization
	void Start () {
        scoreText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = score.ToString();
	}

    public void IncreaseScore(int increment) {
        score += increment;
    }


}
