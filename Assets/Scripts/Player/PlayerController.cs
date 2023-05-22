using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Core.Singleton;
using DG.Tweening;

public class PlayerController : Singleton<PlayerController>
{
    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;

    [Header("Start Screen")]
    public GameObject startScreen;
    public TextMeshProUGUI startScreenText;
    public LoadSceneHelper loadSceneHeloper;

    [Header("Default")]
    public float defaultSpeed = 1;
    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEndLine = "EndLine";
    public GameObject coinCollector;

    private bool _canRun;
    private Vector3 _pos;
    private float _currentSpeed;
    private bool _invincible;
    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
        startScreen.SetActive(true);
        ResetAllPowerUps();
    }

    void Update()
    {
        if (!_canRun) return;

        _pos.Set(target.position.x, transform.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(_currentSpeed * Time.deltaTime * transform.forward);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag(tagToCheckEnemy))
        {
            if(!_invincible) EndGame();
            if (_invincible) collision.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag(tagToCheckEndLine))
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        _canRun = false;
        loadSceneHeloper.Load(0);
        startScreenText.text = "Restart";
        startScreen.SetActive(true);
    }

    public void StartToRun()
    {
        _canRun = true;
    }

    #region
    public void SetInvincible(bool invincible)
    {
        _invincible = invincible;
    }

    public void SetSpeed(float newSpeed)
    {
        _currentSpeed = newSpeed;
    }

    public void SetHeight(float newHeight, Ease ease)
    {
        transform.DOMoveY(transform.position.y + newHeight, .5f).SetEase(ease);
    }

    public void ChangeCoinCollectorSize(float newSize = 1)
    {
        coinCollector.transform.localScale = Vector3.one * newSize;
    }

    public void ResetAllPowerUps()
    {
        SetInvincible(false);
        SetSpeed(defaultSpeed);
        transform.position = _startPosition;
    }
    #endregion
}
