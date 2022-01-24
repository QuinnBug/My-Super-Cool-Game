using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    public UnityEvent m_EnemyKilled;
    public UnityEvent m_PlayerKilled;
    public int score;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }

        if (m_EnemyKilled == null) m_EnemyKilled = new UnityEvent();
        if (m_PlayerKilled == null) m_PlayerKilled = new UnityEvent();

        m_EnemyKilled.AddListener(AddScore);
    }

    void AddScore()
    {
        score++;
    }
}
