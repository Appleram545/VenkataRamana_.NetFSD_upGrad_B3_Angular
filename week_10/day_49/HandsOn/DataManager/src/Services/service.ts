import { Repository } from '../interface/GenericInterface';


export class DataManager<T> implements Repository<T> {
  private items: T[] = [];

  add(item: T): void {
    this.items.push(item);
  }
  getAll(): T[] {
    return this.items;
  }
}

