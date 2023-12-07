using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBehaviour : MonoBehaviour
{
    [SerializeField] private TrapTargetType trapType; 

    private Trap trap; 

    public void Awake()
    {
        trap = new Trap(); 
    }
    private void OnTriggerEnter(Collider other)
    {
        var characterMover = other.GetComponent<IPlayer>();
        trap.HandleCharacterEntered(characterMover, trapType); 
    }
}

public class Trap
{
    public void HandleCharacterEntered(IPlayer characterMover, TrapTargetType trapTargetType)
    {
        if(characterMover.IsPlayer)
        {
            if(trapTargetType == TrapTargetType.Player)
            {
                characterMover.Health--;
            }
        }
        else
        {
            if (trapTargetType == TrapTargetType.NPC)
            {
                characterMover.Health--;
            }
        }
    }
}

//public enum TrapTargetType { Player, NPC }
