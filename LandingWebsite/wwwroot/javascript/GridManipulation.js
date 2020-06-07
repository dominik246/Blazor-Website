let backgroundColor = "white";
let unitType = "basicUnit";
let startExists = false;
let finishExists = false;

function UnitClicked(unit) {
    let unitString = [];

    if ((startExists && unitType === "startUnit") || (finishExists && unitType === "finishUnit")) {
        unitString.push("This already exists!");
        unitString.push("error");
        return;
    }
    if (!startExists && unitType === "startUnit") {
        unitString.push("Now click the Finish Button.");
        unitString.push("success");
        startExists = true;
    }
    if (!finishExists && unitType === "finishUnit") {
        unitString.push("Now click the Wall Button.");
        unitString.push("success");
        finishExists = true;
    }
    if (unitType === "wallUnit") {
        unitString.push("Click Visualize when you're ready.");
        unitString.push("success");
    }
    
    unit.style.setProperty("background-color", backgroundColor);
    unit.style.setProperty("--unitType", unitType);
}

function OptionsButton(option) {
    let toastString = [];

    switch (option) {
        case "start":
            backgroundColor = "yellow";
            unitType = "startUnit";
            break;
        case "finish":
            backgroundColor = "purple";
            unitType = "finishUnit";
            break;
        case "wall":
            backgroundColor = "black";
            unitType = "wallUnit";
            break;
        default:
            backgroundColor = "white";
            unitType = "basicUnit";
            break;
    }

    toastString.push("Now select a square.");
    toastString.push("success");

    return toastString;
}

function ClearGrid() {
    let grid = document.getElementsByClassName("grid_unit");

    for (let unit of grid) {
        unit.style.setProperty("background-color", "white");
        unit.style.setProperty("--unitType", "basicUnit");
    }

    startExists = false;
    finishExists = false;

    return "Grid Cleared!";
}