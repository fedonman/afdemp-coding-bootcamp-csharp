// 1.
var a = 0;
let b = 5;
const c = "constant value";

// 2. 
if (a == 0) {
    console.log("a == 0 is true")
}

if (a == false) {
    console.log("a == false is true")
}

if (a === 0) {
    console.log("a === 0 is true")
}

if (a === false) {
    console.log ("a === false is true")
}

// 3.
const age = 19;
(age > 18) ? console.log("Mike is an adult.") : console.log("Mike is a kid.");

// 4.
for (let i = 0; i <= 20; i++) {
    (i % 2 === 0) ? console.log(`${i} is even`) : console.log(`${i} is odd`);
}

//5. 
//Vanilla JS
function squareVanilla(x) {
    return x * x;
}

let squareES6 = x => x * x;

// 6.
let squareAnonymous = function (x) {
    return x * x;
}

console.log(`Using Vanilla JS: ${squareVanilla(5)}`);
console.log(`Using ES6: ${squareES6(5)}`);
console.log(`Using Anonymous: ${squareAnonymous(5)}`);

// 7.
// The old way (using loop & Vanilla JS)
function sumOfArrayVanilla(array) {
    let sum = 0;
    for (let i = 0; i < array.length; i++) {
        sum += array[i];
    }
    return sum;
}

// The smart way (using es6 array functions)
let sumOfArray = array => array.reduce((acc, val) => acc + val, 0);

let array = [0, 1, 2, 3, 4, 5];
console.log(`Using the OLD way: ${sumOfArrayVanilla(array)}`);
console.log(`Using the GOOD way: ${sumOfArray(array)}`);

// 8.
let factorial = x => {
    if (IsNaN(x) || x < 0 || x > 100) return;
    if (x % 1 !== 0) {
        x = parseInt(x);
    }
    if (x === 0) return 1;
    if (x === 1) return 1;
    return x * factorial(x - 1);
}

console.log(`Factorial of 5 is ${factorial(5)}`);

// 9.
// using VanillaJS syntax (prototypes)
function EventEmitter() {
    this._callbacks = {};

    EventEmitter.prototype._initializeEvent = function (eventName) {
    if (typeof this._callbacks[eventName] == 'undefined') {
        this._callbacks[eventName] = [];
    }
}

EventEmitter.prototype.on = function (eventName, callback) {
    this._initializeEvent(eventName);
    this._callbacks[eventName].push(callback);
}

EventEmitter.prototype.emit = function (eventName, data) {
    this._initializeEvent(eventName);
    for (let i = 0; i < this._callbacks[eventName].length; i++) {
        this._callbacks[eventName][i](data);
    }
}
}

// using ES6 syntax (classes)
class EventEmitterES6 {
    constructor() {
        this._callbacks = {}
    }

    _initializeEvent(eventName) {
        if (typeof this._callbacks[eventName] == 'undefined') {
            this._callbacks[eventName] = [];
        }
    }

    on(eventName, callback) {
        this._initializeEvent(eventName);
        this._callbacks[eventName].push(callback);
    }

    emit(eventName, data) {
        this._initializeEvent(eventName);
        this._callbacks[eventName].map(x => x(data));
    }
}

let emitter = new EventEmitter();
emitter.on('print', console.log);
emitter.on('print', (x) => console.log(x + " " + x));
emitter.emit('print', 'Hello world');

let emitterES6 = new EventEmitterES6();
emitterES6.on('print', console.log);
emitterES6.emit('print', 'Hello world from ES6');