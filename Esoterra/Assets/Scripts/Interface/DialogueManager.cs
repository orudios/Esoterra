using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject dialogueUI;
    public Text displayNameText;
    public Text bodyText;
    public Button exitButton;
    public Button backButton;
    public Button nextButton;

    // Controls
    string exitKey = "x";
    string exitKeySecondary = "tab";
    string backKey = "b";
    KeyCode backKeySecondary = KeyCode.LeftArrow;
    string nextKey = "n";
    KeyCode nextKeySecondary = KeyCode.RightArrow;

    // Dialogue
    List<string> dialogueStrings;
    string displayName;
    int dialoguePosition;   
    string endString;

    // Disable during dialogue
    MouseLook playerMouseLook;
    PlayerMovement playerMovement;
    Image crosshair;


    void Awake()
    {
        exitButton.onClick.AddListener(delegate { ExitDialogue(); });
        backButton.onClick.AddListener(delegate { BackDialogue(); });
        nextButton.onClick.AddListener(delegate { NextDialogue(); });
        
        backButton.gameObject.SetActive(false);
        dialogueUI.SetActive(false);
    }

    void Start()
    {
        crosshair = GameObject.Find("Crosshair").GetComponent<Image>();
        playerMouseLook = Camera.main.GetComponent<MouseLook>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    void Update()
    {
        TryButtonClick();
    }

    // UI button clicks on key press
    void TryButtonClick()
    {
        if (Input.GetKeyDown(exitKey) || Input.GetKeyDown(exitKeySecondary)) {
            exitButton.onClick.Invoke();
        } else if (Input.GetKeyDown(backKey) || Input.GetKeyDown(backKeySecondary)) {
            backButton.onClick.Invoke();
        } else if (Input.GetKeyDown(nextKey) || Input.GetKeyDown(nextKeySecondary)) {
            nextButton.onClick.Invoke();
        }
    }

    public void AddNewDialogue(string name, string[] strings, string end)
    {
        dialoguePosition = 0;
        dialogueStrings = new List<string>(strings.Length);
        dialogueStrings.AddRange(strings);
        displayName = name;
        endString = end;
        SetUIElements();
    }

    void SetUIElements()
    {
        if (dialogueStrings.Count > 0) {
            displayNameText.text = displayName;
            bodyText.text = dialogueStrings[dialoguePosition];
            UpdateUIButtons();
            StartDialogue();
        }
    }

    void StartDialogue()
    {
        dialogueUI.SetActive(true);

        // Disable components during dialogue
        crosshair.enabled = false;
        playerMouseLook.enabled = false;
        playerMovement.enabled = false;
    }

    void ExitDialogue()
    {
        dialoguePosition = 0;
        dialogueUI.SetActive(false);

        // Re-enable components
        crosshair.enabled = true;
        playerMouseLook.enabled = true;
        playerMovement.enabled = true;
    }

    void NextDialogue()
    {
        if (dialoguePosition == dialogueStrings.Count-1) {
            // At the end of dialogue
            ExitDialogue();
        }
        else {
            dialoguePosition++;
            bodyText.text = dialogueStrings[dialoguePosition];
        }
        UpdateUIButtons();
    }

    void BackDialogue()
    {
        if (dialoguePosition != 0) {
            // Not at the start of dialogue
            dialoguePosition--;
            bodyText.text = dialogueStrings[dialoguePosition];
        }
        UpdateUIButtons();
    }
    
    void UpdateUIButtons()
    {
        // Back button visibility
        if (dialoguePosition == 0) {
            // Start of dialogue
            backButton.gameObject.SetActive(false);
        } else {
            backButton.gameObject.SetActive(true);
        }

        // Next button text
        if (dialoguePosition < dialogueStrings.Count-1) {
            // Not at the end of dialogue
            // Default string and colour
            nextButton.GetComponentInChildren<Text>().text = "Next [" + nextKey + "] >";
            nextButton.GetComponentInChildren<Text>().color = new Color32(0, 180, 255, 255);
        } else {
            // End string and lighter blue colour
            nextButton.GetComponentInChildren<Text>().text = endString + " [" + nextKey + "] >";
            nextButton.GetComponentInChildren<Text>().color = new Color32(0, 240, 255, 255);
        }
    }
}
