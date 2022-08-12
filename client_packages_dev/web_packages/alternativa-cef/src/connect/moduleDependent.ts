export abstract class ModuleDependent {
  moduleName: string
  moduleVersion: string

  public constructor(moduleName: string, moduleVersion: string) {
    this.moduleName = moduleName
    this.moduleVersion = moduleVersion
  }
}
