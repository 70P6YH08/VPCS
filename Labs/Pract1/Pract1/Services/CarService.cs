using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using Pract1.PractDbContext;

namespace Pract1.Services
{
    public class CarService
    {
        ApplicationContext db;
        IDistributedCache cache;

        public CarService(ApplicationContext db, IDistributedCache cache)
        {
            this.db = db;
            this.cache = cache;
        }

        public async Task<Car?> GetCar(int id)
        {
            Car? car = null;

            var carString = await cache.GetStringAsync(id.ToString());  // Получение из кэша

            if (carString != null) car = JsonSerializer.Deserialize<Car>(carString); // Если есть кэш десерилизируем

            if (car == null)
            {
                car = await db.Cars.FindAsync(id); // Поиск объекта в БД

                if (car != null)
                {
                    Console.WriteLine($"{car.Model} извлечен из БД");
                    carString = JsonSerializer.Serialize(car); // Сериализация в JSON объекта

                    await cache.SetStringAsync(car.Id.ToString(), carString, new DistributedCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                    }); // Кэширование с установкой времени жизни кэша
                }
            }
            else
            {
                Console.WriteLine($"{car.Model} извлечен из кэша");
            }

            return car;
        }

        public async Task<Car?> DeleteUser(int id)
        {
            Car? car = await db.Cars.FindAsync(id);
            if (car != null) db.Cars.Remove(car);
            cache.Remove(id.ToString());
            await db.SaveChangesAsync();
            return car;
        }

    }

}
