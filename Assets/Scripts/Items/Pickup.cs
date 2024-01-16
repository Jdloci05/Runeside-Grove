using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour, Interactable
{
    #region Variables

    public ItemBase item;

    public bool Used { get; set; } = false;

    #endregion

    #region IEnumerators
    public virtual IEnumerator Interact(Transform initiator)
    {
        if (!Used)
        {
            initiator.GetComponent<Inventory>().AddItem(item);

            Used = true;

            gameObject.SetActive(false);

            string playerName = initiator.GetComponent<PlayerController>().Name;

            AudioManager.i.PlaySfx(AudioId.ItemObtained, pauseMusic: true);
            yield return DialogManager.Instance.ShowDialogText($"{playerName} found {item.Name}");
        }
    }

    #endregion
}
