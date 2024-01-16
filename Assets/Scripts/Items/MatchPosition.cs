using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchPosition : MonoBehaviour
{
    #region Variables

    public Transform target;  // El objeto cuya posición seguirá este objeto

    #endregion

    #region Methods
    void Update()
    {
        if (target != null)
        {
            // Asigna la posición del objeto objetivo a este objeto
            transform.position = target.position;
        }
    }

    #endregion

}
