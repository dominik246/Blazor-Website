﻿function GetGrid() {
    let grid = document.getElementsByClassName("grid_unit");
    let output = [[], []];

    for (let item of grid) {
        if (window.getComputedStyle(document.getElementById(item.id)).getPropertyValue("--unitType") === "startUnit") {
            output[0].push(item.id);
        }
        if (window.getComputedStyle(document.getElementById(item.id)).getPropertyValue("--unitType") === "finishUnit") {
            output[0].push(item.id);
        }
        if (window.getComputedStyle(document.getElementById(item.id)).getPropertyValue("--unitType") === "wallUnit") {
            output[1].push(item.id);
        }
    }
    return output;
}

function Visualize(result) {

    let grid = document.getElementsByClassName("grid_unit");

    for (let unit of grid) {
        if (unit.style.getPropertyValue("background-color") === "blue") {
            unit.style.setProperty("background-color", "white");
            unit.style.setProperty("--unitType", "basicUnit");
        }
    }

    result.forEach((item) => {
        let id = item[0] + ", " + item[1];

        if (document.getElementById(id).style.getPropertyValue("background-color") !== "yellow" &&
            document.getElementById(id).style.getPropertyValue("background-color") !== "purple") {

            document.getElementById(id).style.setProperty("background-color", "blue");
        }
    });
}