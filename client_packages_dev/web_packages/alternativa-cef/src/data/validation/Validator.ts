type ValidationStrings = "required";
type ValidationFunction<T> = (field_value: T) => [boolean] | [boolean, string]
type ValidationError = {
  name: string,
  description: string,
}
type ValidatorSchema = {
  [key: string]: Array<ValidationStrings | ValidationFunction<any>>
}


export class Validator {
  public object: object
  public schema: ValidatorSchema

  constructor(object: object, schema: ValidatorSchema) {
    this.object = object
    this.schema = schema
  }

  public validate(): { isValid: boolean, fields: object } {
    const result = {
      isValid: true,
      fields: {}
    }

    for (let objectProp of Object.keys(this.object)) {
      // @ts-ignore
      result.fields[objectProp] = {
        isValid: true,
        errors: Array<ValidationError>
      }

      const fieldValidators = this.schema[objectProp]
      if (!fieldValidators) {
        continue
      }

      for (let validator of fieldValidators) {
        if (typeof validator === "string") {
          if (validator === "required") {
            // @ts-ignore
            if (this.object[objectProp] === undefined || this.object[objectProp] === null) {
              // @ts-ignore
              result.fields[objectProp].isValid = false
              // @ts-ignore
              result.fields[objectProp].errors.push("Обязательное")
            }
          }
        } else if (typeof validator === "function") {
          // @ts-ignore
          if (!validator(this.object[objectProp])[0]) {
            // @ts-ignore
            result.fields[objectProp].isValid = false
            // @ts-ignore
            result.fields[objectProp].errors.custom = true
            result.isValid = false
          }
        }
      }
    }

    return result
  }
}
