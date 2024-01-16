using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Interactable 
{
    #region Inumerators
    IEnumerator Interact(Transform initiator);

    #endregion
}
