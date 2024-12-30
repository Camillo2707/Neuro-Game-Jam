using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HpTest : MonoBehaviour
{
    public static int hp = 100;
    public TMP_Text hpText;
    void Start()
    {
        
    }

    
    void Update()
    {
        hpText.SetText("HP: "+ hp);
        if (hp <= 0)
        {
            Application.Quit();
        }
    }
}
