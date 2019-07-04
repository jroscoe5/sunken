export class Stat {
    name: string;
    max: number;
    current: number;
    color: string;
    constructor(values: Object = {}) {
        Object.assign(this, values);
    }
}
