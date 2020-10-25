using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(EnemyScript))]

public class EnemyFire : MonoBehaviour
{
    [SerializeField] GameObject _projectile = null;
    [SerializeField] Transform _shotOrigin = null;
    [SerializeField] float _firingDelaySeconds = 3f;
    private EnemyScript enemyScript = null;

    [SerializeField] ParticleSystem _shotParticle = null;
    [SerializeField] AudioClip _shotAudio = null;

    Coroutine _firingCoroutine = null;

    private void Awake()
    {
        enemyScript = GetComponent<EnemyScript>();
    }

    private void OnEnable()
    {
        enemyScript.TargetFound += OnTargetFound;
        enemyScript.TargetLost += OnTargetLost;
    }

    private void OnDisable()
    {
        enemyScript.TargetFound -= OnTargetFound;
        enemyScript.TargetLost -= OnTargetLost;
    }

    private void OnTargetFound()
    {
        if (_firingCoroutine == null)
        {
            _firingCoroutine = StartCoroutine(FiringDelay(_firingDelaySeconds));
        }
    }

    private void OnTargetLost()
    {
        if (_firingCoroutine != null)
        {
            StopCoroutine(_firingCoroutine);
            _firingCoroutine = null;
        }
    }

    IEnumerator FiringDelay(float delayInSeconds)
    {
        FireShot();
        yield return new WaitForSeconds(delayInSeconds);
        _firingCoroutine = null;
    }

    private void FireShot()
    {
        Debug.Log("Firing!");
        Instantiate(_projectile, _shotOrigin.transform.position, _shotOrigin.transform.rotation) ;
        PlayShotSound();
        PlayShotParticle();
    }

    public void PlayShotSound()
    {
        //AudioHelper.PlayClip2D(_shotAudio, .25f);
    }

    public void PlayShotParticle()
    {
       // _shotParticle.Play();
    }
}
