import type {FormItemRule, FormRules} from "naive-ui";
import {ValidateRules} from "@/data/Validate";

export class LoginDTO extends ValidateRules {
  login: string = '';
  password: string = '';

  get dto(): Array<string> {
    return [this.login, this.password]
  }

  rules: FormRules = {
    login: {
      required: true,
      trigger: ['input', 'blur'],
      validator: (rule: FormItemRule, value: string) => {
        if (!value) {
          return new Error('Введи логин')
        }

        return true
      }
    },
    password: {
      required: true,
      trigger: ['input', 'blur'],
      validator: (rule: FormItemRule, value: string) => {
        if (!value) {
          return new Error('Введи пароль')
        }

        return true
      }
    }
  }
}
