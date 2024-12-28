using TMPro;
using UnityEngine;

public class ProgrammerPointsTest : MonoBehaviour
{
    public int pp;
    public TMP_Text ppText;
   
    void Start()
    {
        
    }


    void Update()
    {
        ppText.SetText("PP: " + pp);
    }
}
