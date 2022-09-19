export class BaseModel<T> {
  constructor(rawObject: T) {
    Object.assign(this, rawObject)
  }

  toJSON() {
    return JSON.stringify(this)
  }
}
