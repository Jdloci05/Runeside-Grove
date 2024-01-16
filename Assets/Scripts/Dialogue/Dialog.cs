using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog
{
    #region Variables
    [SerializeField] List<string> lines;
    #endregion

    #region Methods
    public List<string> Lines
    {
        get { return lines; }
    }

    #endregion
}
