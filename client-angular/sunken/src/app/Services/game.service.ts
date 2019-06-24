import { Injectable } from '@angular/core';

import { Game } from '../Models/game'
import { Map } from '../Models/map';
import { Space } from '../Models/space';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  constructor() { }

  createBoard(size: number = 5): Game {
    // create tiles for board
    let tiles = [];
    for (let x = 0; x < size; x++) {
      tiles[x] = [];
      for (let y = 0; y < size; y++) {
        tiles[x][y] = new Space({
          x: x,
          y: y
        });
      }
    }
    let game = new Game({
      id: this.getRandomInt(0, 1000),
      map: new Map({
        spaces: tiles
      })
      // add players
    });
    game = this.setRandomBoard(game, size)
    return game;
  }

  getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
  }

  setRandomBoard(game: Game, size: number) {
    for (let x = 0; x < size; x++) {
      for (let y = 0; y < size; y++) {
        game.map.spaces[x][y].state = this.getRandomInt(0, 3);
      }
    }
    return game;
  }
}
