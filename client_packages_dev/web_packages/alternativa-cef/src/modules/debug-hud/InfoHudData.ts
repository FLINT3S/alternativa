import {Vector3} from "@/data/Vector3";

export class InfoHudData {
  fps: number;
  position: Vector3;
  heading: number;
  velocityVec: Vector3;

  get speed(): number | undefined {
    if (!this.velocityVec) return undefined;

    const v = Math.sqrt(
      this.velocityVec?.x * this.velocityVec?.x
      + this.velocityVec?.y * this.velocityVec?.y
      + this.velocityVec?.z * this.velocityVec?.z);
    return parseFloat((v * 3.6).toFixed(2))
  }
}
