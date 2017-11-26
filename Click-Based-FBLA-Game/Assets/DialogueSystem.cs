using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public GameObject DialoguePanel;
    public string npcName;
    public static DialogueSystem Instance {get; set;}
    public List<string> dialogueLines = new List<string>();

    public Button ContinueButton;
    public Text dialogueText;
    public Text nameText;
    int dialogueIndex;

	// Use this for initialization
	void Awake ()
    {
        ContinueButton = DialoguePanel.transform.FindChild("Continue").GetComponent<Button>();
        dialogueText = DialoguePanel.transform.FindChild("Text").GetComponent<Text>();
        nameText = DialoguePanel.transform.FindChild("Name").GetChild(0).GetComponent<Text>();
        ContinueButton.onClick.AddListener(delegate { ContinueDialogue(); });
        DialoguePanel.SetActive(false);


        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
	}

    public void AddNewDialogue(string[] lines, string npcName)
    {
        dialogueIndex = 0;
        dialogueLines = new List<string>(lines.Length);
        dialogueLines.AddRange(lines);
        this.npcName = npcName;
        CreateDialogue();
    }

    public void CreateDialogue()
    {
        dialogueText.text = dialogueLines[dialogueIndex];
        nameText.text = npcName;
        DialoguePanel.SetActive(true);
    }

    public void ContinueDialogue()
    {
        if (dialogueIndex < dialogueLines.Count - 1)
        {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];
        }
        else
        {
            DialoguePanel.SetActive(false);
        }
        
    }
}
