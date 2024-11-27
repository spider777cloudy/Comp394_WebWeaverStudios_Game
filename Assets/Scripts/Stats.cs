using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[CreateAssetMenu]
public class Stats : ScriptableObject
{
    #region FIELDS
    [Header("Stats")]
    public int strengthScore = 0;
    public int finesseScore = 0;
    public int vitalityScore = 0;
    public int arcaneScore = 0;
    public int slimePoints = 0;

    [Header("Attack")]
    public int baseDamage = 1;
    public float baseAttackSpeed = 1.0f;
    public float baseAttackCD = 1.0f;
    public float baseAttackTime = 0.1f;

    [Header("Movement")]
    public float baseMovementSpeed = 20.0f;
    public float baseJumpPower = 30.0f;

    [Header("Health")]
    private int baseHP = 10;
    private int baseArmor = 0;
    private int baseEnergy = 10;

    [Header("Arcane")]
    public int baseMana = 0;
    public int baseArcaneDamage = 1;
    public float baseCastingTime = 1.0f;
    #endregion

    #region ENUMS
    public enum AttributeType
    {
        Strength,
        Finesse,
        Vitality,
        Arcane
    }
    #endregion

    #region PROPERTIES
    // ATTACK
    public int Damage { get; set; }
    public float AttackSpeed { get; set; }
    public float AttackCD { get; set; }
    public float AttackTime { get; set; }

    // MOVEMENT
    public float MovementSpeed { get; set; }
    public float JumpPower { get; set; }

    // HEALTH
    public int HP { get; set; }
    public int Armor { get; set; }
    public int Energy { get; set; }

    // ARCANE
    public int Mana { get; set; }
    public int ArcaneDamage { get; set; }
    public float CastingTime { get; set; }
    #endregion

    #region METHODS
    public void UpdateAttributes()
    {
        // STRENGTH PROPERTIES
        Damage = baseDamage + (strengthScore * 1);
        JumpPower = baseJumpPower + (strengthScore * 5.0f);

        // FINESSE PROPERTIES
        AttackSpeed = baseAttackSpeed + (finesseScore * 0.34f);
        AttackTime = baseAttackTime - (finesseScore * 0.01f);
        MovementSpeed = baseMovementSpeed + (finesseScore * 5.0f);

        // VITALITY PROPERTIES
        AttackCD = baseAttackCD - (vitalityScore * 0.1f);
        HP = baseHP + (vitalityScore * 2);
        Energy = baseEnergy + (vitalityScore * 2);

        // ARCANE PROPERTIES
        Mana = baseMana + (arcaneScore * 2);
        ArcaneDamage = baseArcaneDamage + (arcaneScore * 1);
        CastingTime = baseCastingTime - (arcaneScore * 0.1f);
    }

    public void IncreaseAttribute(AttributeType attributeType)
    {
        if (slimePoints > 0)
        {
            switch (attributeType)
            {
                case AttributeType.Strength:
                    {
                        strengthScore++;
                    }
                    break;

                case AttributeType.Finesse:
                    {
                        finesseScore++;
                    }
                    break;

                case AttributeType.Vitality:
                    {
                        vitalityScore++;
                    } 
                    break;

                case AttributeType.Arcane:
                    {
                        arcaneScore++;
                    }
                    break;
            }
        }
        else if (slimePoints < 0)
        {
            Debug.Log("No Slime Points");
        }
    }

    public void AddSlimePoints(int points)
    {
        slimePoints += points;
    }
    #endregion
}