import { Injectable } from '@angular/core';
import { Character } from '../Models/character';
import { Stat } from '../Models/stat';

@Injectable({
  providedIn: 'root'
})
export class CharacterService {
  Character: Character;

  constructor() { 
    this.Character = this.CreateTestCharacter();
  }


  CreateTestCharacter(): Character {
    let character = new Character({
      id: 1,
      name: "Bridger",
      stats: [
        new Stat({
          name: "Health",
          max:3,
          current:3,
          color: "red"
        }),
        new Stat({
          name: "Tenacity",
          max:3,
          current:3,
          color: "orange"
        }),
        new Stat({
          name: "Defence",
          max:3,
          current:3,
          color: "yellow"
        }),
        new Stat({
          name: "Initiative",
          max:3,
          current:3,
          color: "green"
        }),
        new Stat({
          name: "Faith",
          max:3,
          current:3,
          color:"royalblue"
        })
      ],
      gear: [

      ],
      rucksack: [
        
      ]
    });
    return character;
  }

}