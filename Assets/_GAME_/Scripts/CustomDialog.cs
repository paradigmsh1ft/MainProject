using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class DialogLine
{
    public string characterName;
    [TextArea(5, 10)]
    public string line;
}

[System.Serializable]
public class Dialog
{
    public List<DialogLine> dialogLines = new List<DialogLine>();
}

public class CustomDialog : MonoBehaviour
{
    public Dialog dialog; 
    public void StartDialog()
    {
        DialogManager.Instance.StartDialog(dialog);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            StartDialog();
        }

    }
}
