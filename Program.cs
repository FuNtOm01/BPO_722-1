using System;

namespace ChessHierarchyApp
{
    // Интерфейс
    public interface IChessPiece
    {
        void DisplayProperties();
    }

    // Базовый абстрактный класс
    public abstract class ChessFigure : IChessPiece
    {
        public string Name { get; protected set; }
        public string Color { get; protected set; }

        // Конструктор базового класса
        public ChessFigure(string name, string color)
        {
        if (string.IsNullOrWhiteSpace(color))
            {
            throw new ArgumentException(
                "Цвет фигуры не может быть пустым.");
            }
        Name = name;
        Color = color;
        }
       
        // Виртуальный метод для второго названия
        public virtual void SecondName()
        {
            Console.WriteLine("Второе русскоязычное название: не предусмотрено.");
        }

        // Абстрактный метод для вывода свойств
        public abstract void DisplayProperties();
    }

    // Промежуточный абстрактный класс для легких фигур
    public abstract class LightPiece : ChessFigure
    {
        public LightPiece(string name, string color) : base(name, color) { }
    }

    // Промежуточный абстрактный класс для тяжелых фигур
    public abstract class HeavyPiece : ChessFigure
    {
        public HeavyPiece(string name, string color) : base(name, color) { }
    }

    //Пешка
    public sealed class Pawn : ChessFigure
    {
        public Pawn(string color) : base("Пешка", color) { }

        public override void DisplayProperties()
        {
            Console.WriteLine($"Свойства -> Название: {Name}, Цвет: {Color}, Роль: Пехота");
        }
    }

    //Король
    public sealed class King : ChessFigure
    {
        public King(string color) : base("Король", color) { }

        public override void DisplayProperties()
        {
            Console.WriteLine($"Свойства -> Название: {Name}, Цвет: {Color}, Статус: Главная фигура");
        }
    }

    //класс Слон легкая фигура
    public sealed class Bishop : LightPiece
    {
        public Bishop(string color) : base("Слон", color) { }

        public override void SecondName()
        {
            Console.WriteLine("Второе русскоязычное название: Офицер");
        }

        public override void DisplayProperties()
        {
            Console.WriteLine($"Свойства -> Название: {Name}, Цвет: {Color}, Категория: Легкая фигура");
        }
    }

    //класс: Ладья Тяжелая фигура)
    public sealed class Rook : HeavyPiece
    {
        public Rook(string color) : base("Ладья", color) { }

        public override void SecondName()
        {
            Console.WriteLine("Второе русскоязычное название: Турка");
        }

        public override void DisplayProperties()
        {
            Console.WriteLine($"Свойства -> Название: {Name}, Цвет: {Color}, Категория: Тяжелая фигура");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ChessFigure[] pieces = new ChessFigure[]
            {
                new Pawn("Белый"),
                new King("Черный"),
                new Bishop("Белый"),
                new Rook("Черный")
            };

            Console.WriteLine("\nВывод информации об объектах:\n");

            foreach (var piece in pieces)
            {
                // Вывод всех свойств через абстрактный метод
                piece.DisplayProperties();

                // Вызов метода SecondName (полиморфное поведение)
                piece.SecondName();

                Console.WriteLine(new string('-', 50));
            }
        }
    }
}
