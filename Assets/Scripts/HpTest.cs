using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HpTest : MonoBehaviour
{
    public int hp;
    public TMP_Text hpText;
    void Start()
    {
        
    }

    
    void Update()
    {
        hpText.SetText("HP: "+ hp);
    }
}
