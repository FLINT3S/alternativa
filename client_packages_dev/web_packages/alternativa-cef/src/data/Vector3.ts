export class Vector3 {
  x: number;
  y: number;
  z: number;

  constructor(x: number, y: number, z: number) {
    this.x = x;
    this.y = y;
    this.z = z;
  }

  static fromArray(arr: number[]): Vector3 {
    return new Vector3(arr[0], arr[1], arr[2]);
  }

  static fromVector3Mp(vec: any): Vector3 {
    return new Vector3(vec.x, vec.y, vec.z);
  }

  toString(): string {
    return `x: ${this.x.toFixed(3)}, y: ${this.y.toFixed(3)}, z: ${this.z.toFixed(3)}`;
  }
}
