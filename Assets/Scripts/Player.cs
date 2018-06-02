using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [SerializeField]
    [Range(0f,100f)]
    [Tooltip("In m/s")]
    float xSpeed = 1f;

    [SerializeField]
    [Range(0f, 100f)]
    [Tooltip("In m/s")]
    float ySpeed = 1f;

    [SerializeField]
    [Range(0f, 50f)]
    [Tooltip("In m")]
    float xRangeMax = 2f;

    [SerializeField]
    [Range(0f, 50f)]
    [Tooltip("In m")]
    float yRangeMax = 2f;

    [SerializeField]
    [Range(0f, 50f)]
    [Tooltip("In m")]
    float yRangeMin = 1f;

    [SerializeField]
    float pitchByVerticalPositionFactor = -6f;

    [SerializeField]
    float pitchByVerticalMovementFactor = -20f;

    [SerializeField]
    float yawByHorizontalPositionFactor = 5f;

    [SerializeField]
    float rollByHorizontalMovementFactor = -20f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MoveShip();
        RotateShip();
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

    private void RotateShip() {

        float pitch = 0f;
        float yaw = 0f;
        float roll = 0f;

        float pitchByVerticalPosition = transform.localPosition.y * pitchByVerticalPositionFactor;
        float pitchByVerticalMovement = CrossPlatformInputManager.GetAxis("Vertical") * pitchByVerticalMovementFactor;
        pitch = pitchByVerticalPosition + pitchByVerticalMovement;

        float yawByHorizontalPosition = transform.localPosition.x * yawByHorizontalPositionFactor;
        yaw = yawByHorizontalPosition;

        float rollByHorizontalMovement = CrossPlatformInputManager.GetAxis("Horizontal") * rollByHorizontalMovementFactor;
        roll = rollByHorizontalMovement;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void OnTriggerEnter(Collider other) {
        print("Triggered");
    }
}
