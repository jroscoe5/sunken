import { Map } from "./map";
import { Player } from "./player"

export class Game {
    id: string;
    map: Map;
    players: Object[];

    constructor(values: Object = {}) {
        Object.assign(this, values);
      }
}
