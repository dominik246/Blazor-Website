function GetElements() {
    let grid = document.getElementsByClassName("unit");
    let arr = [];

    for (let item of grid) {
        console.log(item);
        let unit = window.getComputedStyle(document.getElementById(item.id));
        arr.push([unit.getPropertyValue("height"), item.id, unit.getPropertyValue("background-color")]);
    }
    return arr;
}

function GenerateSortingGrid() {
    let container = document.getElementById("sorting_box");

    RemoveAllEntries(container);

    for (i = 0; i < 49; i++) {
        let color = makeRandomColor();
        let div = document.createElement("div");
        div.className = "unit";
        div.id = i.toString();
        div.style.setProperty("--positionInGrid", i.toString());
        div.style.height = (Math.floor(Math.random() * 90) + 1).toString() + "vh";
        div.style.setProperty("background-color", color);
        container.appendChild(div);
    }
}

function RemoveAllEntries(container) {
    while (container.firstChild) {
        container.removeChild(container.lastChild);
    }
}

function Sort(arr) {
    let container = document.getElementById("sorting_box");
    RemoveAllEntries(container);

    for (i = 0; i < arr.length; i++) {
        let height = arr[i][1];
        let index = arr[i][0];
        let color = arr[i][2];

        let div = document.createElement("div");
        div.className = "unit";
        div.style.setProperty("--positionInGrid", index.toString());
        div.style.height = height.toString() + "px";
        div.id = index.toString();
        div.innerHTML = index.toString();
        div.style.setProperty("background-color", color);
        container.appendChild(div);
    }
}

function makeRandomColor() {
    return "#" + Math.random().toString(16).slice(2, 8);
}