import { Space } from './space';
import { Stat } from './stat';

export class Character {
    id: string;
    name: string;
    stats: Stat[];
    // main_hand
    // off_hand
    // garb
    // trinket_pri
    // trinket_sec
    // trinket_tri
    // rucksack
    // inflictions
    // brands

    constructor(values: Object = {}) {
        Object.assign(this, values);
      }
}

