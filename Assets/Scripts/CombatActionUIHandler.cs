using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CombatActionUIHandler : MonoBehaviour
{
    [SerializeField] Button[] combatActionButtons;
    [SerializeField] GameObject container;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CombatEvents.onBeginTurn.AddListener(onBeginTurn);
        CombatEvents.onEndTurn.AddListener(onEndTurn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onBeginTurn(CombatCharacter c) {
    if (!c.isPlayer)
        {
            return;
        }
        container.SetActive(true);
        for(int i=0; i<combatActionButtons.Length; i++)
        {
            if (i < c.combatActions.Count)
            {
                combatActionButtons[i].gameObject.SetActive(true);
                CombatActions ca = c.combatActions[i];
                combatActionButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = ca.displayName;
                combatActionButtons[i].onClick.RemoveAllListeners();
                combatActionButtons[i].onClick.AddListener(() => OnClickCombatAction(ca));
            }
            else
            {
                combatActionButtons[i].gameObject.SetActive(false);
            }
        }
    }
    public void onEndTurn(CombatCharacter c)
    {
        container.SetActive(false);
    }
    public void OnClickCombatAction(CombatActions ca)
    {
        TurnManager.instance.character.CastCombatAction(ca);
    }
}
