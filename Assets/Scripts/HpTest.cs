using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        if (hp <= 0)
        {
            hp = 0;
            OnDeath();
        }
        hpText.SetText("HP: "+ hp);
    }

    async void OnDeath()
    {
        var res = SceneManager.LoadSceneAsync("Dead Scene", LoadSceneMode.Single);
        res.allowSceneActivation = true;
        await res;
    }
}
