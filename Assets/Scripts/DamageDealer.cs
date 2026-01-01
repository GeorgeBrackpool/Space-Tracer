using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] public int damage;

    public int GetDamage()
    {
        return damage;
    }
    public void Hit()
    {
        Destroy(gameObject);
    }
}
