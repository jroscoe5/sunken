import { Space } from './space';
import { Stats } from './stats';

export class Player {
    id: string;
    name: string;
    img: string;
    space: Space;
    notMyTurn: boolean;
    stats: Stats;


    constructor(values: Object = {}) {
        Object.assign(this, values);
      }
}
