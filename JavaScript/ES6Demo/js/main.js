/*
Need transpiler (babel or webpack) to work
*/
//import * as math from 'math.js'
//import { pi, sum } from './math.js';

class Product {
    constructor(name) {
        this.name = name;
    }

    capitalize() { return this.name.toUpperCase() };
}

window.onload = _ => {
    console.log("Loop with var");
    console.log(i);
    console.log("Starting loop");
    for (var i = 0; i < 10; i++) {
        console.log(i);
    }
    console.log("Ending loop");
    console.log(i);

    
    console.log("Loop with let");
    //this produces error
    //console.log(x);
    console.log("Starting loop");
    for (let x = 0; x < 10; x++) {
        console.log(x);
    }
    console.log("Ending loop");
    //this produces error too
    //console.log(x);


    //constant declaration
    const version = '1.1.1';

    /*
    Need transpiler (babel or webpack) to work
    */
    //let f = sum(pi, 5);
    //console.log(f);

    let p = new Product('cpu');
    console.log(p.capitalize());
}
