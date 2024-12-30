using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    public static int attack;
    
    public static void EnemyAttack()
    {
        attack = Random.Range(1, 5);
        Debug.Log(attack);

        switch (attack)
        {
            case 1:
                Debug.Log("Harpoon");
                HpTest.hp = HpTest.hp - 15;
                Debug.Log(HpTest.hp);
                break;
            case 2:
                Debug.Log("Pipe");
                HpTest.hp = HpTest.hp - 10;
                Debug.Log(HpTest.hp);
                break;
            case 3:
                Debug.Log("Plasma Ball");
                HpTest.hp = HpTest.hp - 20;
                Debug.Log(HpTest.hp);
                break;
            case 4:
                Debug.Log("Ai Problem");
                HpTest.hp = HpTest.hp - 25;
                Debug.Log(HpTest.hp);
                break;
        }
    }
    
    
}
