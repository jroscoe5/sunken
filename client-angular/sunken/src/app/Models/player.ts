export class Player {
    id: string;
    img: string;
    constructor(values: Object = {}) {
        Object.assign(this, values);
      }
}
