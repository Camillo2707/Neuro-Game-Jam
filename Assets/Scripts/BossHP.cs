using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHP : MonoBehaviour
{
    public static int HPBoss = 500;
    public TMP_Text BosshpText;    
    void Update()
    {
        BosshpText.SetText("Evil's HP: " + HPBoss);
        if (BossHP.HPBoss <= 0)
        {
            EvilDeath();
        }
    }

    async void EvilDeath(){
        var res = SceneManager.LoadSceneAsync("Story View", LoadSceneMode.Single);
        res.allowSceneActivation = true;
        await res;
        GameObject.Find("StoryView").GetComponent<StoryController>().CallStory("FOUND_RECIPE_POST_BATTLE", "Main Menu", (storyId) => { });
    }
}
