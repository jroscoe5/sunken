import { Space } from './space';
import { Stat } from './stat';

export class Player {
    id: string;
    name: string;
    img: string;
    space: Space;
    notMyTurn: boolean;

    constructor(values: Object = {}) {
        Object.assign(this, values);
      }
}
