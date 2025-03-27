using System.Collections;
using UnityEngine;
public class Character : Enums
{
    public CharacterClass cC;
    public CharacterType cT;
    public AbilityScoreNames aSN;
    public abilityScores aS = new abilityScores();
    public struct abilityScores
    {
        public int strength;
        public int dexterity;
        public int constitution;
        public int intelligence;
        public int wisdom;
        public int charisma;
        public abilityScores(int s, int d, int c, int i, int w, int h)
        {
            strength = s;
            dexterity=d;
            constitution=c;
            intelligence=i;
            wisdom=w;
            charisma=h;
        }
    }
    public string characterName;
    public GameObject gameObject;
    public Character(CharacterClass a, CharacterType b, AbilityScoreNames c, abilityScores d)
    {
        cC = a;
        cT = b;
        aSN = c;
        aS = d;
    }
    public int GetAbilityScoreBonus(AbilityScoreNames abilityName)
    {
        int i;
        switch (abilityName)
        {
            case AbilityScoreNames.Strength:
                i = aS.strength;
                break;
            case AbilityScoreNames.Dexterity:
                i = aS.dexterity;
                break;
            case AbilityScoreNames.Constitution:
                i = aS.constitution;
                break;
            case AbilityScoreNames.Intelligence:
                i = aS.intelligence;
                break;
            case AbilityScoreNames.Wisdom:
                i = aS.wisdom;
                break;
            case AbilityScoreNames.Charisma:
                i = aS.charisma;
                break;
            default:
                i = 0;
                break;
        }
        switch (i)
        {
            case 3:
            case 4:
                return 0;
            case 5:
            case 6:
                return 1;
            case 7:
            case 8:
                return 2;
            case 9:
            case 10:
                return 3;
            default:
                return -1;
        }
    }
}
