using UnityEngine;
using System.Collections.Generic;

public class GameMangaer : MonoBehaviour
{
    public List<Character> l;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        l = new List<Character>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int appendCharacter(Character c)
    {
        l.Add(c);
        return l.Count - 1;
    }
}
