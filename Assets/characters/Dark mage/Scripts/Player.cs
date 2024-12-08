using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public KeyCode attackKey;
    public GameObject LoosePanel;
    public GameManager _gameManager;
    public Animator playerController;
     bool isAttack;
     public Image healthFiller;
     public Enemy _enemy;

     private void Start()
     {
         healthFiller.fillAmount = 1;
     }

     public float PlayerHealth=100;

     void Update()
    {
        if (Input.GetKeyDown(attackKey))
        {
            Attack();
        }
        if (Input.GetKeyUp(attackKey))
        {
            BackToIdle();
        }
    }

    public void Attack()
    {
        playerController.SetTrigger("isAttack");
    }
    
    private void BackToIdle()
    {
        playerController.Play("Idle");
    }

    public void OnAttackComplete()
    {
        //Debug.Log("Atk Completed");
        playerController.Play("Idle");
        var enemy = _gameManager.GetClosetEnemy();
        _enemy = enemy;
        
        if(enemy!=null)
            enemy.DecreaseEnemyHealth(10);
    }

    public void DecreasePlayerHealth(float damage)
    {
        PlayerHealth -= damage;
        var fillAmountAfterDmg = PlayerHealth / 100;
        healthFiller.fillAmount = fillAmountAfterDmg;
        Die();
    }

    public void Die()
    {
        if (PlayerHealth <= 0)
        {
            playerController.SetTrigger("isDead");
            
            Invoke(nameof(ActivateLoosePanel),0.6f);
        }
    }

    private void ActivateLoosePanel()
    {
        LoosePanel.SetActive(true);
        Time.timeScale = 0;
    }
}
