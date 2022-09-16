interface Date {
  getCurrentTime(): string
}

/*
* @returns {string} - текущее время в формате HH:MM:SS
* */
Date.prototype.getCurrentTime = function () {
  return `${this.getHours().toString().padStart(2, "0")}:` +
    `${this.getMinutes().toString().padStart(2, "0")}:`+
    `${this.getSeconds().toString().padStart(2, "0")}`
}
