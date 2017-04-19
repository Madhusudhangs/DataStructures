using DataStructures.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataStructures
{
    public static class QueueTestCases
    {
        public static void TestAnimalShelter()
        {
            AnimalShelter<Animal> shelterQueue = new AnimalShelter<Animal>();

            Animal dog1 = new Animal
            {
                Name = "dog1",
                Type = AnimalType.Dog,
                TimeOfArrival = DateTime.Now
            };
            shelterQueue.Enqueue(dog1);

            Thread.Sleep(5000);

            Animal dog2 = new Animal
            {
                Name = "dog2",
                Type = AnimalType.Dog,
                TimeOfArrival = DateTime.Now
            };
            shelterQueue.Enqueue(dog2);

            Thread.Sleep(5000);

            Animal cat1 = new Animal
            {
                Name = "cat1",
                Type = AnimalType.Cat,
                TimeOfArrival = DateTime.Now
            };
            shelterQueue.Enqueue(cat1);

            Thread.Sleep(5000);

            Animal dog3 = new Animal
            {
                Name = "dog3",
                Type = AnimalType.Dog,
                TimeOfArrival = DateTime.Now
            };
            shelterQueue.Enqueue(dog3);

            Thread.Sleep(5000);

            Animal cat2 = new Animal
            {
                Name = "cat2",
                Type = AnimalType.Cat,
                TimeOfArrival = DateTime.Now
            };
            shelterQueue.Enqueue(cat2);

            Console.WriteLine(shelterQueue.DequeueAny().ToString());
            Console.WriteLine(shelterQueue.DequeueCat().ToString());
            Console.WriteLine(shelterQueue.DequeueDog().ToString());
            Console.WriteLine(shelterQueue.DequeueAny().ToString());
            Console.WriteLine(shelterQueue.DequeueAny().ToString());
        }

        public static void TestStackUsingQueue()
        {
            Queue.StackUsingQueue<int> stack = new DataStructures.Queue.StackUsingQueue<int>();
            stack.PushRecursive(1);
            stack.PushRecursive(2);
            stack.PushRecursive(3);

            Console.WriteLine(stack.PopRecursive());
            Console.WriteLine(stack.PopRecursive());
            Console.WriteLine(stack.PopRecursive());
        }

    }
}
