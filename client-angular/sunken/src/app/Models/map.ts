import { Space } from "./space"

export class Map {
    spaces: Object[];
    startSpaces: Object[];

    constructor(values: Object = {}) {
        Object.assign(this, values);
      }
}
