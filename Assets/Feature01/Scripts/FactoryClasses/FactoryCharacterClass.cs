using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryCharacterClass 
{

    Dictionary<Instantiation.characterList, CharacterAbstractClass> characters = new Dictionary<Instantiation.characterList, CharacterAbstractClass>()
    {
        {Instantiation.characterList.player,new Player()},
        {Instantiation.characterList.enemy,new Enemy()}

    };

    public CharacterAbstractClass GetCharacter(Instantiation.characterList character)
    {
    return characters[character];
    }

}
