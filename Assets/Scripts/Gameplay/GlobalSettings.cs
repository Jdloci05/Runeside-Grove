using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSettings : MonoBehaviour
{
    #region Variables

    [SerializeField] Color highlightedColor;

    public Color HighlightedColor => highlightedColor;

    public static GlobalSettings i { get; private set; }
    #endregion

    #region Methods
    private void Awake()
    {
        i = this;
    }

    #endregion
}
