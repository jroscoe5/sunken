export class Stat {
    name: string;
    max: number;
    current: number;
    constructor(values: Object = {}) {
        Object.assign(this, values);
    }
}
