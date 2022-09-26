type AdminDescriptorParam = {
  type: "string" | "number" | "boolean"
  name: string
  description: string
}


export class AdminMethodDescriptor {
  name: string
  command: string
  adminLevel: number
  description: string
  params: AdminDescriptorParam[]

  constructor(actionObject: any) {
    this.name = actionObject.name
    this.command = actionObject.command
    this.adminLevel = actionObject.adminLevel
    this.description = actionObject.description
    this.params = actionObject.params
  }
}

export type AdminActions = {
  players: AdminMethodDescriptor[]
}
