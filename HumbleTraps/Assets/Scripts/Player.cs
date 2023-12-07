using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IPlayer 
{
    private CharacterController characterController;

    [SerializeField]
    private bool isPlayer;
    private bool isNPC;
    private bool isNPCandPlayer; 

    public bool IsPlayer => isPlayer;
    public bool IsNPC => isNPC;
    public bool NpcAndPlayer => isNPCandPlayer; 

    public int Health { get; set; }

    public int Ammo { get; set; }

    
    

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();  
    }
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        characterController.Move(new Vector3(horizontal / 10f, 0, vertical / 10f)); 
    }
}
