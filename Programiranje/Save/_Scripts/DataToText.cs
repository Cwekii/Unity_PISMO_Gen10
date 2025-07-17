using System;
using UnityEngine;
using TMPro;

public class DataToText : MonoBehaviour
{
    [SerializeField] private TMP_Text text;


    private void Start()
    {
        // ispis texta
        text.text = String.Empty;
    }
}