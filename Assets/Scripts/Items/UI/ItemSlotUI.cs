using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    #region Variables

    [SerializeField] Text nameText;
    [SerializeField] Text countText;

    RectTransform rectTransform;

    #endregion

    #region Methods
    private void Awake()
    {
        
    }

    public Text NameText => nameText;
    public Text CountText => countText;

    public float Height => rectTransform.rect.height;

    public void SetData(ItemSlot itemSlot)
    {
        rectTransform = GetComponent<RectTransform>();
        nameText.text = itemSlot.Item.Name;
        countText.text = $"X {itemSlot.Count}";
    }

    #endregion
}
