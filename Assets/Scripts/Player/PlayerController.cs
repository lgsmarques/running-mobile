using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;

    public float speed = 1;
    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEndLine = "EndLine";
    public GameObject startScreen;
    public TextMeshProUGUI startScreenText;
    public LoadSceneHelper loadSceneHeloper;

    private bool _canRun;
    private Vector3 _pos;

    private void Start()
    {
        startScreen.SetActive(true);
    }

    void Update()
    {
        if (!_canRun) return;

        _pos.Set(target.position.x, transform.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(speed * Time.deltaTime * transform.forward);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag(tagToCheckEnemy))
        {
            EndGame();
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
}
