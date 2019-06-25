import { Map } from "./map";
import { Player } from "./player"

export class Game {
    id: string;
    map: Map;
    players: Object[];
    turn: Player;
    turnNum: number;
    order: number[];

    constructor(values: Object = {}) {
        Object.assign(this, values);
      }
}
