using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Queue
{
    public class AnimalShelter<T> where T : Animal
    {
        private LinkedList<T> dogList;

        private LinkedList<T> catList;

        public AnimalShelter()
        {
            this.dogList = new LinkedList<T>();
            this.catList = new LinkedList<T>();
        }

        public void Enqueue(T item)
        {
            if (item.Type == AnimalType.Dog)
            {
                this.EnqueueDog(item);
            }
            else if (item.Type == AnimalType.Cat)
            {
                this.EnqueueCat(item);
            }
        }

        public T DequeueAny()
        {
            T removedItem = null;

            if (this.dogList.First != null
                && this.catList.First != null)
            {
                if (this.dogList.First.Value.TimeOfArrival < this.catList.First.Value.TimeOfArrival)
                {
                    removedItem = this.dogList.First.Value;
                    this.dogList.RemoveFirst();
                }
                else
                {
                    removedItem = this.catList.First.Value;
                    this.catList.RemoveFirst();
                }
            }
            else if (this.catList.First == null
                && this.dogList.First!= null)
            {
                removedItem = this.dogList.First.Value;
                this.dogList.RemoveFirst();
            }
            else
            {
                removedItem = this.catList.First.Value;
                this.catList.RemoveFirst();
            }

            return removedItem;
        }

        public T DequeueDog()
        {
            if (this.dogList.First == null)
            {
                throw new InvalidCastException("Queue empty");
            }

            T dog = this.dogList.First.Value;
            this.dogList.RemoveFirst();

            return dog;
        }

        public T DequeueCat()
        {
            if (this.catList.First == null)
            {
                throw new InvalidCastException("Queue empty");
            }

            T cat = this.catList.First.Value;
            this.catList.RemoveFirst();

            return cat;
        }


        private void EnqueueDog(T dog)
        {
            LinkedListNode<T> dogNode = new LinkedListNode<T>(dog);
            this.dogList.AddLast(dogNode);
        }

        private void EnqueueCat(T cat)
        {
            LinkedListNode<T> catNode = new LinkedListNode<T>(cat);
            this.catList.AddLast(catNode);
        }
    }
}
