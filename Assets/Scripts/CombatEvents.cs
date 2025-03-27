using UnityEngine;
using UnityEngine.Events;
public static class CombatEvents
{
    public static UnityEvent<CombatCharacter> onBeginTurn= new UnityEvent<CombatCharacter>();
    public static UnityEvent<CombatCharacter> onEndTurn = new UnityEvent<CombatCharacter>();
    public static UnityEvent<CombatCharacter> onCharacterDie = new UnityEvent<CombatCharacter>();
    public static UnityEvent onHealthChange = new UnityEvent();
}
