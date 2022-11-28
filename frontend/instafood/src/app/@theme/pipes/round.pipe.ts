import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'round' })
export class RoundPipe implements PipeTransform {

  transform(input: number): number {
    return Math.round((input + Number.EPSILON) * 100) / 100
    // return (input.toFixed(2)) as number;
    // return Math.round(input);
  }
}
