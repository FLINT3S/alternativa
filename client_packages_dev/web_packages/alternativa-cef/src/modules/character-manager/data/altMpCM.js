import {altMP} from "@/connect/events/altMP";

export const altMpCM = new altMP("CharacterManager", "0.0.1")
export const parseJson = (...json) => {
    return new Promise((resolve, reject) => {

        try {
            if (json.length === 1) {
                resolve(JSON.parse(json[0]))
            } else {
                resolve(json.map((item) => {JSON.parse(item)}))
            }
        } catch (e) {
            reject(e)
        }
    })
}
