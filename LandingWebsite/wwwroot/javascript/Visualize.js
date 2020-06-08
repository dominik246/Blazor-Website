function GetGrid() {
    let grid = document.getElementsByClassName("grid_unit");
    let output = [[], [], [], []];
    let tmpArr1 = [];
    let finishId = "";
    let startId = "";

    for (let item of grid) {
        if (document.getElementById(item.id).style.getPropertyValue("--unitType") === "startUnit") {
            output[0].push(item.id);
            tmpArr1.push(item.id);
        }
        if (document.getElementById(item.id).style.getPropertyValue("--unitType") === "finishUnit") {
            output[1].push(item.id);
            tmpArr1.push(item.id);
        }
        if (document.getElementById(item.id).style.getPropertyValue("--unitType") === "wallUnit") {
            output[2].push(item.id);
        }
        if (document.getElementById(item.id).style.getPropertyValue("--unitType") === "checkpointUnit") {
            tmpArr1.push(item.id);
        }
    }

    // assign to arr[3] in sorted order
    tmpArr1.forEach(itemId => {
        if (document.getElementById(itemId).style.getPropertyValue("--unitType") === "startUnit") {
            startId = itemId;
            tmpArr1.splice(tmpArr1.indexOf(itemId), 1);
        }
        if (document.getElementById(itemId).style.getPropertyValue("--unitType") === "finishUnit") {
            finishId = itemId;
            tmpArr1.splice(tmpArr1.indexOf(itemId), 1);
        }
    });
    
    output[3].push(startId); // we have to ensure that Start is the first item in the list
    if (tmpArr1.length !== 0) {
        tmpArr1.sort(function (a, b) { return parseInt(document.getElementById(a).innerHTML) - parseInt(document.getElementById(b).innerHTML) });
        tmpArr1.forEach((item) => output[3].push(item));
    } 

    output[3].push(finishId); // we have to ensure that Finish is the last item in the list
    console.log(output[3]);
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

        if (document.getElementById(id).style.getPropertyValue("background-color") !== "yellow" && //start
            document.getElementById(id).style.getPropertyValue("background-color") !== "purple" && // finish
            document.getElementById(id).style.getPropertyValue("background-color") !== "green") {  // checkpoint

            document.getElementById(id).style.setProperty("background-color", "blue");
        }
    });
}