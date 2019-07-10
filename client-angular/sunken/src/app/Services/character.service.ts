import { Injectable } from '@angular/core';
import { Character } from '../Models/character';
import { Stat } from '../Models/stat';
import { Item } from '../Models/item';
import { Worn } from '../Models/worn';

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
      img: "monkey.png",
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
      worn: new Worn({
        main_hand: new Item({
          name: "MainHand",
          img: "mainhand.png",
          type: "MainHand"
        }),
        off_hand: new Item({
          name: "OffHand",
          img: "offhand.png",
          type: "OffHand"
        }),
        garb: new Item({
          name: "Garb",
          img: "garb.png",
          type: "Garb"
        }),
        trinket_pri: new Item({
          name: "Trinket 1",
          img: "trinket.png",
          type: "Trinket"
        }),
        trinket_sec: new Item({
          name: "Trinket 2",
          img: "trinket.png",
          type: "Trinket"
        }),
        trinket_tri: new Item({
          name: "Trinket 3",
          img: "trinket.png",
          type: "Trinket"
        })
      }),
      rucksack: [
        
      ]
    });
    return character;
  }

}