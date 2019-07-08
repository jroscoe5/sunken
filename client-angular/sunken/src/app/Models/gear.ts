import { Item } from './item';

export class Gear {
    _items: Item[];
    main_hand: Item;
    off_hand: Item;
    garb: Item;
    trinket_pri: Item;
    trinket_sec: Item;
    trinket_tri: Item;

    get items(): Item[] {
        return [
            this.main_hand,
            this.off_hand,
            this.garb,
            this.trinket_pri,
            this.trinket_sec,
            this.trinket_tri
        ]
    }

    constructor(values: Object = {}) {
        Object.assign(this, values);
    }
}
