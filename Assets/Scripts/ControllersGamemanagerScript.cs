using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllersGamemanagerScript : MonoBehaviour
{

    [SerializeField] private GameObject doorObject;
    private bool chessSocketEnabled = false;
    private bool consoleSocketEnabled = false;

    public void ChessSocketEnable()
    {
        chessSocketEnabled = true;
    }
    public void ChessSocketDissable()
    {
        chessSocketEnabled = false;
    }

    public void ConsoleSocketEnable()
    {
        consoleSocketEnabled = true;
    }
    public void ConsoleSocketDissable()
    {
        consoleSocketEnabled = false;
    }


    private void Update()
    {
        if(chessSocketEnabled && consoleSocketEnabled)
        {
            doorObject.SetActive(false);
        }
        else
        {
            doorObject.SetActive(true);
        }
    }
}
