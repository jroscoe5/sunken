import { Space } from './space';
import { Stat } from './stat';
import { Gear } from './gear';
import { Rucksack } from './rucksack';

export class Character {
    id: string;
    name: string;
    stats: Stat[];
    gear: Gear[];
    rucksack: Rucksack[];

    // inflictions
    // brands

    constructor(values: Object = {}) {
        Object.assign(this, values);
      }
}

