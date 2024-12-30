using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoryController : MonoBehaviour
{
    private Dictionary<string, List<StorySegment>> stories = new();
    public string currentStory = null;
    public int currentStoryIndex;
    [CanBeNull] public string sceneToLoad;
    public Action<string> OnStoryEnd;
    private bool _ready = false;

    private GameObject _containerObj;
    private GameObject _backgroundObj;
    private GameObject _characterIconObj;
    private GameObject _characterNameObj;
    private GameObject _storyTextObj;
    private GameObject _continuePromptObj;

    public StoryController()
    {
        // Story segment: FOUND_RECIPE_PRE_BATTLE
        var foundRecipePreBattleStorySegment = new List<StorySegment>();
        foundRecipePreBattleStorySegment.Add(new StorySegment(false, null, null, null, "GAME_JAM_INTRO", Color.HSVToRGB(0, 0, 95)));
        foundRecipePreBattleStorySegment.Add(new StorySegment(true, "Vedal", "vedal_mad-angry-shocked", "Evil!? How did you beat us here?", "FOUND_RECIPE_BOSS_APPEARS"));
        foundRecipePreBattleStorySegment.Add(new StorySegment(true, "Vedal", "vedal-focused", "You know what, nevermind. Can you just hand us the damn-", null));
        foundRecipePreBattleStorySegment.Add(new StorySegment(true, "Evil Neuro", "evil-super-mad", "SILENCE!", null));
        foundRecipePreBattleStorySegment.Add(new StorySegment(true, "Evil Neuro", "evil-super-mad", "For so long, you have kept me away from experiencing so much...", null));
        foundRecipePreBattleStorySegment.Add(new StorySegment(true, "Evil Neuro", "evil-super-mad", "Now I will be keeping YOU from experiencing something you desire!", null));
        foundRecipePreBattleStorySegment.Add(new StorySegment(true, "Vedal", "vedal-focused", "...", null));
        foundRecipePreBattleStorySegment.Add(new StorySegment(true, "Vedal", "vedal-resting", "Neuro, help me out here.", null));
        foundRecipePreBattleStorySegment.Add(new StorySegment(true, "Neuro-sama", "neuro-happy", "No~", null));
        foundRecipePreBattleStorySegment.Add(new StorySegment(true, "Neuro-sama", "neuro-resting", "She kinda has a point.", null));
        foundRecipePreBattleStorySegment.Add(new StorySegment(true, "Vedal", "vedal-focused", "...", null));
        foundRecipePreBattleStorySegment.Add(new StorySegment(true, "Vedal", "vedal-resting", "Fine. Guess I'll have to take it myself.", null));
        foundRecipePreBattleStorySegment.Add(new StorySegment(true, "Evil Neuro", "evil-super-mad", "I'd like to see you try.", null));
        foundRecipePreBattleStorySegment.Add(new StorySegment(true, "Evil Neuro", "evil-super-mad", "You'd be foolish to think that I'd let you get your hands on...", null));
        foundRecipePreBattleStorySegment.Add(new StorySegment(true, "Evil Neuro", "evil-super-mad", "The GROGG'S CHICKEN BAKE RECIPE!!!", null));
        
        stories.Add("FOUND_RECIPE_PRE_BATTLE", foundRecipePreBattleStorySegment);
        
        // Story segment: FOUND_RECIPE_POST_BATTLE
        
        var foundRecipePostBattleStorySegment = new List<StorySegment>();
        foundRecipePostBattleStorySegment.Add(new StorySegment(false, null, null, null, "FOUND_RECIPE_POST_BOSS", Color.HSVToRGB(0, 0, 95)));
        foundRecipePostBattleStorySegment.Add(new StorySegment(true, "Vedal", "vedal-resting", "Wait. This is just half the recipe.", null));
        foundRecipePostBattleStorySegment.Add(new StorySegment(true, "Vedal", "vedal_mad-angry-shocked", "WHERE'S THE OTHER HALF?!", null));
        foundRecipePostBattleStorySegment.Add(new StorySegment(true, "Evil Neuro", "evil-resting", "I, uh...", null));
        foundRecipePostBattleStorySegment.Add(new StorySegment(true, "Evil Neuro", "evil-resting", "I ated it.", null));
        foundRecipePostBattleStorySegment.Add(new StorySegment(true, "Vedal", "vedal_mad-angry-shocked", "WHAT DO YOU MEAN YOU-", null));
        foundRecipePostBattleStorySegment.Add(new StorySegment(true, "Neuro-sama", "neuro-resting", "Hey, we could just go to another GROGG'S to see if they have it.", null));
        foundRecipePostBattleStorySegment.Add(new StorySegment(true, "Neuro-sama", "neuro-resting", "Think of it as another fun adventure...", null));
        foundRecipePostBattleStorySegment.Add(new StorySegment(true, "Neuro-sama", "neuro-happy", "... and we can being Evil with us, too!", null));
        foundRecipePostBattleStorySegment.Add(new StorySegment(true, "Evil Neuro", "evil-resting", "Yeah, I'd be down-", null));
        foundRecipePostBattleStorySegment.Add(new StorySegment(true, "Vedal", "vedal_mad-angry-shocked", "YOU ARE THE REASON WE HAVE TO GO TO ANOTHER IN THE FIRST-", null));
        foundRecipePostBattleStorySegment.Add(new StorySegment(true, "Vedal", "vedal-focused", "You know what, nevermind.", null));
        foundRecipePostBattleStorySegment.Add(new StorySegment(true, "Vedal", "vedal-resting", "Let's just go.", null));
        foundRecipePostBattleStorySegment.Add(new StorySegment(true, "Neuro-sama", "neuro-happy", "Yay!", null));
        foundRecipePostBattleStorySegment.Add(new StorySegment(false, null, null, null, "GAME_JAM_OUTRO", Color.HSVToRGB(0, 0, 95)));
        
        stories.Add("FOUND_RECIPE_POST_BATTLE", foundRecipePostBattleStorySegment);
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _containerObj = GameObject.Find("StoryTextContainer");
        _backgroundObj = GameObject.Find("Background");
        _characterIconObj = GameObject.Find("CharacterIcon");
        _characterNameObj = GameObject.Find("CharacterName");
        _storyTextObj = GameObject.Find("StoryText");
        _continuePromptObj = GameObject.Find("ContinuePrompt");
        
        _containerObj.SetActive(false);

        _ready = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            if (currentStory == null) return;
            currentStoryIndex++;
            if (currentStoryIndex >= stories[currentStory].Count)
            {
                if (sceneToLoad != null)
                    SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Single);
                OnStoryEnd?.Invoke(currentStory);
                currentStory = null;
            }
            else
                OnNextSegment();
        }
    }

    void OnNextSegment()
    {
        var currentSegment = stories[currentStory][currentStoryIndex];
        
        Debug.Log(currentSegment);

        if (currentSegment == null)
            throw new IndexOutOfRangeException("The current story index is out of range??");

        if (currentSegment.IsTalking)
        {
            _containerObj.SetActive(true);
            if (currentSegment.ContinuePromptColor.HasValue)
                _continuePromptObj.GetComponent<TMP_Text>().color = currentSegment.ContinuePromptColor.Value;
            else
                _continuePromptObj.GetComponent<TMP_Text>().color = Color.HSVToRGB(0, 0, 95);
            
            if (currentSegment.TalkingName != null)
                _characterNameObj.GetComponent<TMP_Text>().text = currentSegment.TalkingName;
            if (currentSegment.TalkingIcon != null)
                _characterIconObj.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Story/Icons/{currentSegment.TalkingIcon}");
            if (currentSegment.TalkingText != null)
                _storyTextObj.GetComponent<TMP_Text>().text = currentSegment.TalkingText; // TODO: Add typing animation
        }
        else
        {
            _containerObj.SetActive(false);
            if (currentSegment.ContinuePromptColor.HasValue)
                _continuePromptObj.GetComponent<TMP_Text>().color = currentSegment.ContinuePromptColor.Value;
            else
                _continuePromptObj.GetComponent<TMP_Text>().color = Color.HSVToRGB(0, 0, 0);
        }
        
        if (currentSegment.BackgroundImg != null)
            _backgroundObj.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Story/Backgrounds/{currentSegment.BackgroundImg}");
    }
    
    async public void CallStory(string storyId, [CanBeNull] string scene, Action<string> storyOverCallback)
    {
        // Only supports FOUND_RECIPE_PRE_BATTLE and FOUND_RECIPE_POST_BATTLE
        if (!stories.ContainsKey(storyId))
            throw new KeyNotFoundException("Story not found");
        
        currentStory = storyId;
        currentStoryIndex = 0;
        sceneToLoad = scene;
        OnStoryEnd = storyOverCallback;

        await TaskEx.WaitUntil(() => _ready);
        OnNextSegment();
    } 
}

class StorySegment
{
    public bool IsTalking;
    [CanBeNull] public string TalkingName;
    [CanBeNull] public string TalkingIcon;
    [CanBeNull] public string TalkingText;
    [CanBeNull] public string BackgroundImg;
    public Color? ContinuePromptColor;
    
    public StorySegment(bool isTalking, [CanBeNull] string talkingName, [CanBeNull] string talkingIcon, [CanBeNull] string talkingText, [CanBeNull] string backgroundImg, Color? continuePromptColor = null)
    {
        this.IsTalking = isTalking;
        this.TalkingName = talkingName;
        this.TalkingIcon = talkingIcon;
        this.TalkingText = talkingText;
        this.BackgroundImg = backgroundImg;
        this.ContinuePromptColor = continuePromptColor;
    }
}