export function getSecondsTimeString(seconds: number): string {
  const hours = Math.floor(seconds / 3600);
  const minutes = Math.floor((seconds - hours * 3600) / 60);
  const secondsLeft = seconds - hours * 3600 - minutes * 60;

  return `${hours}:${minutes}:${secondsLeft}`;
}

export function getTimeBetweenDates(date1: Date, date2: Date): string {
  const seconds = Math.floor((date2.getTime() - date1.getTime()) / 1000);
  const hours = Math.floor(seconds / 3600);
  const minutes = Math.floor((seconds - hours * 3600) / 60);
  const secondsLeft = seconds - hours * 3600 - minutes * 60;

  return `${hours}:${minutes}:${secondsLeft}`;
}
