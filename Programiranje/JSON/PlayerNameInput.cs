using System;
using TMPro;
using UnityEngine;

public class PlayerNameInput : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] TMP_InputField nameInputField;
    [SerializeField] TMP_InputField passwordInputField;
    [SerializeField] TMP_Text nameText;
    [SerializeField] GameObject playerNameInputPanel;
    
    [SerializeField] Transform nameTextTransform;
    [SerializeField] Transform cameraTransform;
    
    private string playerName;

    private void Start()
    {
        playerName = JsonSave.instance.GetName();
    }

    public void SetName()
    {
        if (string.IsNullOrEmpty(nameInputField.text) || string.IsNullOrEmpty(passwordInputField.text))
        {
            Debug.LogError("Name or password is empty");
            return;
        }

        else if(nameInputField.text == playerName && JsonSave.instance.CheckPassword(passwordInputField.text))
        {
            playerNameInputPanel.SetActive(false);
            nameText.text = playerName;
        }

        else
        {
            JsonSave.instance.SetName(nameInputField.text);
            JsonSave.instance.SetPassword(passwordInputField.text);
            playerNameInputPanel.SetActive(false);

            nameText.text = playerName;
        }
    }

    private void Update()
    {
        nameTextTransform.LookAt(cameraTransform);
    }
}






// Stvoriti novcice zadati i spremiti njihovu poziciju u save file direktno ili putem Play Mode-a
// Pozicije neka budu spremljene u obilku Array-a (Vector3[] coinPositions;)
















