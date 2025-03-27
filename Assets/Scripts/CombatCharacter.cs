using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CombatCharacter : MonoBehaviour
{
    public bool isPlayer;
    public List<CombatActions> combatActions;
    public int curHP;
    public int maxHP;
    [SerializeField] CombatCharacter opp;
    private Vector3 startPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void takeDamage(int i)
    {
        Debug.Log($"Damage to take:{i}");
        curHP -= i;
        CombatEvents.onHealthChange.Invoke();
        if (curHP <= 0) Die();
    }
    private void Die()
    {
        CombatEvents.onCharacterDie.Invoke(this);
        Destroy(gameObject);
    }
    public void Heal(int i)
    {
        curHP += i;
        CombatEvents.onHealthChange.Invoke();
        if (curHP > maxHP) curHP = maxHP;
    }
    public void CastCombatAction(CombatActions c)
    {
        if (c.dmg > 0){

        } else if (c.prefab != null)
        {
            GameObject proj = Instantiate(c.prefab, transform.position, Quaternion.identity);
        } else if (c.healAmt > 0)
        {
            Heal(c.healAmt);
        }
        TurnManager.instance.EndTurn();
    }
    IEnumerator attackOpp(CombatActions c)
    {
        while (transform.position != opp.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, opp.transform.position, 50f*Time.deltaTime);
            yield return null;
        }
        opp.takeDamage(c.dmg);
        while (transform.position != startPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, 30f * Time.deltaTime);
            yield return null;
        }
        TurnManager.instance.EndTurn();
    }
    public float GetHealthPercentage()
    {
        return (float)(curHP / maxHP);
    }
}
