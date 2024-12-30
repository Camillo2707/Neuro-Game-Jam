using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Button startButton;
    public Button endButton;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (startButton != null)
        {
            startButton = startButton.GetComponent<Button>();
            startButton.onClick.AddListener(OnClickStartGame);
        }

        endButton = endButton.GetComponent<Button>();
        endButton.onClick.AddListener(OnClickExitGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    async void OnClickStartGame()
    {
        var res = SceneManager.LoadSceneAsync("Story View", LoadSceneMode.Single);
        res.allowSceneActivation = true;
        await res;
        GameObject.Find("StoryView").GetComponent<StoryController>().CallStory("FOUND_RECIPE_PRE_BATTLE", "Battle View", (storyId) => { });
    }

    async void OnClickExitGame()
    {
        Application.Quit();
    }
}
