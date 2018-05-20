using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [SerializeField]
    [Range(0f,4f)]
    [Tooltip("In m/s")]
    float xSpeed = 1f;

    [SerializeField]
    [Range(0f, 4f)]
    [Tooltip("In m/s")]
    float ySpeed = 1f;

    [SerializeField]
    [Range(0f, 4f)]
    [Tooltip("In m")]
    float xRangeMax = 2f;

    [SerializeField]
    [Range(0f, 4f)]
    [Tooltip("In m")]
    float yRangeMax = 2f;

    [SerializeField]
    [Range(0f, 4f)]
    [Tooltip("In m")]
    float yRangeMin = 1f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MoveShip();
    }

    private void MoveShip() {
        float xInput = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xInput * xSpeed * Time.deltaTime;
        float xNewLocalPosition = Mathf.Clamp(transform.localPosition.x + xOffset, -xRangeMax, xRangeMax);

        float yInput = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yInput * ySpeed * Time.deltaTime;
        float yNewLocalPosition = Mathf.Clamp(transform.localPosition.y + yOffset, -yRangeMin, yRangeMax);

        float zNewlocalPosition = transform.localPosition.z;

        Vector3 newLocalPosition = new Vector3(xNewLocalPosition, yNewLocalPosition, zNewlocalPosition);
        transform.localPosition = newLocalPosition;
    }
}
