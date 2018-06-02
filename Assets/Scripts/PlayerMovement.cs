using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement: MonoBehaviour {

    [Header("Speed")]
    [SerializeField]
    [Range(0f,100f)]
    [Tooltip("In m/s")]
    float xSpeed = 20f;

    [SerializeField]
    [Range(0f, 100f)]
    [Tooltip("In m/s")]
    float ySpeed = 16f;

    [Header("Range")]
    [SerializeField]
    [Range(0f, 50f)]
    [Tooltip("In m")]
    float xRangeMax = 9f;

    [SerializeField]
    [Range(0f, 50f)]
    [Tooltip("In m")]
    float yRangeMax = 5f;

    [SerializeField]
    [Range(0f, 50f)]
    [Tooltip("In m")]
    float yRangeMin = 5f;

    [Header("Pitch")]
    [SerializeField]
    float pitchByVerticalPositionFactor = -6f;
    [SerializeField]
    float pitchByVerticalMovementFactor = -20f;

    [Header("Yaw")]
    [SerializeField]
    float yawByHorizontalPositionFactor = 5f;

    [Header("Roll")]
    [SerializeField]
    float rollByHorizontalMovementFactor = -30f;

    bool isMovementEnabled = true;
	
	// Update is called once per frame
	void Update () {
        if (isMovementEnabled) {
            MoveShip();
            RotateShip();
        }
    }

    // Possibly called via string reference, be careful if you have to rename this
    public void EnablePlayerMovement() {
        isMovementEnabled = true;
    }

    // Possibly called via string reference, be careful if you have to rename this
    public void DisablePlayerMovement() {
        isMovementEnabled = false;
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
}
