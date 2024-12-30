using UnityEngine;
using UnityEngine.InputSystem;

public class SpecialAttacksMenu : MonoBehaviour
{
    public GameObject SpecialAttack1;
    public GameObject SpecialAttack2;
    public GameObject SpecialAttack3;
    public GameObject BackButton;
    public GameObject Attack;
    public GameObject SpecialAttackMenu2;
    

    public void SpecialAttackMenu()
    {
        SpecialAttack1.SetActive(true);
        SpecialAttack2.SetActive(true);
        SpecialAttack3.SetActive(true);
        BackButton.SetActive(true);
        Attack.SetActive(false);
        SpecialAttackMenu2.SetActive(false);
        
    }

    public void LeaveMenu()
    {
        SpecialAttack1.SetActive(false);
        SpecialAttack2.SetActive(false);
        SpecialAttack3.SetActive(false);
        BackButton.SetActive(false);
        Attack.SetActive(true);
        SpecialAttackMenu2.SetActive(true);
        
    }

    void Start()
    {
        SpecialAttack1.SetActive(false);
        SpecialAttack2.SetActive(false);
        SpecialAttack3.SetActive(false);
        BackButton.SetActive(false);
    }
}
