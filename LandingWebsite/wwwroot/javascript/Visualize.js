async function GetGrid() {
    let grid = document.getElementsByClassName("grid_unit");
    let output = [[], [], [], [], []];
    let finishId = "";
    let startId = "";

    new Promise(() => {
        for (let item of grid) {
            if (document.getElementById(item.id).style.getPropertyValue("--unitType") === "wallUnit") {
                output[2].push(item.id);
            }
            if (document.getElementById(item.id).style.getPropertyValue("--unitType") === "checkpointUnit") {
                output[3].push(item.id);
            }
            if (document.getElementById(item.id).style.getPropertyValue("--unitType") === "startUnit") {
                output[0].push(item.id);
                startId = item.id;
            }
            if (document.getElementById(item.id).style.getPropertyValue("--unitType") === "finishUnit") {
                output[1].push(item.id);
                finishId = item.id;
            }
        }
    });

    new Promise(() => {
        // assign to arr[3] in sorted order

        output[3].unshift(startId); // we have to ensure that Start is the first item in the list

        output[3].push(finishId); // we have to ensure that Finish is the last item in the list

        // we're providing the grid length and hight in the output
        output[4].push(document.getElementsByClassName("grid_div")[0].children.length);
        output[4].push(document.getElementsByClassName("grid_div")[0].children[0].children.length);
    });

    return output;
}

async function Visualize(result) {
    new Promise(() => {
        let grid = document.getElementsByClassName("grid_unit");

        for (let unit of grid) {
            if (unit.style.getPropertyValue("background-color") === "blue") {
                unit.style.setProperty("background-color", "white");
                unit.style.setProperty("--unitType", "basicUnit");
            }
        }
    });
    new Promise(() => {
        result.forEach((item) => {
            let id = item[0] + ", " + item[1];
            let unit = document.getElementById(id);

            if (unit === null) {
                return;
            }

            if (unit.style.getPropertyValue("background-color") !== "yellow" && //start
                unit.style.getPropertyValue("background-color") !== "purple" && // finish
                unit.style.getPropertyValue("background-color") !== "green") {  // checkpoint

                unit.style.setProperty("background-color", "blue");
            }
        });
    });
}