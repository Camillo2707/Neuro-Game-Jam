using UnityEngine;

public class SpecialAttacks : MonoBehaviour
{
    public GameObject SpecialAttack1;
    public GameObject SpecialAttack2;
    public GameObject SpecialAttack3;
    public GameObject BackButton;
    public EnemyAttacks enemyAttacks;
    public AnimationController Animation;
    
    public void Heal()
    {
        HpTest.hp = 100;
        SpecialAttack1.SetActive(false);
        SpecialAttack2.SetActive(false);
        SpecialAttack3.SetActive(false);
        BackButton.SetActive(false);
        ProgrammerPointsTest.pp = ProgrammerPointsTest.pp - 2;
        AnimationController.Drink();
        EnemyAttacks.EnemyAttack();
    }

    public void Hack()
    {
        SpecialAttack1.SetActive(false);
        SpecialAttack2.SetActive(false);
        SpecialAttack3.SetActive(false);
        BackButton.SetActive(false);
        ProgrammerPointsTest.pp = ProgrammerPointsTest.pp - 1;
        AnimationController.HackAttack();
        BossHP.HPBoss = BossHP.HPBoss - 30;
        EnemyAttacks.EnemyAttack();
    }

    public void ProgrammingMagic()
    {
        SpecialAttack1.SetActive(false);
        SpecialAttack2.SetActive(false);
        SpecialAttack3.SetActive(false);
        BackButton.SetActive(false);
        ProgrammerPointsTest.pp = ProgrammerPointsTest.pp - 3;
        AnimationController.Magic();
        
        BossHP.HPBoss = BossHP.HPBoss - 60;
        EnemyAttacks.EnemyAttack();
    }
}
