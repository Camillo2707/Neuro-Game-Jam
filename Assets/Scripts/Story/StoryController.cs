using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoryController : MonoBehaviour
{
    private Dictionary<string, List<StorySegment>> stories = new();
    public string currentStory;
    public int currentStoryIndex;
    public Action<string> OnStoryEnd;

    private GameObject _containerObj;
    private GameObject _backgroundObj;
    private GameObject _characterIconObj;
    private GameObject _characterNameObj;
    private GameObject _storyTextObj;
    private GameObject _continuePromptObj;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _containerObj = GameObject.Find("StoryTextContainer");
        _backgroundObj = GameObject.Find("Background");
        _characterIconObj = GameObject.Find("CharacterIcon");
        _characterNameObj = GameObject.Find("CharacterName");
        _storyTextObj = GameObject.Find("StoryText");
        _continuePromptObj = GameObject.Find("ContinuePrompt");
        
        
        // Story segment: FOUND_RECIPE_PRE_BATTLE
        var foundRecipePreBattleStorySegment = new List<StorySegment>();
        foundRecipePreBattleStorySegment.Add(new StorySegment(true, "Neuro-sama", "neuro-happy", "Hello I am Neuro-sama!", null));
        
        stories.Add("FOUND_RECIPE_PRE_BATTLE", foundRecipePreBattleStorySegment);
        
        // Story segment: FOUND_RECIPE_POST_BATTLE
        
        var foundRecipePostBattleStorySegment = new List<StorySegment>();
        foundRecipePostBattleStorySegment.Add(new StorySegment(false, null, null, null, "FOUND_RECIPE_POST_BOSS"));
        foundRecipePostBattleStorySegment.Add(new StorySegment(true, "Neuro-sama", "neuro-resting", "Hello I am Neuro-sama!", null));
        foundRecipePostBattleStorySegment.Add(new StorySegment(true, "Neuro-sama", "neuro-sad", "If this doesn't work, I will be sad.", null));
        foundRecipePostBattleStorySegment.Add(new StorySegment(true, "Neuro-sama", "neuro-happy", "But if it does, I will be really happy!", null));
        
        stories.Add("FOUND_RECIPE_POST_BATTLE", foundRecipePostBattleStorySegment);
        
        CallStory("FOUND_RECIPE_POST_BATTLE", (storyId) =>
        {
            Debug.Log(storyId);
        });
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

        if (currentSegment == null)
            throw new IndexOutOfRangeException("The current story index is out of range??");

        if (currentSegment.IsTalking)
        {
            _containerObj.SetActive(true);
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
            _continuePromptObj.GetComponent<TMP_Text>().color = Color.HSVToRGB(0, 0, 0);
        }
        
        if (currentSegment.BackgroundImg != null)
            _backgroundObj.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Story/Backgrounds/{currentSegment.BackgroundImg}");
    }
    
    public void CallStory(string storyId, Action<string> storyOverCallback)
    {
        // Only supports FOUND_RECIPE_PRE_BATTLE and FOUND_RECIPE_POST_BATTLE
        if (!stories.ContainsKey(storyId))
            throw new KeyNotFoundException("Story not found");

        currentStory = storyId;
        currentStoryIndex = 0;
        OnStoryEnd = storyOverCallback;
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
    
    public StorySegment(bool isTalking, [CanBeNull] string talkingName, [CanBeNull] string talkingIcon, [CanBeNull] string talkingText, [CanBeNull] string backgroundImg)
    {
        this.IsTalking = isTalking;
        this.TalkingName = talkingName;
        this.TalkingIcon = talkingIcon;
        this.TalkingText = talkingText;
        this.BackgroundImg = backgroundImg;
    }
}