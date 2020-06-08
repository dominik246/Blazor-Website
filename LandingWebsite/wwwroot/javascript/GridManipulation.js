let backgroundColor = "white";
let newType = "basicUnit";
let wallCheckedOnce = false;
let nextOption = "";
let startExists = false;
let finishExists = false;

function UnitClicked(stringId) {
    let unitString = [];
    let unit = document.getElementById(stringId);
    let type = unit.style.getPropertyValue("--unitType");

    if (nextOption === "") {
        unitString.push("");
        unitString.push("");
        return unitString;
    }

    if (newType === "startUnit") {
        if (startExists) {
            unitString.push("This already exists! You can have only one Start unit.");
            unitString.push("error");
            return unitString;
        }
        else
            startExists = true;
    }
    else if (newType === "finishUnit") {
        if (finishExists) {
            unitString.push("This already exists! You can have only one Finish unit.");
            unitString.push("error");
            return unitString;
        }
        else
            finishExists = true;
    }
    else if (newType === "wallUnit") {
        if (wallCheckedOnce) {
            unitString.push("");
            unitString.push("");
        }
        else {
            wallCheckedOnce = true;
            unitString.push("Click Visualize when you're ready.");
            unitString.push("success");
        }
    }
    else if (newType === "checkpointUnit") {
        //WIP
    }

    unit.style.setProperty("background-color", backgroundColor);
    unit.style.setProperty("--unitType", newType);

    if (nextOption === "Remove") {
        unitString.push("");
        unitString.push("");

        return unitString;
    }

    unitString.push("Now click the " + nextOption + " button.");
    unitString.push("success");

    return unitString;
}

function OptionsButton(option) {
    let toastString = [];

    switch (option) {
        case "start":
            backgroundColor = "yellow";
            newType = "startUnit";
            nextOption = "Finish";
            break;
        case "finish":
            backgroundColor = "purple";
            newType = "finishUnit";
            nextOption = "Wall";
            break;
        case "wall":
            backgroundColor = "black";
            newType = "wallUnit";
            nextOption = "Visualize";
            break;
        case "remove":
        case "checkpoint":
        default:
            backgroundColor = "white";
            newType = "basicUnit";
            nextOption = "Remove";
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