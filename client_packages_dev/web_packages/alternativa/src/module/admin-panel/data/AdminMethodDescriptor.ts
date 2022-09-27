export type AdminDescriptorParam = {
  type: "string" | "number" | "boolean"
  name: string
  description: string
}


export type AdminMethodDescriptor = {
  name: string
  command: string
  adminLevel: number
  description: string
  params: AdminDescriptorParam[]
}

export type AdminMethodsGroup = {
  [category: string]: AdminMethodDescriptor[]
}


export type AdminMethods = {
  players: AdminMethodsGroup
}

