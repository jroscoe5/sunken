import { Space } from './space';
import { Stat } from './stat';
import { Worn } from './worn';
import { Rucksack } from './rucksack';

export class Character {
    id: string;
    img: string;
    name: string;
    stats: Stat[];
    worn: Worn;
    rucksack: Rucksack[];

    // inflictions
    // brands

    constructor(values: Object = {}) {
        Object.assign(this, values);
      }
}

