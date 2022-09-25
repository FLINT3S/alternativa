type AdminDescriptorParam = {
  type: "string" | "number" | "boolean"
  name: string
  description: string
}


export class AdminActionDescriptor {
  name: string
  command: string
  adminLevel: number
  description: string
  params: AdminDescriptorParam[]

  constructor(name: string, command: string, adminLevel: number = 0, description: string = '', params: AdminDescriptorParam[] = []) {
    this.name = name
    this.command = command
    this.adminLevel = adminLevel
    this.description = description
    this.params = params
  }
}
