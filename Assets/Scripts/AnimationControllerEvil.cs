using UnityEngine;

public class AnimationControllerEvil : MonoBehaviour
{
    public static Animator Evil;
    
    void Start()
    {
        Evil = GetComponent<Animator>();
    }

    public static void Harpoon()
    {
        Evil.SetTrigger("Harpoon");
    }

    public static void Pipe()
    {
        Evil.SetTrigger("Pipe");
    }

    public static void Speech()
    {
        Evil.SetTrigger("Speech");
    }

    public static void Plasma()
    {
        Evil.SetTrigger("Plasma");
    }
}
