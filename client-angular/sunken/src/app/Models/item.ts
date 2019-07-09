export class Item {
    name: string;
    img: string;
    type: string;

    constructor(values: Object = {}) {
        Object.assign(this, values);
      }
}
