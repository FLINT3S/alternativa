import {email, helpers, maxLength, minLength, required} from "@vuelidate/validators";

export class RegistrationDTO {
  public login: string
  public password: string
  public email: string

  public static validators = {
    login: {
      required: helpers.withMessage("Логин - обязательное поле", required),
      minLength: helpers.withMessage("Логин должен содержать больше 5 символов", minLength(5)),
      maxLength: helpers.withMessage("Логин должен содержать не больше 15 символов", maxLength(15)),
      allowedSymbols: helpers.withMessage("Логин должен содержать только латинские буквы, цифры, знак нижнего подчеркивания, точку и короткое тире",
        helpers.regex(/^[a-zA-Z0-9/.\-_]+$/))
    },
    password: {
      required: helpers.withMessage("Пароль - обязательное поле", required),
      minLength: minLength(8),
    },
    email: {
      required,
      email,
    }
  }
}
