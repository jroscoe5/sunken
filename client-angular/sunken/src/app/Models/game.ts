import { Map } from "./map";
import { Player } from "./player"

export class Game {
    id: string;
    map: Map;
    players: Player[] = new Array<Player>();

    constructor(values: Object = {}) {
        Object.assign(this, values);
      }
}
