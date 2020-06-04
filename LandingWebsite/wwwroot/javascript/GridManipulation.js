let backgroundColor = "white";
let unitType = "basicUnit";
let startExists = false;
let finishExists = false;

function UnitClicked() {
    let start = document.getElementById("startCheck");
    let finish = document.getElementById("finishCheck");

    let target = event.target || event.srcElement;
    let id = target.id;

    let grid = document.getElementsByClassName("grid_unit");

    //let test = document.getElementById("0");
    //console.log(window.getComputedStyle(test));

    for (let unit of grid) {
        let tmp = window.getComputedStyle(unit);
        if (tmp.getPropertyValue("--unitType") == "startUnit" && start.checked) {
            startExists = true;
            return;
            //console.log(startExists);
        }
        if (tmp.getPropertyValue("--unitType") == "finishUnit" && finish.checked) {
            finishExists = true;
            return;
            //console.log(finishExists);
        }
    }

    document.getElementById(id).style.setProperty("background-color", backgroundColor);
    document.getElementById(id).style.setProperty("--unitType", unitType);
}

function CheckBoxCheck(checkbox) {
    let start = document.getElementById("startCheck");
    let finish = document.getElementById("finishCheck");
    let wall = document.getElementById("wallCheck");
    //let checkpoint = document.getElementById("checkpointCheck");

    // makes sure only one checkbox is triggered
    let checkboxes = document.getElementsByName('checkbox');
    checkboxes.forEach((item) => {
        if (item !== checkbox)
            item.checked = false;
    });

    if (start.checked) {
        backgroundColor = "yellow"; // rgb(255, 255, 0)
        unitType = "startUnit";
    }
    else if (finish.checked) {
        backgroundColor = "purple"; // rgb(128, 0, 128)
        unitType = "finishUnit";
    }
    else if (wall.checked) {
        backgroundColor = "black"; // rgb(0, 0, 0)
        unitType = "wallUnit";
    }
    //else if (checkpoint.checked) {
    //    backgroundColor = "green"; // rgb(0, 128, 0)
    //    unitType = "test4";
    //}
    else {
        backgroundColor = "white"; // rgb(255, 255, 255)
        unitType = "basicUnit";
    }
}

function ClearGrid() {
    let grid = document.getElementsByClassName("grid_unit");

    for (let unit of grid) {
        unit.style.setProperty("background-color", "white");
        unit.style.setProperty("--unitType", "basicUnit");
    }

    startExists = false;
    finishExists = false;
}