using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] CombatCharacter[] characters;
    [SerializeField] float nextTurnDelay = 1f;
    private int index=-1;
    public CombatCharacter character;
    public static TurnManager instance;
    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onBeginTurn()
    {
        index++;
        index %= characters.Length;
        character = characters[index];
        CombatEvents.onBeginTurn.Invoke(character);
    }
    public void EndTurn()
    {
        CombatEvents.onEndTurn.Invoke(character);
        Invoke(nameof(onBeginTurn),nextTurnDelay);
    }
    private void onCharacterDie(CombatCharacter c)
    {
        Debug.Log("ded");
    }
}
