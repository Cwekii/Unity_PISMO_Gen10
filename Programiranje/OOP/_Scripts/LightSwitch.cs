
using System;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightSwitch : MonoBehaviour, IInteractable
{
    Light light;
    
    bool hasInteracted = false;
    private void Awake()
    {
        light = GetComponent<Light>();
    }

    private void Start()
    {
        light.type = LightType.Point;
        light.intensity = 0;
    }

    private void Update()
    {
        if (hasInteracted)
        {
            light.intensity = Mathf.Lerp(0, 5000, 0.2f);
            
        }
    }

    public void Interact()
    {
        hasInteracted = true;
    }

   
}
