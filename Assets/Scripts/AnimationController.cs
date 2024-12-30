using UnityEngine;

public class AnimationController : MonoBehaviour
{
   public static Animator Vedal;

   void Start()
   {
      Vedal = GetComponent<Animator>();
   }

   public static void NormalAttackAnimation()
   {
      Vedal.SetTrigger("Attack");
   }

   public static void HackAttack()
   {
      Vedal.SetTrigger("Hack");
   }

   public static void Drink()
   {
      Vedal.SetTrigger("Drink");
   }

   public static void Magic()
   {
      Vedal.SetTrigger("Magic");
   }
}
