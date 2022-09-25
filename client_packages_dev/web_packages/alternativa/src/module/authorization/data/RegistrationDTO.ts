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

  loginCheck: {
    loading: boolean,
    available: boolean,
    error: boolean,
  } = {
    loading: false,
    available: false,
    error: false,
  };

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
      trigger: ['input', 'blur'],
      validator: (rule: FormItemRule, value: string) => {
        if (!value) {
          return new Error('Введи логин')
        }

        if (value.length < 4) {
          return new Error('Логин должен содержать не менее 4 символов')
        }

        if (this.loginCheck.error) {
          return new Error('Ошибка проверки логина')
        }

        if (!this.loginCheck.available && !this.loginCheck.loading) {
          return new Error('Логин занят')
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
      trigger: ['input', 'blur'],
      validator: (rule: FormItemRule, value: string) => {
        if (!value) {
          return new Error('Введи электронную почту')
        }

        if (!/(.+)@(.+){2,}\.(.+){2,}/.test(value)) {
          return new Error('Некорректная почта')
        }

        if (this.emailCheck.error) {
          return new Error('Ошибка проверки')
        }

        if (!this.emailCheck.available) {
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
