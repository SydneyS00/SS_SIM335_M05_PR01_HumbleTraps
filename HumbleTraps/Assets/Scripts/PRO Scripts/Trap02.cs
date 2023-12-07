using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap02 : MonoBehaviour
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

    public class MyTrap02
    {
        public void HandleCharacterEntered(IPlayer characterMover, TrapTargetType trapTargetType)
        {
            if (characterMover.NpcAndPlayer)
            {
                if (trapTargetType == TrapTargetType.Player || trapTargetType == TrapTargetType.NPC)
                {
                characterMover.Ammo--;
                characterMover.Health--; 
                }
            }
            else
            {
                if (trapTargetType == TrapTargetType.Enemy)
                {
                //characterMover.Health--;
                characterMover.Ammo++; 
                }
            }
        }
    }

