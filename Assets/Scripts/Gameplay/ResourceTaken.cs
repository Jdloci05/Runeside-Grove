using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ResourceTaken : MonoBehaviour, DestroyInteractable
{
    public GameObject pickup;
    public RuntimeAnimatorController newAnimatorController;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public IEnumerator Destroyinteracteable(Transform initiator)
    {
        animator.runtimeAnimatorController = newAnimatorController;
        Invoke("Final",0.30f);
        yield return null;
    }
    
    public void Final()
    {
        Destroy(gameObject);
        pickup.SetActive(true);
    }
}
