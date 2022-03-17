using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamList : MonoBehaviour
{
    public List<GameObject> _team1 = new List<GameObject>();
    public List<GameObject> _enemy = new List<GameObject>();

    private void Start()
    {
        _team1.AddRange(GameObject.FindGameObjectsWithTag("Team1"));
        _enemy.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
    }

    void AddTeam(string Team, GameObject obj)
    {
        switch (Team)
        {
            case "Team1": _team1.Add(obj); break;

            case "Enemy": _enemy.Add(obj); break;
        }
    }
}

//왜만들었지? Lookat에서 쓰더라. 다른걸로 대처하든가