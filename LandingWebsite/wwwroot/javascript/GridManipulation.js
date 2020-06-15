let backgroundColor = "white";
let newType = "basicUnit";
let wallCheckedOnce = false;
let nextOption = "";
let startExists = false;
let finishExists = false;
let checkPointExists = false;
let checkpointIndex = 0;
let checkpoints = [];

async function UnitClicked(stringId) {
    let unitString = [];
    let unit = document.getElementById(stringId);
    let type = window.getComputedStyle(unit).getPropertyValue("--unitType").replace(/ /g, '');

    new Promise(async () => {
        if (nextOption === "") {
            unitString.push("");
            unitString.push("");
            return unitString;
        }

        if (nextOption !== "Remove" && window.getComputedStyle(unit).getPropertyValue("--unitType").replace(/ /g, '') !== "basicUnit") {
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
            if (checkPointExists) {
                unitString.push("");
                unitString.push("");
            }
            else {
                checkPointExists = true;
                unitString.push("Click Visualize when you're ready.");
                unitString.push("success");
            }

            checkpoints.push([unit.id, 0]);
        }

        if (type === "checkpointUnit" && nextOption === "Remove") {
            let index = checkpoints.findIndex((item) => item[0] === unit.id);
            checkpoints.splice(index, 1); // removing the unit from the arr by index of itself
        }

        // refresh values of only checkpoints (no point of having values to walls or start and finish)
        await RefreshCheckpoints();

        unit.style.setProperty("background-color", backgroundColor);
        unit.style.setProperty("--unitType", newType);

        if (nextOption === "Remove") {
            unitString.push("");
            unitString.push("");
            unit.innerHTML = "";

            if (type === "startUnit") {
                startExists = false;
            }
            if (type === "finishUnit") {
                finishExists = false;
            }

            return unitString;
        }

        unitString.push("Now click the " + nextOption + " button.");
        unitString.push("success");
    });

    return unitString;
}

async function OptionsButton(option) {
    let toastString = [];

    new Promise(() => {
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
            case "checkpoint":
                backgroundColor = "green";
                newType = "checkpointUnit";
                nextOption = "Visualize";
                break;
            case "remove":
            default:
                backgroundColor = "white";
                newType = "basicUnit";
                nextOption = "Remove";
                break;
        }
    });

    toastString.push("Now select a square.");
    toastString.push("success");

    return toastString;
}

async function ClearGrid() {
    let grid = document.getElementsByClassName("grid_unit");

    startExists = false;
    finishExists = false;
    checkPointExists = false;
    checkpoints = [];

    new Promise(() => {
        for (let unit of grid) {
            unit.style.setProperty("background-color", "white");
            unit.style.setProperty("--unitType", "basicUnit");
            unit.innerHTML = "";
        }
    });

    return "Grid Cleared!";
}

function CheckIfValidGraph() {
    if (startExists && finishExists)
        return true;
    else
        return false;
}

async function RefreshCheckpoints() {
    new Promise(() => {
        checkpoints.forEach((item) => {
            let index = checkpoints.indexOf(item);
            item[1] = index;
            document.getElementById(item[0]).innerHTML = (item[1] + 1).toString();
            checkpoints.sort(function (a, b) { return parseInt(document.getElementById(a[1])) - parseInt(document.getElementById(b[1])) });
        });
    });
}
