using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] GameObject explosionFX;
    [SerializeField] float speedMultiplier = 1f;
    [SerializeField] float lifetimeMultiplier = 1f;

    private void Start() {
        AddNonTriggerBoxCollider();
    }

    private void AddNonTriggerBoxCollider() {
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other) {
        if (explosionFX != null) {
            GameObject fx = Instantiate(explosionFX, gameObject.transform.position, Quaternion.identity);
            fx.transform.parent = GameObject.Find("RuntimeSpawnedObjects").transform;
            if (fx.GetComponent<ParticleSystem>() != null) {
                var particleSystem = fx.GetComponent<ParticleSystem>().main;
                particleSystem.startSpeedMultiplier = speedMultiplier;
                particleSystem.startLifetimeMultiplier = lifetimeMultiplier;
                particleSystem.stopAction = ParticleSystemStopAction.Destroy;
            }
        }
        GameObject.Destroy(gameObject);
    }
}
