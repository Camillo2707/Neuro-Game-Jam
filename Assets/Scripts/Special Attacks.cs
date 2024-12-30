using UnityEngine;

public class SpecialAttacks : MonoBehaviour
{
    public GameObject SpecialAttack1;
    public GameObject SpecialAttack2;
    public GameObject SpecialAttack3;
    public GameObject BackButton;
    public EnemyAttacks enemyAttacks;
    public AnimationController Animation;
    public GameObject Attack;
    public GameObject SpecialAttackMenu2;
    
    public void Heal()
    {
        if (ProgrammerPointsTest.pp > 0)
        {
            HpTest.hp = 100;
            SpecialAttack1.SetActive(false);
            SpecialAttack2.SetActive(false);
            SpecialAttack3.SetActive(false);
            BackButton.SetActive(false);
            Attack.SetActive(true);
            SpecialAttackMenu2.SetActive(true);
            ProgrammerPointsTest.pp = ProgrammerPointsTest.pp - 2;
            AnimationController.Drink();
            EnemyAttacks.EnemyAttack();
        }
    }

    public void Hack()
    {
        if (ProgrammerPointsTest.pp > 0)
        {
            SpecialAttack1.SetActive(false);
            SpecialAttack2.SetActive(false);
            SpecialAttack3.SetActive(false);
            BackButton.SetActive(false);
            Attack.SetActive(true);
            SpecialAttackMenu2.SetActive(true);
            ProgrammerPointsTest.pp = ProgrammerPointsTest.pp - 1;
            AnimationController.HackAttack();
            BossHP.HPBoss = BossHP.HPBoss - 40;
            EnemyAttacks.EnemyAttack();
        }
    }

    public void ProgrammingMagic()
    {
        if (ProgrammerPointsTest.pp > 0)
        {
            SpecialAttack1.SetActive(false);
            SpecialAttack2.SetActive(false);
            SpecialAttack3.SetActive(false);
            BackButton.SetActive(false);
            Attack.SetActive(true);
            SpecialAttackMenu2.SetActive(true);
            ProgrammerPointsTest.pp = ProgrammerPointsTest.pp - 3;
            AnimationController.Magic();

            BossHP.HPBoss = BossHP.HPBoss - 80;
            EnemyAttacks.EnemyAttack();
        }
    }
}
