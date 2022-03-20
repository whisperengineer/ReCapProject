using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()//Concrete denir
        {
            _car = new List<Car>()
            {
                new Car{CarId =1,BrandId=1,ColorId="Blue",DailyPrice=200000,ModelYear=2015,Description="Mercedes"},
                new Car{CarId =2,BrandId=1,ColorId="Black",DailyPrice=150000,ModelYear=2010,Description="Volkswagen"},
                new Car{CarId =3,BrandId=2,ColorId="Red",DailyPrice=80000,ModelYear=2005,Description="Nissan"},
                new Car{CarId =4,BrandId=2,ColorId="Yellow",DailyPrice=130000,ModelYear=2013,Description="Peugeot"},
                new Car{CarId =5,BrandId=3,ColorId="Green",DailyPrice=450000,ModelYear=2020,Description="Hyundai"},
                new Car{CarId =6,BrandId=3,ColorId="Silver",DailyPrice=1500000,ModelYear=2022,Description="Rover"}
                

            };
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _car.SingleOrDefault(p => p.CarId == car.CarId); //SingleOrDefault tek tek dolaşmaya yarar
            //Car carToDelete = _car.SingleOrDefault(car=> car.CarId == carToDelete.CarId);
            _car.Remove(car);//bunu tek kullanmayız çünkü refernasları farklı olduğu için
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public Car GetById(int id)
        {
            
            Car carToGetById = _car.SingleOrDefault(c => c.CarId == id);
            return carToGetById;
        }

        public void Update(Car car)
        {   // Gönderdiğim Car'ın Id'sini listede bul
            Car carToUpdate = _car.SingleOrDefault(c => c.CarId == car.CarId); //SingleOrDefault tek tek dolaşmaya yarar
            carToUpdate.BrandId=car.BrandId;
            carToUpdate.ColorId=car.ColorId;    
            carToUpdate.DailyPrice=car.DailyPrice;
            carToUpdate.ModelYear=car.ModelYear;
            carToUpdate.Description=car.Description;
        }

        List<Car> ICarDal.GetById(int CarToGetById)
        {
            return _car.Where(c=>c.CarId==CarToGetById).ToList();
        }
    }
}
