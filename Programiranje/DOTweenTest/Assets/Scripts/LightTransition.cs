using DG.Tweening;
using UnityEngine;

public class LightTransition : MonoBehaviour
{
    [SerializeField] Light[] lights;

    public void ChangeLightColor()
    {
        foreach (Light light in lights)
        {
            if (light.color == Color.blue)
            {
                light.DOColor(Color.red, 1f);
                light.DOIntensity(0.5f, 1);
            }


            else
            {
                light.DOColor(Color.blue, 1f);
                light.DOIntensity(1.5f, 1);
            }
        }
    }
}
