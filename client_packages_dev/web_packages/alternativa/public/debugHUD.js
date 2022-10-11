const debugInfo = {
    "fps": 0,
    "position": {},
    "heading": 0,
    "velocity": 0,
}

function renderDebugInfo() {
    document.getElementById("debugInfo_fps").innerText = "FPS: " + debugInfo.fps;
    document.getElementById("debugInfo_position").innerText = "Position: " + `x: ${debugInfo.position.x.toFixed(2)}, y: ${debugInfo.position.y.toFixed(2)}, z: ${debugInfo.position.z.toFixed(2)}`;
    document.getElementById("debugInfo_heading").innerText = "Heading: " + debugInfo.heading.toFixed(2);
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
