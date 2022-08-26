export class RegistrationDTO {
  public login: string
  public password: string
  public email: string

  public validation = {
    login: {
      required: true,
      type: String,
      minLength: 4,
      maxLength: 20,
    },
    password: {
      required: true,
      type: String,
      minLength: 8,
      maxLength: 20,
    }
  }
}
