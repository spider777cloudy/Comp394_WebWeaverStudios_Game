using UnityEngine;

public class PersistentCanvas : MonoBehaviour
{
    private void Awake()
    {
        // Ensure this Canvas persists across scenes
        DontDestroyOnLoad(gameObject);

        // Prevent duplicate Canvases from being created
        if (FindObjectsOfType<PersistentCanvas>().Length > 1)
        {
            Destroy(gameObject);
        }
    }
}
