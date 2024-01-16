using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLayers : MonoBehaviour
{
    #region Variables

    [SerializeField] LayerMask longGrassLayer;
    [SerializeField] LayerMask solidObjectsLayer;
    [SerializeField] LayerMask interactableLayer;
    [SerializeField] LayerMask destroyinteracteable;
    [SerializeField] LayerMask playerLayer;

    public static GameLayers i { get; set; }

    #endregion

    #region Methods
    private void Awake()
    {
        i = this;
    }

    public LayerMask SolidLayer
    {
        get => solidObjectsLayer;
    }

    public LayerMask InteractableLayer
    {
        get => interactableLayer;
    }

    public LayerMask GrassLayer
    {
        get => longGrassLayer;
    }

    public LayerMask PlayerLayer
    {
        get => playerLayer;
    }

    public LayerMask Destroyinteracteable
    {
        get => destroyinteracteable;
    }

    #endregion

}
