using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollisionHandler : MonoBehaviour {

    [Tooltip("A GameObject that will be called SetActive(true) on")]
    public GameObject explosionFX;

    [SerializeField]
    [Range(0f, 10f)]
    [Tooltip("In seconds")]
    float levelReloadDelay = 2f;

    private void OnTriggerEnter(Collider other) {
        StartDeathSequence();
    }

    private void StartDeathSequence() {
        SendMessage("DisablePlayerMovement");
        TriggerExplosion();
        SendMessageUpwards("ReloadCurrentSceneWithDelay", levelReloadDelay);
    }

    private void TriggerExplosion() {
        if (explosionFX != null) {
            explosionFX.SetActive(true);
        }
    }

}
