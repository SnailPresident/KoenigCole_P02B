﻿using System;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] Transform _target = null;
    [SerializeField] float _targetingDistance = 20f;
    public event Action TargetFound = delegate { };
    public event Action TargetLost = delegate { };
    public GameObject enemy;
    [SerializeField] AudioClip deathSound = null;
    public Level01Controller level;
   
    public void Die()
    {
        AudioHelper.PlayClip2D(deathSound, .25f);
        level.IncreaseScore(5);
        enemy.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (TargetIsClose())
        {
            transform.LookAt(_target);
            TargetFound?.Invoke();
        }
        else
        {
            TargetLost?.Invoke();
        }
    }

    private bool TargetIsClose()
    {
        float currentDistance = Vector3.Distance(_target.position, transform.position);
        if (currentDistance < _targetingDistance)
        {
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
