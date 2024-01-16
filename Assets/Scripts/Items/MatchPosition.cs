using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchPosition : MonoBehaviour
{
    #region Variables

    public Transform target;  // El objeto cuya posici�n seguir� este objeto

    #endregion

    #region Methods
    void Update()
    {
        if (target != null)
        {
            // Asigna la posici�n del objeto objetivo a este objeto
            transform.position = target.position;
        }
    }

    #endregion

}
