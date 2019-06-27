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

  createGame(size: number = 10, playerCount: number = 4): Game {
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
    let startTiles = [];
    let players = [];
    for (let z = 0; z < playerCount; z++){
      players[z+1] = new Player({
        id: z+1,
        img: this.playerImgs[z],
        name: this.playerNames[z]
      });
      startTiles[z] = [];
      startTiles[z][0] = new Space({
        x: -1,
        y: z
      });
    }
    let game = new Game({
      id: this.getRandomInt(0, 1000),
      map: new Map({
        spaces: tiles,
        startSpaces: startTiles
      }),
      players: players
    });
    game = this.setRandomBoard(game, size);
    this.NewStart(game, players);
    return game;
  }

  getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
  }

  setRandomBoard(game: Game, size: number) {
    let spaces = game.map.spaces;
    for (let x = 0; x < size; x++) {
      for (let y = 0; y < size; y++) {
        let newState = this.getRandomInt(0, 3);
        let space = spaces[x][y];
        if (newState == 1){
          space.state = 0;
          space.player = [];
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
    

    return game;
  }

  NewStart(game: Game, players: Player[]){
    
    game.order = [1,2,3,4];
    game.turnNum = 0;
    game.turn = <Player>game.players[game.order[game.turnNum]];
    game.turn.notMyTurn = false;
    for (let x = 0; x < game.order.length; x++){
      var space = <Space>game.map.startSpaces[x][0];
      space.player = [game.players[x+1]];
      let player = <Player>game.players[x+1];
      player.space = space;
      player.space.state = 1;
      player.notMyTurn = true;
    }
    game.turn.space.state = 4;
    game.turn.notMyTurn = false;

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
    let player = <Player>game.players[game.order[game.turnNum]];
    if (player.space)
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
  }
}
