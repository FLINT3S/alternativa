import {VirtualKey} from "../utils/virtualKeys";
import {keyboardMapping} from "./keyboardManager";

mp.keys.bind(keyboardMapping.ToggleCursor, true, () => {
  mp.gui.cursor.visible = !mp.gui.cursor.visible
})

export const showCursor = () => {
  mp.gui.cursor.visible = true
}

export let lmbPressed = false
export const lmbHoldCoords = {x: null, y: null}
export const lmbLastClickCoords = {x: null, y: null}

mp.events.add('click', (x, y, upOrDown, leftOrRight, relativeX, relativeY, worldPosition, hitEntity) => {
  if (leftOrRight === "left" && upOrDown === "down") {
    lmbPressed = true
    lmbHoldCoords.x = x
    lmbHoldCoords.y = y
    lmbLastClickCoords.x = x
    lmbLastClickCoords.y = y
  } else if (leftOrRight === "left" && upOrDown === "up") {
    lmbPressed = false;
    lmbHoldCoords.x = null;
    lmbHoldCoords.y = null;
  }
})
