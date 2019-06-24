import { Player } from './player';

enum state{
    Empty = 0,
    Occupied = 1,
    Solid = 2,
    Drop = 3
}

export class Space {
    x: number;
    y: number;
    state: state;
    player: Object[];

    constructor(values: Object = {}) {
        Object.assign(this, values);
      }
}