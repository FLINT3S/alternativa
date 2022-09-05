export class animationManager {
  static playAnimation(animDict: string, animName: string, flag: number): void {
    mp.events.callRemote("CLIENT:SERVER:Animations:PlayAnimation", animDict, animName, flag)
  }

  static stopAnimation(): void {
    mp.events.callRemote("CLIENT:SERVER:Animations:StopAnimation")
  }

  static playIdleStay(): void {
    animationManager.playAnimation("misshair_shop@barbers", "idle_a_cam", 1)
  }
}
