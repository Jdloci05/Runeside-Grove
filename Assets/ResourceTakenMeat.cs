using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceTakenMeat : ResourceTaken
{
    public override void Final()
    {
        gameObject.SetActive(false);
        pickup.GetComponent<SpriteRenderer>().enabled = true;
    }
}
