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

  constructor(
    private gameService: GameService
  ) {
    this.Game = this.gameService.createBoard(this.MAP_SIZE);
  }

  ngOnInit() {
    
  }
}
