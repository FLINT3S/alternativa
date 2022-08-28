import {VirtualKey} from "../utils/virtualKeys";

mp.keys.bind(VirtualKey.VK_OEM_3, true, () => {
  mp.gui.cursor.visible = !mp.gui.cursor.visible
})

export const showCursor = () => {
  mp.gui.cursor.visible = true
}
