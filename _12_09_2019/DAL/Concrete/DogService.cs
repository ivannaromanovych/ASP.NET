using DAL.Abstract;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Concrete
{

    public class DogService : IDogService
    {
        private readonly EFContext _context = new EFContext();
        public DogService(EFContext context)
        {
            _context = context;
        }

        public event AddDogDelegate AddDogEvent;

        public void AddDogsRange(int count)
        {
            for (int i = 0; i < count; i++) 
            {
                Dog dog = new Dog()
                {
                    Name = "Semen" + (i + 1).ToString(),
                    Breed = "Mole"
                };
                _context.Dogs.Add(dog);
                _context.SaveChanges();

                Thread.Sleep(100);
                AddDogEvent?.Invoke(i + 1);
            }
        }
        public Task AddDogsRangeAsync(int count)
        {
            Action action = new Action(() => AddDogsRange(count));
            Task task = new Task(action);
            task.Start();
            return task;
        }

    }
}
