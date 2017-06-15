/* kwdikas pou den me endiaferei na exei 'fortwsei' i html (diladi to DOM) */
function toArray(obj) {
    var array = [];
    // iterate backwards ensuring that length is an UInt32
    for (var i = obj.length >>> 0; i--;) {
        array[i] = obj[i].value;
    }
    return array;
}

window.onload = function () {
    var button = document.getElementById("multiplyButton");
    var text = document.getElementById("inputText");
    var result = document.getElementById("result");

    button.onclick = function () {
        var inputnumber = parseFloat(text.value);
        if (!isNaN(inputnumber)) {
            result.innerHTML = inputnumber * 2;
        }
        else {
            result.innerHTML = '';
        }
    }

    /* example 2 */
    var addButton = document.getElementById("addButton");
    var addButtonReduce = document.getElementById("addButtonReduce");
    var inputs = document.querySelectorAll(".addInputs input");
    var addResult = document.getElementById("addResult");

    var addAll = function () {
        var r = 0;
        for (var i = 0; i < inputs.length; i++) {
            var value = parseFloat(inputs[i].value);
            console.log(value);
            if (!isNaN(value)) {
                r += value;
            }
        }
        addResult.innerHTML = r;
    }
    addButton.onclick = addAll;

    var addAllReduce = _ => {
        var array = toArray(inputs);
        addResult.innerHTML = array.reduce((acc, val) => isNaN(parseFloat(val)) ? acc : acc + parseFloat(val), 0);
    }
    addButtonReduce.onclick = addAllReduce;

    var numbers = [1, 2, 3, 4, 5];
    numbers.reduce((acc, val) => acc + val, 0);
    numbers.reduce((acc, val) => acc * val, 1);

}
