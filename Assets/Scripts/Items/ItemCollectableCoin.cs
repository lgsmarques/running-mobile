using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableCoin : ItemCollectableBase
{
    public int amount = 1;
    public bool collect = false;
    public float lerp = 5f;
    public float minDistance = 1f;

    protected override void Collect()
    {
        OnCollect();
    }

    protected override void OnCollect()
    {
        base.OnCollect();
        collect = true;
        //ItemManager.Instance.AddCoins(amount);
    }
    private void Update()
    {
        if(collect)
        {
            transform.position = Vector3.Lerp(transform.position, PlayerController.Instance.transform.position, lerp * Time.deltaTime);

            if (Vector3.Distance(transform.position, PlayerController.Instance.transform.position) < minDistance)
            {
                HideItems();
                Destroy(gameObject);
            }
        }
    }
}
