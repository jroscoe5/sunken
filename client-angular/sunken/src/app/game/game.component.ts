import { Component, OnInit } from '@angular/core';

import { Game } from '../Models/game';
import { Player } from '../Models/player';
import { mapToMapExpression } from '@angular/compiler/src/render3/util';
import { Space } from '../Models/space';
import { GameService } from '../Services/game.service';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css'],
  providers: [GameService]
})
export class GameComponent implements OnInit {
  Game = new Game();
  MAP_SIZE = 10;
  connectedTo = [];

  constructor(
    private gameService: GameService
  ) {
    this.Game = this.gameService.createGame(this.MAP_SIZE);
    for (let x = 0; x < this.MAP_SIZE; x++) {
      for (let y = 0; y < this.MAP_SIZE; y++) {
        this.connectedTo.push(x+","+y);
      }
    }
    
  }

  ngOnInit() {
    
  }
}
