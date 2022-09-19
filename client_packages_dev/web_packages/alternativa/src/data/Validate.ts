import type {FormRules} from "naive-ui";

type rulesFields = {
  [key: string]: {
    isValid: boolean;
    touched: boolean;
    errors: Array<Error>
    feedback: string;
    touch: () => void;
    touchedInvalid: boolean;
  }
}

export class ValidateRules {
  rules: FormRules = {};
  touchedFields: Set<string> = new Set<string>();

  get validate(): {
    isValid: boolean;
    fields: rulesFields;
    errors: Array<Error>;
    humanErrors: Array<string>
  } {
    const errors: Array<Error> = [];
    const humanErrors: Array<string> = [];
    const fields: rulesFields = {}

    Object.keys(this.rules).forEach((key) => {
      fields[key] = {
        isValid: true,
        touched: false,
        errors: [],
        feedback: "",
        touch: () => {
          this.touchedFields.add(key)
        },
        touchedInvalid: false
      }

      // @ts-ignore
      if (this[key] !== undefined && this[key] !== "") {
        this.touchedFields.add(key);
      }

      if (this.touchedFields.has(key)) {
        fields[key].touched = true;
      }

      const rule: any = this.rules[key];

      if (rule?.validator) {
        if (this.hasOwnProperty(key)) {
          // @ts-ignore
          const validationResult = rule.validator(rule, this[key]);
          if (validationResult instanceof Error) {
            fields[key].isValid = false;
            fields[key].errors.push(validationResult);
            fields[key].feedback += validationResult.message;

            errors.push(validationResult);
            humanErrors.push(validationResult.message);
          }
        }
      }

      if (!fields[key].isValid && fields[key].touched) {
        fields[key].touchedInvalid = true;
      }
    })

    return {isValid: errors.length === 0, errors, humanErrors, fields};
  }
}
