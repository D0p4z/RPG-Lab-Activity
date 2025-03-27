using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private CombatCharacter character;
    [SerializeField] private AnimationCurve healrate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        CombatEvents.onBeginTurn.AddListener(OnBeginTurn);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnBeginTurn(CombatCharacter c)
    {
        if (character == c)
        {
            DetermineCombatActions();
        }
    }

    public void DetermineCombatActions()
    {
        float healthPercentage = character.GetHeatlhPercentage();
        bool wantToHeal = Random.value < healrate.Evaluate(healthPercentage);
        CombatActions ca = null;
        if (wantToHeal && DetermineIfHasCombatActionType(AttackType.Heal))
        {
            ca = GetCombatActionOfType(AttackType.Heal);
        }
        else if (DetermineIfHasCombatActionType(AttackType.Basic))
        {
            ca = GetCombatActionOfType(AttackType.Basic);
        }
    }
    private bool DetermineIfHasCombatActionType(AttackType type)
    {
        return character.combatActions.Exists(x=>x.action==type);
    }
    private CombatActions GetCombatActionOfType(AttackType type)
    {
        List<CombatActions> availableActions = character.combatActions.FindAll(x=>x.action==type);
        return availableActions[Random.Range(0,availableActions.Count)];
    }
    
}
