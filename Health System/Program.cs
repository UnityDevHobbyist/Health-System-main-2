 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health_System
{
    internal class Program
    {
        static int health = 100;
        static int shield = 100;
        static int lives;
        static string status;

        // Extra Mile

        static int maxHealth = 100;
        static int maxShield = 100;
        static int defaultLives = 3;
        static int maxLives = 99;

        static int experience = 0;
        static int level = 1;
        static int maxLevel = 99;
        static int experienceNeeded = 1000;
        static int experienceMultiplier = 1;

        static string weapon1 = "Beretta M9";
        static string weapon2 = "Colt AR-15";
        static string weapon3 = "Sniper Rifle";
        static string weapon4 = "Drum Gun";
        static string weapon5 = "Uzi";

        static int weapon1ammoPerMag = 15;
        static int weapon2ammoPerMag = 25;
        static int weapon3ammoPerMag = 1;
        static int weapon4ammoPerMag = 75;
        static int weapon5ammoPerMag = 32;

        static string currentWeapon = weapon1;

        //

        static void Main(string[] args)
        {
            lives = defaultLives;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Health System:");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("--------------");

            ShowHUD();
            Console.ReadKey(true);
            Console.Clear();
            TakeDamage(80);
            Console.ReadKey(true);
            Console.Clear();
            TakeDamage(80);
            Console.ReadKey(true);
            Console.Clear();
            TakeDamage(80);
            Console.ReadKey(true);
            Console.Clear();
            TakeDamage(120);
            Console.ReadKey(true);
            Console.Clear();
            Heal(20);
            Console.ReadKey(true);
            Console.Clear();
            RegenerateShield(20);
            Console.ReadKey(true);
            Console.Clear();
            TakeDamage(40);
            Console.ReadKey(true);
            Console.Clear();
            RegenerateShield(40);
            Console.ReadKey(true);
            Console.Clear();
            Heal(-5);
            Console.ReadKey(true);
            Console.Clear();
            TakeDamage(-5);
            Console.ReadKey(true);
            Console.Clear();
            RegenerateShield(-5);
            Console.ReadKey(true);
            Console.Clear();
            ONEUP();
            Console.ReadKey(true);
            GameReset();
            ShowHUD();
            Console.ReadKey(true);
            Console.Clear();
            GainExperience(2000);
            Console.ReadKey(true);
            Console.Clear();
            GainExperience(1250);
            Console.ReadKey(true);
            Console.Clear();
            TakeDamage(200);
            Console.ReadKey(true);
            Console.Clear();
            TakeDamage(200);
            Console.ReadKey(true);
            Console.Clear();
            SwitchWeapon(weapon5);
            Console.ReadKey(true);
            Console.Clear();
            ShootWeapon(5);
            Console.ReadKey(true);
            Console.Clear();
            ReloadWeapon();
            Console.ReadKey(true);
            Console.Clear();
            TakeDamage(200);
            Console.ReadKey(true);
            Console.Clear();
        }

        static int Clamp(int number, int min, int max)
        {
            int result = Math.Max(Math.Min(number, max), min);
            return result;
        }

        static void ShowHUD()
        {
            Console.WriteLine();
            Console.WriteLine("ShowHUD()");
            Console.WriteLine();
            Console.WriteLine("--------------");

            Console.WriteLine();
            Console.WriteLine("Player's health is " + health + "%" + " full.");
            Console.ResetColor();
            Console.WriteLine("Player's health status is described as " + HealthStatus() + ".");
            Console.WriteLine("Player has " + shield + " shield.");
            Console.ResetColor();
            if (lives == 1)
            {
                Console.WriteLine("Player has " + lives + " life left.");
            }
            else
            {
                Console.WriteLine("Player has " + lives + " lives left.");
            }
            Console.WriteLine("Player has " + experience + " experience.");
            Console.ResetColor();
            Console.WriteLine("Player is level " + level + ".");
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("--------------");
            Console.WriteLine();

            Console.WriteLine(weapon1 + " has " + weapon1ammoPerMag + " ammo.");
            Console.WriteLine(weapon2 + " has " + weapon2ammoPerMag + " ammo.");
            Console.WriteLine(weapon3 + " has " + weapon3ammoPerMag + " ammo.");
            Console.WriteLine(weapon4 + " has " + weapon4ammoPerMag + " ammo.");
            Console.WriteLine(weapon5 + " has " + weapon5ammoPerMag + " ammo.");
            Console.WriteLine("Current weapon: " + currentWeapon);

            Console.WriteLine();
            Console.WriteLine("--------------");
            Console.WriteLine();
        }

        static void TakeDamage(int damage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("TakeDamage(" + damage + ")");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("--------------");

            if (damage < 0)
            {
                Console.WriteLine();
                Console.WriteLine("TakeDamage(" + damage + ") does not accept negative values.");
                Console.WriteLine();
                Console.WriteLine("--------------");
                Console.WriteLine();
                return;
            }

            int damage_to_shield = 0;
            int damage_to_health = 0;

            if (shield > 0)
            {
                damage_to_shield += damage;

                if (damage_to_shield > shield)
                {
                    int remainder = damage_to_shield - shield;

                    damage_to_shield = shield;
                    damage_to_health += remainder;
                }
            }
            else
            {
                damage_to_health += damage;
            }

            shield -= damage_to_shield;
            health -= damage_to_health;

            if (health <= 0)
            {
                //Console.WriteLine();
                //Console.WriteLine("Player died.");
                //Console.WriteLine();
                //Console.WriteLine("--------------");

                health = 0;
                health = 100;
                shield = 100;
                lives -= 1;

                if (lives == 0)
                {
                    GameOver();
                    return;
                }
            }

            ShowHUD();
        }

        static void Heal(int amount)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Heal(" + amount + ")");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("--------------");

            if (amount < 0)
            {
                Console.WriteLine();
                Console.WriteLine("Heal(" + amount + ") does not accept negative values.");
                Console.WriteLine();
                Console.WriteLine("--------------");
                Console.WriteLine();
                return;
            }

            amount = Clamp(amount, 0, maxHealth);
            health += amount;
            health = Clamp(health, 0, maxHealth);

            ShowHUD();
        }

        static void RegenerateShield(int amount)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("RegenerateShield(" + amount + ")");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("--------------");

            if (amount < 0)
            {
                Console.WriteLine();
                Console.WriteLine("RegenerateShield(" + amount + ") does not accept negative values.");
                Console.WriteLine();
                Console.WriteLine("--------------");
                Console.WriteLine();
                return;
            }

            shield += amount;

            shield = Clamp(shield, 0, maxShield);

            ShowHUD();
        }

        static void ONEUP()
        {
            if (lives > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Player obtained a 1UP!");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("--------------");

                lives += 1;
                lives = Clamp(lives, 2, maxLives);

                ShowHUD();
            }
        }

        static string HealthStatus()
        {
            health = Clamp(health, 0, 100);

            if (health == 100)
            {
                status = "perfect health";
            }
            else if (health >= 80 && health < 100)
            {
                status = "healthy";
            }
            else if (health >= 60 && health < 80)
            {
                status = "hurt";
            }
            else if (health >= 40 && health < 60)
            {
                status = "badly hurt";
            }
            else if (health >= 20 && health < 40)
            {
                status = "injured";
            }
            else
            {
                status = "fatal";
            }
            return status;
        }

        static void GameReset()
        {
            health = 100;
            shield = 100;

            // Extra Mile

            maxHealth = 100;
            maxShield = 100;
            defaultLives = 3;
            maxLives = 99;

            //

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("GameReset()");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("--------------");
        }

        static void GainExperience(int exp)
        {
            experience += exp;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("GainExperience(" + experience + ")");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("--------------");

            while (experience >= experienceNeeded)
            {
                experience = experience - experienceNeeded;

                level += 1;
                level = Clamp(level, 2, maxLevel);

                experienceMultiplier += 1;
                experienceNeeded *= experienceMultiplier;
            }

            ShowHUD();
        }

        static void SwitchWeapon(string newWeaponUsed)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Player switched their " + currentWeapon + " to a " + newWeaponUsed + ".");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("--------------");

            currentWeapon = newWeaponUsed;
        }

        static void ShootWeapon(int amount)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

            if (amount != 1)
                Console.WriteLine("Player triggered their " + currentWeapon + " " + amount + " times.");
            else
                Console.WriteLine("Player triggered their " + currentWeapon + " " + amount + " time.");

            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("--------------");

            if (currentWeapon == weapon1)
            {
                if (weapon1ammoPerMag == 0) return;

                weapon1ammoPerMag -= amount;
            }
            else if (currentWeapon == weapon2)
            {
                if (weapon2ammoPerMag == 0) return;

                weapon2ammoPerMag -= amount;
            }
            else if (currentWeapon == weapon3)
            {
                if (weapon3ammoPerMag == 0) return;

                weapon3ammoPerMag -= amount;
            }
            else if (currentWeapon == weapon4)
            {
                if (weapon4ammoPerMag == 0) return;

                weapon4ammoPerMag -= amount;
            }
            else
            {
                if (weapon5ammoPerMag == 0) return;

                weapon5ammoPerMag -= amount;
            }

            ShowHUD();
        }

        static void ReloadWeapon()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Player reloaded their " + currentWeapon + ".");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("--------------");

            if (currentWeapon == weapon1)
            {
                weapon1ammoPerMag -= 15;
            }
            else if (currentWeapon == weapon2)
            {
                weapon2ammoPerMag = 25;
            }
            else if (currentWeapon == weapon3)
            {
                weapon3ammoPerMag = 1;
            }
            else if (currentWeapon == weapon4)
            {
                weapon4ammoPerMag = 75;
            }
            else
            {
                weapon5ammoPerMag = 32;
            }

            ShowHUD();
        }

        static void GameOver()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("GAME OVER!");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("--------------");
            Console.WriteLine();
        }
    }
}