import {ValidateRules} from "@/data/Validate";
import type {FormRules, FormItemRule} from "naive-ui";

export class RegistrationDTO extends ValidateRules {
  login: string = ""
  password: string = ""
  passwordConfirm: string = ""
  email: string = ""
  promoAgreement: boolean = false
  promocode: string = ""
  ageAgreement: boolean = false
  rulesAgreement: boolean = false
  privacyAgreement: boolean = false

  emailCheck: {
    available: boolean;
    loading: boolean;
    error: boolean;
  } = {
    available: false,
    loading: false,
    error: false
  }

  get dto(): Array<string> {
    return [
      this.login,
      this.password,
      this.email,
    ]
  }

  rules: FormRules = {
    login: {
      required: true,
      trigger: ['input'],
      validator: (rule: FormItemRule, value: string) => {
        if (!value) {
          return new Error('Введи логин')
        }
        return true
      }
    },
    password: {
      required: true,
      trigger: ['input'],
    },
    passwordConfirm: {
      required: true,
      trigger: ['input'],
    },
    email: {
      required: true,
      trigger: ['input'],
      validator: (rule: FormItemRule, value: string) => {
        if (!value) {
          return new Error('Введи электронную почту')
        }

        if (this.emailCheck.error) {
          return new Error('Ошибка проверки')
        }

        if (!this.emailCheck.available && value.includes('@') && value.slice(-1) !== '@') {
          return new Error('Почта уже используется')
        }

        return true
      }
    },
    ageAgreement: {
      trigger: ['change', 'input'],
      validator: (rule: FormItemRule, value: boolean) => {
        if (!value) {
          return new Error('Необходимо согласие')
        }

        return true
      }
    },
    rulesAgreement: {
      trigger: ['change', 'input'],
      validator: (rule: FormItemRule, value: boolean) => {
        if (!value) {
          return new Error('Необходимо согласие')
        }

        return true
      }
    },
    privacyAgreement: {
      trigger: ['change', 'input'],
      validator: (rule: FormItemRule, value: boolean) => {
        if (!value) {
          return new Error('Необходимо согласие')
        }

        return true
      }
    },
  }
}
