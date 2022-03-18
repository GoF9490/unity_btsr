using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamList : MonoBehaviour
{
    public static TeamList Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<TeamList>();

            return instance;
        }
    }

    private static TeamList instance;

    public List<GameObject> _player = new List<GameObject>();
    public List<GameObject> _enemy = new List<GameObject>();

    private void Start()
    {
        //SerchTeam();
    }

    private void OnEnable()
    {
        SerchTeam();
    }

    public void SerchTeam()
    {
        _player.Clear();
        _enemy.Clear();
        _player.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        _enemy.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
    }

    public void AddTeam(string Team, GameObject obj)
    {
        switch (Team)
        {
            case "Player": _player.Add(obj); break;

            case "Enemy": _enemy.Add(obj); break;
        }
    }
}