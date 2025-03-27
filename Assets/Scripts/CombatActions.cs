using UnityEngine;
[CreateAssetMenu(fileName ="CombatAction",menuName ="newCombatAction")]
public class CombatActions : ScriptableObject
{
    public string displayName;
    public AttackType action;
    public int dmg;
    public GameObject prefab;
    public int healAmt;

}
