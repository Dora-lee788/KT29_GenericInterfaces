namespace KT29_GenericInterfaces
{
    public interface IContainer<out T>
    {
        T GetItem();

        //void SetItem(T item);
        //попытка добавить метод, принимающий T как параметр, не должна компилироваться при объявленной ковариантности
    }

    public class Box<T> : IContainer<T>
    {
        private T item;

        public Box(T item) => this.item = item;

        public T GetItem() => item;
    }

    public class Animal { }

    public class Dog : Animal { }

    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n1. Проверить ковариантность интерфейса");
                Console.WriteLine("2. Проверить инвариантность класса");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите действие: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        IContainer<Animal> c = new Box<Dog>(new Dog());

                        Console.WriteLine(c.GetItem().GetType().Name);
                        break;

                    case "2":
                        //Box<Animal> b = new Box<Dog>(new Dog()); 
                        //напрямую (без интерфейса) НЕ присваивается переменной Box<Animal>
                        Console.WriteLine(
                            "Box<Animal> b = new Box<Dog>(new Dog());");
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Нет такого пункта.");
                        break;
                }
            }
        }
    }
}

