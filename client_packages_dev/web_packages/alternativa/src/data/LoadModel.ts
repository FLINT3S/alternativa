import type {altMP} from "@/connect/events/altMP";

export interface ILoadModel {
  loading: boolean;

  load(): Promise<void> | void;
}
