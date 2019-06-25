import { Space } from './space';

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
