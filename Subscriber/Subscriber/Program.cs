using System;
using System.Collections.Generic;
using System.Threading;

namespace Subscriber
{
    public interface ISubscriber
    {
        public void Update(ISubject subject, int del, int subNum);
        public static void Loading(ISubject subject, int _delay, int _subNum)
        {
            for (int i = 0; i < _delay; i++)
            {
                Console.Write("*");
                Thread.Sleep(1000);
            }

            Console.WriteLine($"\nПодписчик {_subNum} активирован");
        }
    }

    public interface ISubject
    {
        void AddSub(ISubscriber subscriber);

        void RemoveSub(ISubscriber subscriber);

        void Notify();
    }

    public class Countdown : ISubject
    {
        public int State { get; set; } = 0;
        private int _subNum = 0;
        private int _del = 0;

        private List<ISubscriber> _subscribers = new List<ISubscriber>();

        public void AddSub(ISubscriber subscriber)
        {
            this._subscribers.Add(subscriber);
        }

        public void RemoveSub(ISubscriber subscriber)
        {
            this._subscribers.Remove(subscriber);
        }

        public void Notify()
        {
            foreach (var subscriber in _subscribers)
            {
                subscriber.Update(this, _del, _subNum);
            }
        }
        public void CountdownEvent()
        {
            Console.WriteLine("\nОбработка подписчика в процессе");
            this.State = this.State + 1;

            this.Notify();
        }

    }

    public class Subscriber1 : ISubscriber
    {
        public int _delay = 0;
        public int _subNum = 1;
        public Subscriber1(int delay)
        {
            this._delay = delay;
        }
        public void Update(ISubject subject, int _delay, int _subNum)
        {
            _delay = this._delay;
            _subNum = this._subNum;
            ISubscriber.Loading(subject, _delay, _subNum);
            Console.WriteLine("Подписчик 1 готов");
        }


    }

    public class Subscriber2 : ISubscriber
    {
        public int _delay = 0;
        public int _subNum = 2;
        public Subscriber2(int delay)
        {
            _delay = delay;
        }
        public void Update(ISubject subject, int _delay, int _subNum)
        {
            _delay = this._delay;
            _subNum = this._subNum;
            ISubscriber.Loading(subject, _delay, _subNum);
            Console.WriteLine("Подписчик 2 готов");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int seconds;
            Console.WriteLine("Введите задержку (секунды):");
            while (!int.TryParse(Console.ReadLine(), out seconds))
            {
                Console.WriteLine("Неверный формат");
                Console.WriteLine("Введите задержку (секунды):");
            }
            Countdown cnd = new Countdown();
            Console.WriteLine("Выберите подписчика (1 или 2)");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Subscriber1 Subscriber1 = new Subscriber1(seconds);
                    cnd.AddSub(Subscriber1);
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Subscriber2 Subscriber2 = new Subscriber2(seconds);
                    cnd.AddSub(Subscriber2);
                    break;
                default:
                    break;
            }
            cnd.CountdownEvent();
            Console.WriteLine("\n\nНажмите любую клавишу чтобы завершить");
            Console.ReadKey();
        }
    }
}
