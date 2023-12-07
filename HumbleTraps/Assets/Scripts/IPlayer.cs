using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer
{
   int Health { get; set; }
   bool IsPlayer { get; }
   int Ammo { get; set; }
   bool IsNPC { get; }
   bool NpcAndPlayer { get; }

}
