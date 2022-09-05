export {};

declare global {
  interface Array<T> {
    getRandomElement(): T,
    getRandomIndex(): number
  }
}

Array.prototype.getRandomElement = function() {
  return this[Math.floor(Math.random() * this.length)]
}

Array.prototype.getRandomIndex = function() {
  return Math.floor(Math.random() * this.length)
}
