using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldMine : MonoBehaviour, DestroyInteractable
{
    #region Variables

    public GameObject pickup;
    public Sprite newSprite;
    public GameObject money;
    SpriteRenderer sprite;

    #endregion

    #region Methods
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    #region Inumerators
    public IEnumerator Destroyinteracteable(Transform initiator)
    {
        Invoke("Destroyed", 0.35f);
        yield return null;
    }

    #endregion

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

    #endregion
}
