interface Date {
  getCurrentTime(): string
}

Date.prototype.getCurrentTime = function () {
  return `${this.getHours().toString().padStart(2, "0")}:` +
    `${this.getMinutes().toString().padStart(2, "0")}:`+
    `${this.getSeconds().toString().padStart(2, "0")}`
}
