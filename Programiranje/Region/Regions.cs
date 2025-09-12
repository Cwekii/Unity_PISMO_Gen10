using System;
using UnityEngine;

public class Regions : MonoBehaviour
{
    #region Myregion

    private void ThisIsInsideOfRegion()
    {
    }



    #endregion

#if UNITY_ANDROID
    private void Update()
    {
        
    }
#endif

#if  UNITY_IOS
private void Update()
{

}
#endif
    #if UNITY_EDITOR
    #endif
    
}
