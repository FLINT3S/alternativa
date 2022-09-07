import {lmbPressed, lmbHoldCoords} from "./cursorManager";
import {logger} from "../utils/logger";

export const rotateCameraSettings = {
  mouseSensitivity: 100,
  zoomSpeed: 1.5,
  minZoom: 18.0,
  maxZoom: 75.0,
  radius: 1.7,
  angleDiv: 0.5,
  pointingPosition: {x: 754.459, y: 318.391, z: 176.0},
  limits: {
    zAngleMin: -0.4,
    zAngleMax: 0.7,
    angleMin: -2,
    angleMax: 0.3
  },
  checkFunc: () => true
}

export const rotateCameraVariables = {
  angle: 0,
  zAngle: 0,
  forceRenderOnce: false
}

// @ts-ignore
export const rotateCameraSafeZone = {xGe: 250, xLe: mp.game.graphics.getScreenResolution().x,yGe: 0, yLe: mp.game.graphics.getScreenResolution().y};

export let activeRotateCamera: CameraMp = null;

export const setActiveRotateCamera = (camera: CameraMp) => {
  activeRotateCamera = camera;
}

export const removeRotateCamera = () => {
  try {
    mp.events.remove("render", rotateCameraRenderHandler)
  } catch (e) {
    console.log(e)
  }
}

const rotateCameraRenderHandler = () => {
  if (activeRotateCamera !== null && activeRotateCamera.isActive() && activeRotateCamera.isRendering()) {

    mp.game.controls.disableAllControlActions(2);
    let x = (mp.game.controls.getDisabledControlNormal(7, 1) * rotateCameraSettings.mouseSensitivity);
    let y = (mp.game.controls.getDisabledControlNormal(7, 2) * rotateCameraSettings.mouseSensitivity);
    let zoomIn = (mp.game.controls.getDisabledControlNormal(2, 40) * rotateCameraSettings.zoomSpeed);
    let zoomOut = (mp.game.controls.getDisabledControlNormal(2, 41) * rotateCameraSettings.zoomSpeed);

    const allowControlHold =
      lmbHoldCoords.x > rotateCameraSafeZone.xGe &&
      lmbHoldCoords.x < rotateCameraSafeZone.xLe &&
      lmbHoldCoords.y > rotateCameraSafeZone.yGe &&
      lmbHoldCoords.y < rotateCameraSafeZone.yLe

    if ((lmbPressed && allowControlHold && rotateCameraSettings.checkFunc()) || rotateCameraVariables.forceRenderOnce) {
      rotateCameraVariables.forceRenderOnce = false

      const angleDelta = x / (300 / rotateCameraSettings.angleDiv);
      if (rotateCameraVariables.angle < rotateCameraSettings.limits.angleMax && x < 0) {
        rotateCameraVariables.angle -= angleDelta
      } else if (rotateCameraVariables.angle > rotateCameraSettings.limits.angleMin && x > 0) {
        rotateCameraVariables.angle -= angleDelta
      }

      const zAngleDelta = (-y / (500 / rotateCameraSettings.angleDiv))
      if (rotateCameraVariables.zAngle < rotateCameraSettings.limits.zAngleMax && y > 0) {
        rotateCameraVariables.zAngle -= zAngleDelta
      } else if (rotateCameraVariables.zAngle > rotateCameraSettings.limits.zAngleMin && y < 0) {
        rotateCameraVariables.zAngle -= zAngleDelta
      }

      let camX = rotateCameraSettings.radius * Math.cos(rotateCameraVariables.angle) - rotateCameraSettings.pointingPosition.x
      let camY = rotateCameraSettings.radius * Math.sin(rotateCameraVariables.angle) + rotateCameraSettings.pointingPosition.y
      let camZ = rotateCameraSettings.radius * Math.tan(rotateCameraVariables.zAngle) + rotateCameraSettings.pointingPosition.z

      activeRotateCamera.setCoord(camX, camY, camZ);
    }

    if (zoomIn > 0 && mp.gui.cursor.position[0] < 900) {
      let currentFov = activeRotateCamera.getFov();
      currentFov -= zoomIn
      if (currentFov < rotateCameraSettings.minZoom)
        currentFov = rotateCameraSettings.minZoom
      activeRotateCamera.setFov(currentFov)
    } else if (zoomOut > 0 && mp.gui.cursor.position[0] < 900) {
      let currentFov = activeRotateCamera.getFov();
      currentFov += zoomOut
      if (currentFov > rotateCameraSettings.maxZoom)
        currentFov = rotateCameraSettings.maxZoom
      activeRotateCamera.setFov(currentFov)
    }
  }
}

mp.events.add("render", rotateCameraRenderHandler);
