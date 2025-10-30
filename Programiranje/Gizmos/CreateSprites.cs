using System.Threading.Tasks;
using UnityEngine;

public class CreateSprites : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    
    async void Start()
    {
        Debug.Log($"Starting instance of CreateSprites");
        await GenerateSprites();
        Debug.Log($"CreateSprites finished");
    }

    private async Awaitable GenerateSprites()
    {
        for (int i = 0; i < 10; i++)
        {
            await Awaitable.WaitForSecondsAsync(1f);
            GameObject sprite = Instantiate(prefab, new Vector3(i,0,0),  Quaternion.identity);
            
        }

    }

}
