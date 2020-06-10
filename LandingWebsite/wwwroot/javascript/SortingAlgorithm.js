function GetElements(sortName) {
    let grid = document.getElementsByClassName("unit");
    let arr = [];
    // arr.push() has to be [index, text, height, sortName]
    for (let item of grid) {
        let unit = window.getComputedStyle(document.getElementById(item.id));
        arr.push([item.id, item.id.toString(), unit.getPropertyValue("height"), sortName]);
    }
    return arr;
}

function GenerateSortingGrid() {
    let container = document.getElementById("sorting_box");

    RemoveAllEntries(container);

    for (i = 0; i < 49; i++) {
        let div = document.createElement("div");
        div.className = "unit";
        div.id = i.toString();
        div.style.setProperty("--positionInGrid", i.toString());
        div.style.height = (Math.floor(Math.random() * 90) + 1).toString() + "vh";
        div.style.setProperty("background-color", "blue");
        container.appendChild(div);
    }
}

function RemoveAllEntries(container) {
    while (container.firstChild) {
        container.removeChild(container.lastChild);
    }
}

async function Sort(arr) {
    // arr is [originalItem, comparedItem, isMatchForSwitch]
    for (let i = 0; i < arr.length; i++) {
        let comparedElement = document.getElementById(arr[i][1]);
        let originalElement = document.getElementById(arr[i][0]);

        if (comparedElement === null || originalElement === null) {
            return;
        }

        if (arr[i][2] === false) {
            await a(originalElement, comparedElement);
        }
        else {
            await b(originalElement, comparedElement);
        }
    }
    
}

function exchangeElements(element1, element2) {
    let newElement1 = element1.cloneNode(false);
    let newElement2 = element2.cloneNode(false);
    element1.replaceWith(newElement2);
    element2.replaceWith(newElement1);
}

async function a(originalElement, comparedElement) {
    comparedElement.style.setProperty("background-color", "red");
    originalElement.style.setProperty("background-color", "red");
    await delay();
    comparedElement.style.setProperty("background-color", "blue");
    await delay();
}

async function b(originalElement, comparedElement) {
    comparedElement.style.setProperty("background-color", "blue");
    await delay();
    comparedElement.style.setProperty("background-color", "green");
    exchangeElements(comparedElement, originalElement);
    await delay();
}

function delay() {
    return new Promise(resolve => setTimeout(resolve, 20));
}