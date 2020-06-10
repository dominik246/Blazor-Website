function GetElements(sortName) {
    let grid = document.getElementsByClassName("unit");
    let arr = [];
    // arr.push() has to be [index, text, height, [h, s, v], sortName]
    for (let item of grid) {
        let unit = window.getComputedStyle(document.getElementById(item.id));
        let color = unit.getPropertyValue("background-color");
        let individualRgb = getRGBValues(color);
        let hsv = rgb2hsv(individualRgb.r, individualRgb.g, individualRgb.b);
        arr.push([item.id, item.id.toString(), unit.getPropertyValue("height"), [hsv.h, hsv.s, hsv.v], sortName]);
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

    // arr.push() has to be [index, text, height, [h, s, v], sortName]
    for (i = 0; i < arr.length; i++) {
        let height = arr[i][2];
        let index = arr[i][0];
        let color = calculateHSL(arr[i][3][0], arr[i][3][1], arr[i][3][2]);
        let hslColor = "hsl(" + Math.floor(color.h) + ", " + Math.floor(color.s) + "%, " + Math.floor(color.l) + "%)";

        let div = document.createElement("div");
        div.className = "unit";
        div.style.setProperty("--positionInGrid", index.toString());
        div.style.height = height.toString() + "px";
        div.id = index.toString();
        div.innerHTML = arr[i][1];
        div.style.setProperty("background-color", hslColor);
        container.appendChild(div);
    }
}

function makeRandomColor() {
    return "#" + Math.random().toString(16).slice(2, 8);
}

function rgb2hsv(r, g, b) {
    let rabs, gabs, babs, rr, gg, bb, h, s, v, diff, diffc, percentRoundFn;
    rabs = r / 255;
    gabs = g / 255;
    babs = b / 255;
    v = Math.max(rabs, gabs, babs),
        diff = v - Math.min(rabs, gabs, babs);
    diffc = c => (v - c) / 6 / diff + 1 / 2;
    percentRoundFn = num => Math.round(num * 100) / 100;
    if (diff == 0) {
        h = s = 0;
    } else {
        s = diff / v;
        rr = diffc(rabs);
        gg = diffc(gabs);
        bb = diffc(babs);

        if (rabs === v) {
            h = bb - gg;
        } else if (gabs === v) {
            h = (1 / 3) + rr - bb;
        } else if (babs === v) {
            h = (2 / 3) + gg - rr;
        }
        if (h < 0) {
            h += 1;
        } else if (h > 1) {
            h -= 1;
        }
    }

    return {
        h: Math.round(h * 360),
        s: percentRoundFn(s * 100),
        v: percentRoundFn(v * 100)
    };
}

function getRGBValues(str) {
    let vals = str.substring(str.indexOf('(') + 1, str.length - 1).split(', ');
    return {
        'r': vals[0],
        'g': vals[1],
        'b': vals[2]
    };
}

function calculateHSL(h, s, v) {
    // determine the lightness in the range [0,100]
    let l = (2 - s / 100) * v / 2;
    let divisor = (l < 50 ? l * 2 : 200 - l * 2);

    // correct a division-by-zero error
    if (divisor === 0) {
        divisor = Infinity;
    }

    // return the HSL components
    return {
        'h': h,
        's': s * v / divisor,
        'l': l
    };
}