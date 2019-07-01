import { Component, OnInit } from '@angular/core';

import { Game } from '../Models/game';
import { Player } from '../Models/player';
import { mapToMapExpression } from '@angular/compiler/src/render3/util';
import { Space } from '../Models/space';
import { GameService } from '../Services/game.service';
import { CdkDragDrop, transferArrayItem, moveItemInArray, CdkDrag, CdkDropList } from '@angular/cdk/drag-drop';
import { HostListener } from '@angular/core';
import { Key } from 'protractor';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css'],
  providers: [GameService]
})
export class GameComponent implements OnInit {
  Game: Game;

  constructor(
    private gameService: GameService,
  ) { }

  ngOnInit() {
    this.Game = this.gameService.Game;
  }

  public drop = (event: CdkDragDrop<string[]>) => {
    if (event.previousContainer != event.container) {
      transferArrayItem(event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex);
      let previousSpace = this.findSpace(event.previousContainer.id);
      let newSpace = this.findSpace(event.container.id);

      this.gameService.Move(this.Game, previousSpace, newSpace);
    }
  }


  public Reset(){
    this.Game = this.gameService.Reset();
  }

  public EndTurn(){
    this.gameService.EndTurn(this.Game);
  }

  public isOccupied = (drag: CdkDrag, drop: CdkDropList) => {
    let space = this.findSpace(drop.id);
    if (space == null)
      return true;
    if (drop.data.length > 0)
      return false;
    if (space.state == 0) {
      return true;
    }
    return false;
  }

  private findSpace(cords: string): Space {  
    var spaceCords = cords.split(',');
    if (cords.charAt(0) == "-") {
      cords = cords.substr(1);
      spaceCords = cords.split(",");
      return <Space>this.Game.map.startSpaces[parseInt(spaceCords[1])]
    }
    if (spaceCords.length == 2 && parseInt(spaceCords[0]) >= 0){
      return this.Game.map.spaces[parseInt(spaceCords[0])][parseInt(spaceCords[1])];
    }
    return null;
  }
}
