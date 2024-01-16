using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ResourceTaken : MonoBehaviour, DestroyInteractable
{
    #region Variables

    public GameObject pickup;
    public RuntimeAnimatorController newAnimatorController;
    Animator animator;

    #endregion

    #region Methods
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    #region IEnumerators
    public IEnumerator Destroyinteracteable(Transform initiator)
    {
        Invoke("Destroyed", 0.35f);
        yield return null;
    }

    #endregion

    public void Destroyed()
    {
        animator.runtimeAnimatorController = newAnimatorController;
        Invoke("Final", 0.30f);
    }

    public virtual void Final()
    {
        gameObject.SetActive(false);
        pickup.SetActive(true);
    }

    #endregion
}
