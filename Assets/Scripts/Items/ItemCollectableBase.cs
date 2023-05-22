using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    public string compareTag = "Player";
    public float timeToHide = 2f;
    public GameObject graphicItem;


    private void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    protected virtual void HideItems()
    {
        if (graphicItem != null) graphicItem.SetActive(false);
        Invoke(nameof(HideObject), timeToHide);
    }

    protected virtual void Collect()
    {
        HideItems();
        OnCollect();
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnCollect()
    {

    }
}
