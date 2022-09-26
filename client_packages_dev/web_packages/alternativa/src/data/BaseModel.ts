export class BaseModel<T = {}> {

  constructor(...args: any[]) {
    if (args.length === 1 && typeof args[0] === 'object') {
      const [json] = args
      this.fromJSON(json)
    }
  }

  fromJSON(json: T) {
    Object.assign(this, json)
  }

  toJSON() {
    return JSON.stringify(this)
  }
}
