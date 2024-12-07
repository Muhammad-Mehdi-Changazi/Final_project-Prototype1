using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
   public float speed;
   public NavMeshAgent enemyAiController;
   public Animator _animator;
   public Transform targetPlayer;
   public GameManager _gameManager;
   public int enemyIndex;
   public float playerCloseDistance=5;
   public float enemyHealth = 20;
   public Image enemyHealthFiller;
   bool die;
   public Player Player;
   bool isEnabled;
      
   private void Update()
   {
      EnableEnemy();
      AttackPlayer();
   }

   private void EnableEnemy()
   {
      if (!isEnabled && _gameManager.GetEnemyBool(enemyIndex))
      {  
         
         _animator.SetBool("isWalk",true);
         enemyAiController.enabled = true;
         enemyAiController.SetDestination(targetPlayer.position);
         isEnabled = true;
      }
   }

   private void AttackPlayer()
   {
      if (Vector3.Distance(transform.position, targetPlayer.position) <= playerCloseDistance)
      {  
         _animator.SetBool("isWalk",false);
         _animator.SetBool("isAttack",true);
         enemyAiController.enabled = false;
       
      }
      else if(isEnabled)
      {
         WalkToPlayer();
      }
   }


   private void WalkToPlayer()
   {  
      Debug.LogError("WalkToPlayer");
      _animator.SetBool("isAttack",false);
      _animator.SetBool("isWalk",true);
      isEnabled = false;
      enemyAiController.enabled = true;
   }

   public void OnAttackComplete()
   {
      Debug.Log("Enemy atk completed");
      
      if(Vector3.Distance(transform.position,targetPlayer.position)<=playerCloseDistance)
         Player.DecreasePlayerHealth(20);
   }
   
   public void DecreaseEnemyHealth(float damage)
   {
      enemyHealth -= damage;
      var fillAmountAfterDmg = enemyHealth / 20;
      enemyHealthFiller.fillAmount = fillAmountAfterDmg;
      Die();
   }
   
   public void Die()
   {
      if (!die && enemyHealth <= 0)
      {
         //_animator.SetTrigger("isDead");
         _gameManager.IncreaseEnemyDieCount();
         Invoke(nameof(Deactivate),0.2f);
         die = true;
      }
   }



   void Deactivate()
   {
      gameObject.SetActive(false);
      _animator.enabled = false;
   }
}
