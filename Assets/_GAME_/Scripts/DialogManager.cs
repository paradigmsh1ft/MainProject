using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogBar;
    public static DialogManager Instance;
    public TextMeshProUGUI dialogArea; 

    public bool isDialogActive = false;
    public float dialogSpeed = 0.3f;

    private Queue<DialogLine> lines;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        lines = new Queue<DialogLine>();

        dialogBar.SetActive(false);     
    }

    private void Update()
    {
        if (isDialogActive && Input.GetKeyDown(KeyCode.Space)) 
        {
            ShowNextDialogLine(); 
        }

    }
    public void StartDialog(Dialog dialog)
    {
        isDialogActive = true;
        
        dialogBar.SetActive(true);

        lines.Clear();

        foreach (DialogLine dialogLine in dialog.dialogLines)
        {
            lines.Enqueue(dialogLine);
        }

        if (lines.Count > 0)
        {
            DialogLine firstLine = lines.Dequeue();
            dialogArea.text = firstLine.line; 
            StartCoroutine(TypeSentence(firstLine)); 
        }
    }  
    
    public void ShowNextDialogLine()
    {
        if (lines.Count == 0)
        {
            EndDialog();
            return;
        }  
        DialogLine currentLine = lines.Dequeue();
     
        StopAllCoroutines();

        StartCoroutine(TypeSentence(currentLine));
    }
    
    void EndDialog()
    {
        isDialogActive = false;              
        dialogBar.SetActive(false);         
    }

    IEnumerator TypeSentence(DialogLine dialogLine)
    {
        dialogArea.text = " ";

        foreach (char letter in dialogLine.line.ToCharArray())
        {
            dialogArea.text += letter;
            yield return new WaitForSeconds(dialogSpeed);
        }
    }
}