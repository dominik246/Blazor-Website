async function CreateGrid(objRef) {
    let x = 49;
    let y = 25;

    new Promise(async () => {
        for (i = 0; i < x; i++) {
            let container = document.getElementsByClassName("grid_div")[0];

            let divRow = document.createElement("div");
            divRow.className = "container_div";
            container.appendChild(divRow);

            new Promise(() => {
                for (j = 0; j < y; j++) {
                    let id = `${j}, ${i}`;
                    let unitDiv = document.createElement("div");
                    unitDiv.className = "grid_unit";
                    unitDiv.id = id;
                    unitDiv.onmouseover = async function (args) { await OnMouseOver(args, objRef, id) };
                    unitDiv.onclick = async function () { await OnMouseClick(objRef, id) };
                    container.children[i].appendChild(unitDiv);
                }
            });
        }
    });
}

async function OnMouseOver(args, obj, id) {
    if (args.buttons === 1) {
        await obj.invokeMethodAsync("UnitClicked", id);
    }
}

async function OnMouseClick(obj, id) {
    await obj.invokeMethodAsync("UnitClicked", id);
}