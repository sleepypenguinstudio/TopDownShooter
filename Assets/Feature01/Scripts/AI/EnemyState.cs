using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyState : MonoBehaviour
{
    public float EnemyMaxHealth;
    public float EnemyCurrentHealth;
    public float EnemyMovementSpeed;
    public Color EnemyColor;
    private Stats EnemyStats;
    public PolarityManager PolarityManager;
    public PolarityManager.PlayerState EnemyPlayerState;





    private void Awake()
    {
        EnemyStats = PolarityManager.PlayerStateSelectionsList.First(r => r.PlayerState == EnemyPlayerState).Stats;
        EnemyMaxHealth = EnemyStats.MaxHealth;
        EnemyCurrentHealth = EnemyMaxHealth;
        EnemyColor = EnemyStats.PlayerColor;
        this.gameObject.GetComponent<MeshRenderer>().sharedMaterial.color = EnemyColor;
    }



    




























}
