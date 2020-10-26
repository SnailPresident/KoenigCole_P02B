using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBall : MonoBehaviour
{
    [SerializeField] AudioClip HealSound = null;
    public float healAmount = 6;

    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement health = other.gameObject.GetComponent<PlayerMovement>();
        AudioHelper.PlayClip2D(HealSound, .25f);
        health.playerHealth += healAmount;
        this.gameObject.SetActive(false);
    }
}
