using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;


public class GameManager : MonoBehaviour
{

    public class Events
    {
        [Serializable]
        public class EnemyHealed : UnityEvent<string> { }

        [Serializable]
        public class EnemyHurt : UnityEvent<string> { }

        [Serializable]
        public class EnemyKilled : UnityEvent<string> { }

        [Serializable]
        public class BaseHealed : UnityEvent { }

        [Serializable]
        public class CheckEnemyStatus : UnityEvent { }
    }

    public enum EnemyEffect
    {
        KILLED,
        HEALED,
        HURT
    }

    static GameManager _instance;

    public Events.EnemyHealed OnEnemyHealed;
    public Events.EnemyHurt OnEnemyHurt;
    public Events.EnemyKilled OnEnemyKilled;
    public Events.BaseHealed OnBaseHealed;
    public Events.CheckEnemyStatus OnCheckEnemyStatus;



    public static GameManager Manager
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }


}
