using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Vjezbe2 : MonoBehaviour
{
    [Header("Panel references")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject optionsPanel;
     [Header("UI references")] [SerializeField]
     private Sprite[] toggleSprites;
     
    [SerializeField] private GameObject volume;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Image inputToggle;
    [SerializeField] private TMP_Text volumeText;

    private void Start()
    {
        volumeSlider.value = volumeSlider.maxValue;
        volumeText.text = $"{volumeSlider.value}%";
        inputToggle.sprite = toggleSprites[0];
    }

    private void Update()
    {
        volumeText.text = $"{volumeSlider.value}%";
    }

    public void OptionsPanel()
    {
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void ToggleInput(Toggle isActive)
    {
        volume.SetActive(isActive.isOn);
        if (isActive.isOn)
        {
            inputToggle.sprite = toggleSprites[0];
        }
        else
        {
            inputToggle.sprite = toggleSprites[1];
        }
    }
}
