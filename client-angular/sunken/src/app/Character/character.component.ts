import { Component, OnInit } from '@angular/core';
import { Character } from '../Models/character';
import { CharacterService } from '../Services/character.service';

@Component({
  selector: 'app-character',
  templateUrl: './character.component.html',
  styleUrls: ['./character.component.css'],
  providers: [CharacterService]
})
export class CharacterComponent implements OnInit {
  Character: Character;

  constructor(
    private characterService: CharacterService,
  ) { }

  ngOnInit() {
    this.Character = this.characterService.Character;
    console.log(this.Character);
  }

}
