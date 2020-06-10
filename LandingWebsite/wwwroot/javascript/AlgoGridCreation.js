function CreateGrid(objRef) {
    let x = 49;
    let y = 25;

    for (i = 0; i < x; i++) {
        let container = document.getElementsByClassName("grid_div")[0];

        let divRow = document.createElement("div");
        divRow.className = "container_div";
        container.appendChild(divRow);

        for (j = 0; j < y; j++) {
            let id = `${j}, ${i}`;
            let unitDiv = document.createElement("div");
            unitDiv.className = "grid_unit";
            unitDiv.id = id;
            unitDiv.onmouseover = function (args) { OnMouseOver(args, objRef, id) };
            unitDiv.onclick = function () { OnMouseClick(objRef, id) };
            container.children[i].appendChild(unitDiv);
        }
    }
}

function OnMouseOver(args, obj, id) {
    if (args.buttons === 1) {
        obj.invokeMethodAsync("UnitClicked", id);
    }
}

function OnMouseClick(obj, id) {
    obj.invokeMethodAsync("UnitClicked", id);
}