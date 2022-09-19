export const parseJson = (...json: Array<string>) => {
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
