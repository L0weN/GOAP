using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int Health = 100;

    public void OnDamage(int damage)
    {
        Health -= damage;
    }
}
