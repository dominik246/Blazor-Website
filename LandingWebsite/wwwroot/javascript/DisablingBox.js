async function Disable() {
    new Promise(() => {
        let unitBoxes = document.getElementsByClassName("sub_box disabledBox");
        if (unitBoxes[0] === null) {
            return;
        }
        for (let item of unitBoxes) {
            item.style.setProperty("cursor", "not-allowed");
            // bug, doesn't show the cursor as "not-allowed"
        };
    });
}