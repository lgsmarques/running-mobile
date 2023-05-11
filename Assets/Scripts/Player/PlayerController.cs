using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Core.Singleton;

public class PlayerController : Singleton<PlayerController>
{
    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;

    public float defaultSpeed = 1;
    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEndLine = "EndLine";
    public GameObject startScreen;
    public TextMeshProUGUI startScreenText;
    public LoadSceneHelper loadSceneHeloper;

    private bool _canRun;
    private Vector3 _pos;
    private float _currentSpeed;
    private bool _invincible;

    private void Start()
    {
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
    public void PowerUpInvincible()
    {
        _invincible = true;
    }

    public void ResetInvincible()
    {
        _invincible = false;
    }

    public void PowerUpSpeedUp(float newSpeed)
    {
        _currentSpeed = newSpeed;
    }

    public void ResetSpeed()
    {
        _currentSpeed = defaultSpeed;
    }

    public void ResetAllPowerUps()
    {
        ResetInvincible();
        ResetSpeed();
    }
    #endregion
}
