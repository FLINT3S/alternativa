const debugInfo = {
    "fps": 0,
    "position": {},
    "heading": 0,
    "velocity": 0,
}

// get heading as degrees from 0 to 360
// return direction as string +x or -x or +y or -y
function headingAxis(heading) {
    if (heading > 315 || heading <= 45) {
        return "+X";
    } else if (heading > 45 && heading <= 135) {
        return "-Y";
    } else if (heading > 135 && heading <= 225) {
        return "-X";
    } else if (heading > 225 && heading <= 315) {
        return "+Y";
    }
}

function renderDebugInfo() {
    document.getElementById("debugInfo_fps").innerText = "FPS: " + debugInfo.fps;
    document.getElementById("debugInfo_position").innerText = "Position: " + `x: ${debugInfo.position.x.toFixed(2)}, y: ${debugInfo.position.y.toFixed(2)}, z: ${debugInfo.position.z.toFixed(2)}`;
    document.getElementById("debugInfo_heading").innerText = "Heading: " + debugInfo.heading.toFixed(2) + ` (${headingAxis(debugInfo.heading)})`;
    document.getElementById("debugInfo_velocity").innerText = "Velocity: " + debugInfo.velocity.toFixed(2);
}

function setDataRender(data) {
    debugInfo.fps = data.fps;
    debugInfo.position = data.position;
    debugInfo.heading = data.heading;
    debugInfo.velocity = data.velocity;

    renderDebugInfo()
}

window.setDataRender = setDataRender;
console.log("Init debugHUD.js")
