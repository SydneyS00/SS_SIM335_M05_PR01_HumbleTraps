using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using NSubstitute;

public class TrapTests
{
    [Test]
    public void WRONGPlayerEnteringPlayerTargetedTrap_ReducesHealthByOne()
    {
        Trap trap = new Trap();
        IPlayer characterMover = Substitute.For<IPlayer>();
        trap.HandleCharacterEntered(characterMover, TrapTargetType.Player);

        Assert.AreEqual(-1, characterMover.Health);
    }

    [Test]
    public void CORRECT_PlayerEnteringPlayerTargetedTrap_ReducesHealthByOne()
    {
        Trap trap = new Trap();
        IPlayer characterMover = Substitute.For<IPlayer>();
        characterMover.IsPlayer.Returns(true);

        trap.HandleCharacterEntered(characterMover, TrapTargetType.Player);

        Assert.AreEqual(-1, characterMover.Health);
    }

    //Test number 1 - Is an NPC trap that will take all of the ammo from the NPC and not the player
    [Test]
    public void WRONG_NPCEnteringNPCTargetedTrap_ReduceAmmo()
    {
        MyTrap mytrap = new MyTrap(); 
        IPlayer characterMover = Substitute.For<IPlayer>();

        mytrap.HandleCharacterEntered(characterMover, TrapTargetType.NPC); 

        Assert.AreEqual(-1, characterMover.Ammo); 
    }

    [Test]
    public void CORRECT_NPCEnteringNPCTargetedTrap_ReduceAmmo()
    {
        MyTrap mytrap = new MyTrap();
        IPlayer characterMover = Substitute.For<IPlayer>();
        characterMover.IsNPC.Returns(true); 

        mytrap.HandleCharacterEntered(characterMover, TrapTargetType.NPC);

        Assert.AreEqual(-1, characterMover.Ammo);
    }

    //Test number 2 - Is either an NPC or a Player in the trap and if so they reduce both the health and ammo count. If the an enemy is in the trap they get more ammo
    [Test]
    public void WRONG_BothEnteringTargetedTrap_ReduceStuff()
    {
        MyTrap02 myTrap02 = new MyTrap02();
        IPlayer characterMover = Substitute.For<IPlayer>();

        myTrap02.HandleCharacterEntered(characterMover, TrapTargetType.NPC);
        myTrap02.HandleCharacterEntered(characterMover, TrapTargetType.Player);

        Assert.AreEqual(-1, characterMover.Health);
        Assert.AreEqual(-1, characterMover.Ammo);
    }

    [Test]
    public void CORRECT_BothEnteringTargetTrap_ReduceStuff()
    {
        MyTrap02 myTrap02 = new MyTrap02();
        IPlayer characterMover = Substitute.For<IPlayer>();
        characterMover.NpcAndPlayer.Returns(false);

        myTrap02.HandleCharacterEntered(characterMover, TrapTargetType.Enemy);

        Assert.AreEqual(+1, characterMover.Ammo); 

        
    }
}


