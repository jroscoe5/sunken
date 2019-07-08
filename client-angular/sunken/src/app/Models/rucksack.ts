import { Item } from './item';

export class Rucksack {
    maxitems: number = 6;

    _items: Item[];

    get items(): Item[] {
        return this._items;
    }

    public addItem(item: Item) {
        if (this._items.length != this.maxitems) {
            this._items.push(item);
        }
    }

    constructor(values: Object = {}) {
        Object.assign(this, values);
    }
}
