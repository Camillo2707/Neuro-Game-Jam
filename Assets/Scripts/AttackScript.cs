using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class TurnOrder : MonoBehaviour
{
    public GameObject AttackButton;
    public GameObject SpecialAttack;
    public EnemyAttacks enemyAttacks;
    public GameObject Vedal;
    public AnimationController Animation;
    
    
    
    public void Attack()
    {
        

        BossHP.HPBoss = BossHP.HPBoss - 25;
        EnemyAttacks.EnemyAttack();
        AnimationController.NormalAttackAnimation();
    }
}
