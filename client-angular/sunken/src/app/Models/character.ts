export class Character {
    id: string;
    name: string;
    // main_hand
    //off_hand
    //garb
    //trinket_pri
    //trinket_sec
    // trinket_tri
    //rucksack
    //inflictions
    //brands


    constructor(values: Object = {}) {
        Object.assign(this, values);
      }
}

import { Space } from './space';
import { Stats } from './stats';

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

