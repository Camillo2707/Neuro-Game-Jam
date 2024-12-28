using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class TurnOrder : MonoBehaviour
{
    public int turn;
    public GameObject Attack;
    public GameObject SpecialAttack;
    public GameObject Items;

    public void TurnPlayer()
    {
        turn = 1;
        Debug.Log(turn);
        Attack.SetActive(true);
        SpecialAttack.SetActive(true);
        Items.SetActive(true);
    }

    public void TurnEnemy()
    {
        turn = 2;
        Debug.Log(turn);
        Attack.SetActive(false);
        SpecialAttack.SetActive(false);
        Items.SetActive(false);
    }
}
