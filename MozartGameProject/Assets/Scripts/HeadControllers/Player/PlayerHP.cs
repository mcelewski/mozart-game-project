using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    private static float _playerHP = 100;
    private static float _playerMaxHP = 100;

    public static float GetPlayerHP()
    {
        return _playerHP;
    }

    public static float GetMaxHp()
    {
        return _playerMaxHP;
    }

    public static void SetPlayerHP(float amount)
    {
        if (amount < 20 && _playerHP < _playerMaxHP)
        {
            _playerHP += amount;
        }
    }

    public static void SetMaximumHP(float maxHp)
    {
        _playerMaxHP = maxHp;
    }
}
