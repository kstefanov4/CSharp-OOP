using System;
using System.Collections.Generic;
using WildFarm.Models.Animals;
using WildFarm.Models.Foods;

namespace WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Animal> animals = new List<Animal>();

            while (input != "End")
            {
                string[] animalInfo = input.Split();
                string[] fruitInfo = Console.ReadLine().Split();

                Food food;
                Animal animal;

                try
                {
                    switch (fruitInfo[0])
                    {
                        case "Vegetable":
                            food = new Vegetable(int.Parse(fruitInfo[1]));
                            break;
                        case "Fruit":
                            food = new Fruit(int.Parse(fruitInfo[1]));
                            break;
                        case "Meat":
                            food = new Meat(int.Parse(fruitInfo[1]));
                            break;
                        case "Seeds":
                            food = new Seeds(int.Parse(fruitInfo[1]));
                            break;
                        default:
                            throw new ArithmeticException("Invalid Food input");
                    }

                    switch (animalInfo[0])
                    {
                        case "Owl":
                            animal = new Owl(animalInfo[1], double.Parse(animalInfo[2]), double.Parse(animalInfo[3]));
                            break;
                        case "Hen":
                            animal = new Hen(animalInfo[1], double.Parse(animalInfo[2]), double.Parse(animalInfo[3]));
                            break;
                        case "Mouse":
                            animal = new Mouse(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3]);
                            break;
                        case "Dog":
                            animal = new Dog(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3]);
                            break;
                        case "Cat":
                            animal = new Cat(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3], animalInfo[4]);
                            break;
                        case "Tiger":
                            animal = new Tiger(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3], animalInfo[4]);
                            break;
                        default:
                            throw new ArithmeticException("Invalid Animal input");
                    }
                    animals.Add(animal);
                    Console.WriteLine(animal.ProduceSound());
                    animal.Eat(food);

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
