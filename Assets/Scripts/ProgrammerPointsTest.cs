using TMPro;
using UnityEngine;

public class ProgrammerPointsTest : MonoBehaviour
{
    public static int pp = 15;
    public TMP_Text ppText;
   
    void Start()
    {
        
    }


    void Update()
    {
        if (pp <= 0)
        {
            pp = 0;
        }
        ppText.SetText("Programmer Points(PP): " + pp);
    }
}
