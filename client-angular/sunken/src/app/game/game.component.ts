import { Component, OnInit } from '@angular/core';

import { Game } from '../Models/game';
import { Player } from '../Models/player';
import { mapToMapExpression } from '@angular/compiler/src/render3/util';
import { Space } from '../Models/space';
import { GameService } from '../Services/game.service';
import { CdkDragDrop, transferArrayItem, moveItemInArray, CdkDrag, CdkDropList } from '@angular/cdk/drag-drop';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css'],
  providers: [GameService]
})
export class GameComponent implements OnInit {
  MAP_SIZE = 10;
  Game: Game;

  constructor(
    private gameService: GameService
  ) {}

  ngOnInit() {
    this.Game = this.gameService.createGame(this.MAP_SIZE);
  }

  drop(event: CdkDragDrop<string[]>) {
    if (event.previousContainer != event.container) {
      transferArrayItem(event.previousContainer.data,
                        event.container.data,
                        event.previousIndex,
                        event.currentIndex);
    }
  }

  isOccupied(drag: CdkDrag, drop: CdkDropList){
    let indexes = drop.id.split(',');
    // add space state check here
    if (drop.data[0] == null){
      return true;
    }
    return false;
  }

}
