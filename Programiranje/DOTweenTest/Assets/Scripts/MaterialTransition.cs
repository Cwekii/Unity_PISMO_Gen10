using DG.Tweening;
using UnityEngine;

public class MaterialTransition : MonoBehaviour
{
    [SerializeField] Material m_Material;

    public void ChangeColor()
    {
        if (m_Material.color == Color.blue)
        {
            m_Material.DOColor(Color.red, "_EmissionColor", 1f);
            m_Material.DOColor(Color.red, 1f);
        }
       

        else
        {
            m_Material.DOColor(Color.blue, "_EmissionColor", 1f);
            m_Material.DOColor(Color.blue, 1f);
        }
    }
}
