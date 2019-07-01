export class Stats {
    health: Stat;
    tenacity: Stat;
    defence: Stat;
    initiative: Stat;
    faith: Stat;
    constructor() {
        this.health = new Stat({
            name: "Health",
            max:3,
            current:3
        });
        this.tenacity = new Stat({
            name: "Tenacity",
            max:3,
            current:3
        });
        this.defence = new Stat({
            name: "Defence",
            max:3,
            current:3
        });
        this.initiative = new Stat({
            name: "Initiative",
            max:3,
            current:3
        });
        this.faith = new Stat({
            name: "Faith",
            max:3,
            current:3
        });
    }
}

class Stat {
    name: string;
    max: number;
    current: number;
    constructor(values: Object = {}) {

    }
}
