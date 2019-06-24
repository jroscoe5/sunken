import { Injectable } from '@angular/core';

import { Game } from '../Models/game'
import { Map } from '../Models/map';
import { Space } from '../Models/space';
import { Player } from '../Models/player';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  constructor() { }

  createGame(size: number = 5): Game {
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
    for (let x = 0; x < 4; x++){
      players[x] = new Player({
        id: x
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
    for (let x = 0; x < size; x++) {
      for (let y = 0; y < size; y++) {
        let newState = this.getRandomInt(0, 3);

        if (newState == 1 && playerCount < 4){
          game.map.spaces[x][y].state = newState;
          playerCount++;
          let playerId = this.getRandomInt(0,4);
          game.map.spaces[x][y].player = [game.players[playerId]];
        }
        else if (newState != 1) {
          game.map.spaces[x][y].state = newState
        }
        else {
          game.map.spaces[x][y].state = 0;
        }
      }
    }
    return game;
  }
}
