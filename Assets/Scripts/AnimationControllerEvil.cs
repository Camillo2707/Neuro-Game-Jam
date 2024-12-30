using UnityEngine;

public class AnimationControllerEvil : MonoBehaviour
{
    public static Animator Evil;
    
    void Start()
    {
        Evil = GetComponent<Animator>();
    }
    
    
}
