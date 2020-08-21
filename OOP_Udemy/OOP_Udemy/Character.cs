using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Udemy
{
    public class Point2D
    {
        private int x;
        private int y;

        public Point2D(int x, int y)//Конструктор класса
        {
            this.x = x;// this для обращения именно к полям класса, чтобы избежать коллизий 
            this.y = y;
        }
    }
    public class Character//по умолчанию - internal. "private" и "protected" классов не бывает
    {
        private static int speed = 10;
        public string Name { get; private set; }
        public int Health { get; private set; } = 100;
        public Race Race { get; private set; }
        public int Armor { get; private set; }
        public Character(Race race)
        {
            Race = race;
           // Armor = (int)race;
           switch(race)
            {
                case Race.Elf:
                    Armor = 30;
                    break;
                case Race.Ork:
                    Armor = 40;
                    break;
                case Race.Terrarin:
                    Armor = 20;
                    break;
                default:
                    throw new ArgumentException("Unknown race.");
            }
            if(race==Race.Terrarin)
            {
                Armor = 20;
            }

            else if (race == Race.Ork)
            {
                Armor = 40;
            }

            else if (race == Race.Elf)
            {
                Armor = 30;
            }
            else { 

            }
        }
        public Character(Race race, int armor)
        {
            Race = race;
            Armor = armor;
           
        }
        public Character(string name,int armor)
        {
            if (name == null)
                throw new ArgumentNullException("Name arg can't be null");

            if (armor < 0 || armor > 100)
                throw new ArgumentException("Armor can't be less than 0 or greater than 100");

            Name = name;
            Armor = armor;
        }
        public void hit(int damage)// analogi4no private void hit
        {
            if (Health == 0)
                throw new InvalidOperationException("Can't hit a dead character");

            if (damage > Health)
                throw new ArgumentException("damage can't be greater than current Health");

            if (damage > Health)
                damage = Health;
           // health -= damage;
            Health -= damage;
        }
        public int PrintSpeed()
        {
            return speed;
        }
        public void IncreaseSpeed()
        {
            speed += 10;
        }
    }
}
