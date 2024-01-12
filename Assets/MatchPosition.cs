using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchPosition : MonoBehaviour
{
    public Transform target;  // El objeto cuya posición seguirá este objeto

    void Update()
    {
        if (target != null)
        {
            // Asigna la posición del objeto objetivo a este objeto
            transform.position = target.position;
        }
    }

}
