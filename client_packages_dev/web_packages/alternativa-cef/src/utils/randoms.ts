export const getRandomArrayElement = (array: any[]) => {
  return array[Math.floor(Math.random() * array.length)]
}

export const getRandomFloat = (min: number, max: number, toFixed = 0) => {
  const r = Math.random() * (max - min) + min
  return toFixed ? parseFloat(r.toFixed(toFixed)) : r
}

export const getRandomInt = (min: number, max: number) => {
  return Math.floor(Math.random() * (max - min + 1)) + min
}
