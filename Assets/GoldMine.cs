using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldMine : MonoBehaviour, DestroyInteractable
{
    public GameObject pickup;
    public Sprite newSprite;
    public GameObject money;
    SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public IEnumerator Destroyinteracteable(Transform initiator)
    {
        Invoke("Destroyed", 0.35f);
        yield return null;
    }

    public void Destroyed()
    {
        sprite.sprite = newSprite;
        money.SetActive(true);
        Invoke("Final", 0.30f);
    }

    public virtual void Final()
    {
        money.SetActive(false);
        pickup.SetActive(true);
    }
}
