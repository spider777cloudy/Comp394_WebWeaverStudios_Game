using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Components.HP
{
    public class HPStats : MonoBehaviour
    {
        float currHP;
        public float maxHealth;
        public bool isAlive;

        [Header("UI Element")]
        public Slider healthBar;

        [Header("Combat Text")]
        public GameObject floatingCombatText;
        public TMP_Text popUpText;

        public event Action OnDeath = delegate { };

        public virtual void Start()
        {
            isAlive = true;
            currHP = maxHealth;
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public virtual void TakeDamage(int damage)
        {
            if (!isAlive)
            {
                Debug.Log($"{gameObject.name} taking damage but it is dead!");
                QuitGame();
                return;
            }
            popUpText.text = damage.ToString();
            if (damage > 0)
            {
                popUpText.color = Color.red;
            }
            else if (damage == 0)
            {
                popUpText.color = Color.gray;
            }
            Instantiate(floatingCombatText, transform.position, Quaternion.identity);
            //Debug.Log($"{gameObject.name} is taking damage {damage}");
            var remainingDamage = damage;

            currHP -= remainingDamage;

            if (currHP <= 0 && isAlive)
            {
                Death();
                isAlive = false;
            }
        }

        public virtual void Update()
        {
            UpdateHealthUI();
        }

        void UpdateHealthUI()
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currHP;
        }

        public virtual void Death()
        {
            OnDeath.Invoke();
        }
    }
}
