using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupMeat : Pickup
{
    #region IEnumerators
    public override IEnumerator Interact(Transform initiator)
    {
        if (!Used)
        {
            initiator.GetComponent<Inventory>().AddItem(item);

            Used = true;

            gameObject.SetActive(false);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;

            string playerName = initiator.GetComponent<PlayerController>().Name;

            AudioManager.i.PlaySfx(AudioId.ItemObtained, pauseMusic: true);
            yield return DialogManager.Instance.ShowDialogText($"{playerName} found {item.Name}");
        }
    }

    #endregion
}
