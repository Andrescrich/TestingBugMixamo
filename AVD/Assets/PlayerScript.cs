using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript Instance { get; set; }
    
    private void Awake()
    {
        Instance = this;
    }
}
