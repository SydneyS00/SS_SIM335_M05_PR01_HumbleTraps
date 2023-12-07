using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap01 : MonoBehaviour
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

public class MyTrap
{
    public void HandleCharacterEntered(IPlayer characterMover, TrapTargetType trapTargetType)
    {
        if (characterMover.IsNPC)
        {
            if (trapTargetType == TrapTargetType.NPC)
            {
                //characterMover.Health--;

                characterMover.Ammo--;
            }
        }
        else
        {
            if (trapTargetType == TrapTargetType.Player)
            {
                //characterMover.Health--;
                
            }
        }
    }
}

public enum TrapTargetType { Player, NPC, Enemy }
