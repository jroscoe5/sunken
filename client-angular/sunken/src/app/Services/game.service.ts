import { Injectable } from '@angular/core';

import { Game } from '../Models/game'
import { Map } from '../Models/map';
import { Space } from '../Models/space';
import { Player } from '../Models/player';

@Injectable({
  providedIn: 'root'
})
export class GameService {
  playerImgs = [
    "../../assets/imgs/panda.png",
    "../../assets/imgs/lion.png",
    "../../assets/imgs/monkey.png",
    "../../assets/imgs/croc.png"
  ]
  playerNames = [
    "Panda",
    "Lion",
    "Monkey",
    "Croc"
  ]
  constructor() { }

  createGame(size: number = 10): Game {
    // create tiles for board
    let tiles = [];
    for (let x = 0; x < size; x++) {
      tiles[x] = [];
      for (let y = 0; y < size; y++) {
        tiles[x][y] = new Space({
          x: x,
          y: y,
        });
      }
    }
    let players = [];
    for (let z = 0; z < 4; z++){
      players[z+1] = new Player({
        id: z+1,
        img: this.playerImgs[z],
        name: this.playerNames[z]
      });
    }
    let game = new Game({
      id: this.getRandomInt(0, 1000),
      map: new Map({
        spaces: tiles
      }),
      players: players
    });
    game = this.setRandomBoard(game, size)
    return game;
  }

  getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
  }

  setRandomBoard(game: Game, size: number) {
    let playerCount = 0;
    let spaces = game.map.spaces;
    for (let x = 0; x < size; x++) {
      for (let y = 0; y < size; y++) {
        let newState = this.getRandomInt(0, 3);
        let space = spaces[x][y];
        if (newState == 1 && playerCount < 4){
          space.state = newState;
          playerCount++;
          let playerId = playerCount;
          space.player = [game.players[playerId]];
          let player = <Player>game.players[playerId];
          player.space = space;
          player.notMyTurn = true;
        }
        else if (newState != 1) {
          space.state = newState
          space.player = [];
        }
        else {
          space.state = 0;
          space.player = [];
        }
      }
    }
    game.order = [1,2,3,4];
    game.turnNum = 0;
    game.turn = <Player>game.players[game.order[game.turnNum]];
    game.turn.notMyTurn = false;
    game.turn.space.state = 4;
    return game;
  }

  updateGame(game: Game, oldSpace: Space, newSpace: Space){
    let player = game.turn;
    if (oldSpace){
      oldSpace.state = 0;
    }
    if (newSpace){
      newSpace.state = 1;
    }
    player.space = newSpace;
    this.updateTurn(game);
    
  }

  private updateTurn(game: Game){
    console.log("old Turn: " + game.turnNum);
    let player = <Player>game.players[game.order[game.turnNum]];
    player.space.state = 1;
    player.notMyTurn = true;
    if (game.turnNum == 3){
      game.turnNum = 0;
    }
    else{
      game.turnNum++;
    }
    game.turn = <Player>game.players[game.order[game.turnNum]];
    game.turn.notMyTurn = false;
    game.turn.space.state = 4;
    console.log("new Turn: " + game.turnNum);
  }
}
